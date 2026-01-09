using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Vector2 Int
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2Int
    {
        public int X;
        public int Y;

        public Vector2Int(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}