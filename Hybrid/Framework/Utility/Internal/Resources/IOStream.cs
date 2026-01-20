using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class MemoryIOStream : IDisposable
    {
        private byte[] _data;
        private GCHandle _handle;
        public SDL.IOStream* Stream { get; private set; }
        private long _position;

        public MemoryIOStream(byte[] data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _handle = GCHandle.Alloc(_data, GCHandleType.Pinned);
            _position = 0;

            // Track positions per handle (for safety in callbacks)
            _positions[_handle] = 0;

            // Create delegates
            SDLSize sizeDel   = Size;
            SDLSeek seekDel   = Seek;
            SDLRead readDel   = Read;
            SDLWrite writeDel = Write;
            SDLFlush flushDel = Flush;
            SDLClose closeDel = Close;

            // Build IOStreamInterface
            SDL.IOStreamInterface ioInterface = new SDL.IOStreamInterface
            {
                version = 1,
                size  = Marshal.GetFunctionPointerForDelegate(sizeDel),
                seek  = Marshal.GetFunctionPointerForDelegate(seekDel),
                read  = Marshal.GetFunctionPointerForDelegate(readDel),
                write = Marshal.GetFunctionPointerForDelegate(writeDel),
                flush = Marshal.GetFunctionPointerForDelegate(flushDel),
                close = Marshal.GetFunctionPointerForDelegate(closeDel)
            };

            Stream = SDL.OpenIO(ref ioInterface, GCHandle.ToIntPtr(_handle));
            if (Stream == null)
                throw new Exception($"SDL_OpenIO failed: {SDL.GetError()}");
        }

        public void Dispose()
        {
            if (Stream != null) SDL.CloseIO(Stream);
            if (_handle.IsAllocated) _handle.Free();
        }

        // ------------------- Static Helpers -------------------

        private static readonly Dictionary<GCHandle, long> _positions = new();

        private delegate long SDLSize(IntPtr userdata);
        private delegate long SDLSeek(IntPtr userdata, long offset, SDL.IOWhence whence);
        private delegate UIntPtr SDLRead(IntPtr userdata, IntPtr ptr, UIntPtr size, UIntPtr nmemb);
        private delegate UIntPtr SDLWrite(IntPtr userdata, IntPtr ptr, UIntPtr size, UIntPtr nmemb);
        private delegate bool SDLFlush(IntPtr userdata);
        private delegate bool SDLClose(IntPtr userdata);

        private long Size(IntPtr userdata)
        {
            var data = (byte[])GCHandle.FromIntPtr(userdata).Target;
            return data.Length;
        }

        private long Seek(IntPtr userdata, long offset, SDL.IOWhence whence)
        {
            var handle = GCHandle.FromIntPtr(userdata);
            var data = (byte[])handle.Target;
            long pos = _positions[handle];

            switch (whence)
            {
                case SDL.IOWhence.SDL_IO_SEEK_SET: pos = offset; break;
                case SDL.IOWhence.SDL_IO_SEEK_CUR: pos += offset; break;
                case SDL.IOWhence.SDL_IO_SEEK_END: pos = data.Length + offset; break;
            }

            pos = Math.Clamp(pos, 0, data.Length);
            _positions[handle] = pos;
            return pos;
        }

        private UIntPtr Read(IntPtr userdata, IntPtr ptr, UIntPtr size, UIntPtr nmemb)
        {
            var handle = GCHandle.FromIntPtr(userdata);
            var data = (byte[])handle.Target;
            long pos = _positions[handle];

            ulong total = size.ToUInt64() * nmemb.ToUInt64();
            ulong available = (ulong)(data.Length - pos);
            ulong toCopy = Math.Min(total, available);

            if (toCopy > 0)
            {
                Marshal.Copy(data, (int)pos, ptr, (int)toCopy);
                pos += (long)toCopy;
                _positions[handle] = pos;
            }

            return (UIntPtr)(toCopy / size.ToUInt64());
        }

        private UIntPtr Write(IntPtr userdata, IntPtr ptr, UIntPtr size, UIntPtr nmemb) => UIntPtr.Zero;
        private bool Flush(IntPtr userdata) => true;
        private bool Close(IntPtr userdata) => true;
    }
}