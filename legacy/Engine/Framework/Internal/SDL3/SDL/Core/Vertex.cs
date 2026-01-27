using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        public SDL.Point position;
        public SDL.Color color;
        public SDL.Point uv;
    }
}