using System;

namespace Hybrid
{
    [DisallowDestroyComponent]
    [DisallowMultipleComponent]
    public sealed class Transform : Component
    {
        public Transform()
        {
            Transform = this;
        }
    }
}