using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Vertex
    {
        public SDL.FPoint position;
        public SDL.FColor color;
        public SDL.FPoint uv;
    }
}