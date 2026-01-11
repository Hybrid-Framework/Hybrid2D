using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    // Vector4
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4
    {
        public static readonly Vector4 Zero  = new Vector4(0, 0, 0, 0);
        public static readonly Vector4 One  = new Vector4(1, 1, 1, 1);
        
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

        public Vector4()
        {
            
        }
    }
}