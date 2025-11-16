using System;

namespace Hybrid
{
    // Vector2
    public partial struct Vector2
    {
        public static readonly Vector2 PositiveInfinity = new(float.PositiveInfinity, float.PositiveInfinity);
        public static readonly Vector2 NegativeInfinity = new(float.NegativeInfinity, float.NegativeInfinity);
        
        public static readonly Vector2 Zero = new(0, 0);
        public static readonly Vector2 One = new(1, 1);
        
        public static readonly Vector2 Up = new(0, 1);
        public static readonly Vector2 Down = new(0, -1);
        public static readonly Vector2 Left = new(-1, 0);
        public static readonly Vector2 Right = new(1, 0);
        
        public float X;
        public float Y;
        

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2()
        {
            
        }
    }
}