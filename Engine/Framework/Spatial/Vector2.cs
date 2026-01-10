using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Vector2
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        public static readonly Vector2 Zero  = new Vector2(0, 0);
        public static readonly Vector2 One  = new Vector2(0, 0);
        
        public float X;
        public float Y;

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}