using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        public SDL.FPoint position;
        public SDL.FColor color;
        public SDL.FPoint uv;
    }
}