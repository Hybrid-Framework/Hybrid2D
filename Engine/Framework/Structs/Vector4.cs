using System;

namespace Hybrid
{
    public partial struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }

    public partial struct Vector4
    {
        public static readonly Vector4 PositiveInfinity = new(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        public static readonly Vector4 NegativeInfinity = new(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        
        public static readonly Vector4 OneMinus = new(-1, -1, -1, -1);
        public static readonly Vector4 Zero = new(0, 0, 0, 0);
        public static readonly Vector4 One = new(1, 1, 1, 1);
    }
}