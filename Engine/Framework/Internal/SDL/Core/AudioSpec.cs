using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioSpec
    {
        public SDL.AudioFormat format;
        public int channels;
        public int freq;

        public AudioSpec(SDL.AudioFormat format = SDL.AudioFormat.S32, int channels = 2, int freq = 44100)
        {
            this.channels = channels;
            this.format = format;
            this.freq = freq;
        }
    }
}