using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Vector4 Int
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4Int
    {
        public int X;
        public int Y;
        public int Z;
        public int W;

        public Vector4Int(int x, int y, int z, int w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }
    }
}