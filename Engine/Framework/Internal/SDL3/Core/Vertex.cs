using System.Runtime.InteropServices;
using Hybrid;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Vertex
    {
        public Point Position;
        public Color Color;
        public Point UV;

        internal Vertex(Point position, Color color, Point uv)
        {
            this.Position = position;
            this.Color = color;
            this.UV = uv;
        }
    }
}