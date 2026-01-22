using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Vertex
    {
        internal Point Position;
        internal Color Color;
        internal Point UV;

        internal Vertex(Point position, Color color, Point uv)
        {
            this.Position = position;
            this.Color = color;
            this.UV = uv;
        }
    }
}