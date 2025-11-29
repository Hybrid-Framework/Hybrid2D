using System;

namespace Hybrid
{
    public class Transform : Component
    {
        public Vector2 Position;
        public Vector2 Scale;
        public int Rotation;

        internal override void OnDestroy()
        {
            base.OnDestroy();
            
            Position = Vector2.Zero;
            Scale = Vector2.Zero;
            Rotation = 0;
        }
    }
}