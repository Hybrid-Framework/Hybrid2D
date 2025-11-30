using System;

namespace Hybrid
{
    // Component
    public class Component : Behaviour
    {
        internal override void OnDispose()
        {
            base.OnDispose();

            if (GameObject != null)
            {
                // Remove From GameObject
                GameObject.RemoveComponent(this);
            }

            // Remove
            GameObject = null;
            Transform = null;
        }
    }
}