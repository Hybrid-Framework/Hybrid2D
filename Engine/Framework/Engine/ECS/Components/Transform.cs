using System;

namespace Hybrid
{
    [DisallowDestroyComponent]
    [DisallowMultipleComponent]
    public class Transform : Component
    {
        public Vector2 Position;
        public Vector2 Scale;
        public int Rotation;

        internal override void OnDispose()
        {
            base.OnDispose();
            
            Position = Vector2.Zero;
            Scale = Vector2.Zero;
            Rotation = 0;
        }
    }
}