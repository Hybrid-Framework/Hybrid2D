using System;

namespace Hybrid
{
    public abstract class Component : Behaviour
    {
        internal override void OnDispose()
        {
            if (GameObject != null)
            {
                if (GameObject.DestroyComponentInternal(this))
                {
                    GameObject = null;
                    Transform = null;
                }
            }
            
            base.OnDispose();
        }
    }
}