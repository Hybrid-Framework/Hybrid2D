using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace SDL3;

public static unsafe partial class MIXER
{
    public const uint SDL_AUDIO_DEVICE_DEFAULT_PLAYBACK = 0xFFFFFFFFU;
    private const string nativeLibName = "SDL3_mixer";

    // Initialize the mixer library
    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial SDL.SDLBool MIX_Init();

    // Create a mixer device
    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial IntPtr MIX_CreateMixerDevice(uint deviceId, ref SDL.SDL_AudioSpec spec);

    // Load audio file
    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial IntPtr MIX_LoadAudio(IntPtr mixer, string path, SDL.SDLBool predecode);

    // Play audio
    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial SDL.SDLBool MIX_PlayAudio(IntPtr mixer, IntPtr audio);
}