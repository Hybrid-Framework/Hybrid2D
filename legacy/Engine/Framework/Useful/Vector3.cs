using System;

namespace Hybrid
{
    // Vector3
    public partial struct Vector3
    {
        public static readonly Vector3 Positive = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        public static readonly Vector3 Negative = new Vector3(float.MinValue, float.MinValue, float.MinValue);
        
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);
        public static readonly Vector3 One = new Vector3(1, 1, 1);
        
        public static readonly Vector3 Up = new Vector3(0, 1, 0);
        public static readonly Vector3 Down = new Vector3(0, -1, 0);
        public static readonly Vector3 Right = new Vector3(1, 0, 0);
        public static readonly Vector3 Left = new Vector3(-1, 0, 0);
        public static readonly Vector3 Forward = new Vector3(0, 0, 1);
        public static readonly Vector3 Back = new Vector3(0, 0, -1);
        
        public float X;
        public float Y;
        public float Z;
        

        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3()
        {
            
        }
    }
}