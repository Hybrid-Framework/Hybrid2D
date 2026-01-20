using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IOStreamInterface
    {
        public uint version;
        public IntPtr size; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr seek; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr read; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr write; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr flush; // WARN_ANONYMOUS_FUNCTION_POINTER
        public IntPtr close; // WARN_ANONYMOUS_FUNCTION_POINTER
    }
}