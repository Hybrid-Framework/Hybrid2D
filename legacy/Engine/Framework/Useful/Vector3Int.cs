using System;

namespace Hybrid
{
    // Vector3 Int
    public partial struct Vector3Int
    {
        public static readonly Vector3Int Positive = new Vector3Int(int.MaxValue, int.MaxValue, int.MaxValue);
        public static readonly Vector3Int Negative = new Vector3Int(int.MinValue, int.MinValue, int.MinValue);
        
        public static readonly Vector3Int Zero = new Vector3Int(0, 0, 0);
        public static readonly Vector3Int One = new Vector3Int(1, 1, 1);
        
        public static readonly Vector3Int Up = new Vector3Int(0, 1, 0);
        public static readonly Vector3Int Down = new Vector3Int(0, -1, 0);
        public static readonly Vector3Int Right = new Vector3Int(1, 0, 0);
        public static readonly Vector3Int Left = new Vector3Int(-1, 0, 0);
        public static readonly Vector3Int Forward = new Vector3Int(0, 0, 1);
        public static readonly Vector3Int Back = new Vector3Int(0, 0, -1);
        
        public int X;
        public int Y;
        public int Z;
        

        public Vector3Int(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3Int()
        {
            
        }
    }
}