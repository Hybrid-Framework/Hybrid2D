using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioSpec
    {
        public SDL.AudioFormat format;
        public int channels;
        public int freq;
    }
}