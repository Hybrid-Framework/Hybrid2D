using System;

namespace Hybrid
{
    // Component
    public class Component : Behaviour
    {
        private bool hasAwake = false;
        private bool hasStart = false;

        
        protected internal override void OnProcess()
        {
            if (!hasAwake)
            {
                hasAwake = true;
                Awake();
            }

            if (!hasStart)
            {
                hasStart = true;
                Start();
            }
            
            Update();
        }

        protected internal override void OnDestroy()
        {
            if (GameObject != null)
            {
                GameObject.RemoveComponent(this);
            }
        }

        public virtual void Awake()
        {
            
        }
        
        public virtual void Start()
        {
            
        }
        
        public virtual void Update()
        {
            
        }
    }
}