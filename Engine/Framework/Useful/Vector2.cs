using System;

namespace Hybrid
{
    // Vector2
    public partial struct Vector2
    {
        public static readonly Vector2 Positive = new Vector2(float.MaxValue, float.MaxValue);
        public static readonly Vector2 Negative = new Vector2(float.MinValue, float.MinValue);
        
        public static readonly Vector2 Zero = new Vector2(0, 0);
        public static readonly Vector2 One = new Vector2(1, 1);
        
        public static readonly Vector2 Up = new Vector2(0, 1);
        public static readonly Vector2 Down = new Vector2(0, -1);
        public static readonly Vector2 Right = new Vector2(1, 0);
        public static readonly Vector2 Left = new Vector2(-1, 0);
        
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