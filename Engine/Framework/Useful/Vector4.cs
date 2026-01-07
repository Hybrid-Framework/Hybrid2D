using System;

namespace Hybrid
{
    // Vector4
    public partial struct Vector4
    {
        public static readonly Vector4 Positive = new Vector4(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
        public static readonly Vector4 Negative = new Vector4(float.MinValue, float.MinValue, float.MinValue, float.MinValue);
        
        public static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);
        public static readonly Vector4 One = new Vector4(1, 1, 1, 1);
        
        public float X;
        public float Y;
        public float Z;
        public float W;
        

        public Vector4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Vector4()
        {
            
        }
    }
}