using System;

namespace Hybrid
{
    // Component
    public class Component : Behaviour
    {
        private bool OnAwake = false;
        private bool OnStart = false;
        

        protected internal override void OnInitialize()
        {
            
        }

        protected internal override void OnProcess()
        {
            if (!OnAwake)
            {
                OnAwake = true;
                Awake();
            }

            if (!OnStart)
            {
                OnStart = true;
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