using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct AudioSpec
    {
        internal SDL.AudioFormat format;
        internal int channels;
        internal int freq;
        
        internal AudioSpec(SDL.AudioFormat format = SDL.AudioFormat.S16, int channels = 2, int frequency = 44100)
        {
            format = SDL.AudioFormat.S16;
            channels = 2;
            freq = 44100;
        }
    }
}