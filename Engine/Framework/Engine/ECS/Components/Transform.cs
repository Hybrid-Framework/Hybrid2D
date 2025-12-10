using System;

namespace Hybrid
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Transform))]
    public sealed partial class Transform : Component
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;
    }
}