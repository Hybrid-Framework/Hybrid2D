using System;

namespace Hybrid
{
    // Internal
    [DisallowDestroyComponent]
    [DisallowMultipleComponent]
    public sealed partial class Transform : Component
    {
        // Dispose
        internal override void OnDispose()
        {
            base.OnDispose();
        }
    }

    // Transform API
    public sealed partial class Transform
    {
        public Vector2 Position;
        public Vector2 Scale;
        public int Rotation;
    }
}