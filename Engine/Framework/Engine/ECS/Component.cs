using System;

namespace Hybrid
{
    // Component
    public partial class Component : Object
    {
        protected internal virtual bool SingletonComponent() => false;
        protected internal virtual bool RequiredComponent() => false;
        
        protected internal bool InitializedComponent { get; set; }
        
        internal bool _Enabled = true;
        public bool Enabled
        {
            get => _Enabled;
            set
            {
                if (value != Enabled)
                {
                    if (!value)
                    {
                        OnDisable();
                    }
                    else
                    {
                        OnEnable();
                    }
                }

                _Enabled = value;
            }
        }
        
        protected Component()
        {
            
        }
        
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