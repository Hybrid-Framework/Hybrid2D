using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        public Point Position;
        public Color Color;
        public Point UV;


        public Vertex(Point position, Color color, Point uv)
        {
            this.Position = position;
            this.Color = color;
            this.UV = uv;
        }
    }
}