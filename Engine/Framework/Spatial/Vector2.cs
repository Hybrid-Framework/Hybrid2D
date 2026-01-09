using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Vector2
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        public float X;
        public float Y;

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}