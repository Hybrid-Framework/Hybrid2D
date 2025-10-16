using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioSpec
    {
        public SDL.AudioFormat format;
        public int channels;
        public int freq;
        
        public AudioSpec()
        {
            format = SDL.AudioFormat.S16;
            channels = 1;
            freq = 44100;
        }
    }
}