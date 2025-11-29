using System;

namespace Hybrid
{
    // Component
    public class Component : Behaviour
    {
        internal override void OnDestroy()
        {
            base.OnDestroy();

            if (GameObject != null)
            {
                GameObject.DetachComponent(this);
            }
        }
    }
}