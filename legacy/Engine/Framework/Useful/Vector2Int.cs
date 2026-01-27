using System;

namespace Hybrid
{
    // Vector2 Int
    public partial struct Vector2Int
    {
        public static readonly Vector2Int Positive = new Vector2Int(int.MaxValue, int.MaxValue);
        public static readonly Vector2Int Negative = new Vector2Int(int.MinValue, int.MinValue);
        
        public static readonly Vector2Int Zero = new Vector2Int(0, 0);
        public static readonly Vector2Int One = new Vector2Int(1, 1);
        
        public static readonly Vector2Int Up = new Vector2Int(0, 1);
        public static readonly Vector2Int Down = new Vector2Int(0, -1);
        public static readonly Vector2Int Right = new Vector2Int(1, 0);
        public static readonly Vector2Int Left = new Vector2Int(-1, 0);
        
        public int X;
        public int Y;
        

        public Vector2Int(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2Int()
        {
            
        }
    }
}