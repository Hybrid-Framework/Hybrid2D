using System;

namespace Hybrid
{
    [DisallowDestroyComponent]
    [DisallowMultipleComponent]
    public sealed partial class Transform : Component
    {
        // Constructor
        internal Transform(GameObject gameObject)
        {
            // Ensure only one Transform
            if (!gameObject.GetComponent<Transform>())
            {
                GameObject = gameObject;
                Name = gameObject.Name;
                Transform = this;
            }
        }
    }
}