using System;

namespace Hybrid
{
    // Transform
    public class Transform : Component
    {
        protected internal override bool SingletonComponent() => true;
        protected internal override bool RequiredComponent() => true;

        public Vector2 Position = Vector2.Zero;
        public Vector2 Scale = Vector2.One;
        public float Rotation = 0;
    }
}