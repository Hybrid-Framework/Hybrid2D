using System;

namespace Hybrid
{
    public abstract class Component : Behaviour
    {
        internal override void OnDispose()
        {
            if (GameObject != null)
            {
                if (GameObject.DestroyComponent(this))
                {
                    GameObject = null;
                    Transform = null;
                }
            }
            
            base.OnDispose();
        }
    }
}