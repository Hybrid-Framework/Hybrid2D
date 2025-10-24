using System;

namespace Hybrid
{
    public partial struct Ray
    {
        public Vector3 position;
        public Vector3 direction;

        public Ray(Vector3 position, Vector3 direction)
        {
            this.position = position;
            this.direction = direction;
        }
    }
}