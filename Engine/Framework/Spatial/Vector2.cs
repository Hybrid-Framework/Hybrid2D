using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Vector2
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        public static readonly Vector2 Zero  = new Vector2(0, 0);
        public static readonly Vector2 One  = new Vector2(1, 1);
        public static readonly Vector2 Left  = new Vector2(-1, 0);
        public static readonly Vector2 Right  = new Vector2(1, 0);
        public static readonly Vector2 Down  = new Vector2(0, -1);
        public static readonly Vector2 Up  = new Vector2(0, 1);
        
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2()
        {
            
        }
    }
}