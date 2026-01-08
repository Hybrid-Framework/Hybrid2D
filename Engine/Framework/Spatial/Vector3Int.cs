using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Vector3 Int
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3Int
    {
        public int X;
        public int Y;
        public int Z;


        public Vector3Int(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}