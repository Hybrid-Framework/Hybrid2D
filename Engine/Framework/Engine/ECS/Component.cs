using System;

namespace Hybrid
{
    // Component
    public partial class Component : Behaviour
    {
        protected internal virtual bool SingletonComponent() => false;
        protected internal virtual bool RequiredComponent() => false;
        
        
        internal override void Dispose()
        {
            if (GameObject != null)
            {
                OnDestroy();
                
                GameObject.DetachComponent(this);
                GameObject = null;
                Transform = null;
            }
        }
    }
    
    // Component API
    public partial class Component
    {
        internal bool InitializedComponent { get; set; }
        
        
        public virtual void OnStart()
        {
            
        }

        public virtual void OnUpdate()
        {
            
        }

        public virtual void OnEnable()
        {
            
        }

        public virtual void OnDisable()
        {
            
        }
        
        public virtual void OnDestroy()
        {
            
        }
    }
}