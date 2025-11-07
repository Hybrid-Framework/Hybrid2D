using System;

namespace Hybrid
{
    // Component
    public class Component : Behaviour
    {
        protected internal bool InitializedComponent { get; set; } = false;
        protected internal virtual bool SingletonComponent() => false;
        protected internal virtual bool RequiredComponent() => false;
        
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

        internal override void Dispose()
        {
            base.Dispose();
            
            if (GameObject != null)
            {
                OnDestroy();
                
                GameObject.DetachComponent(this);
                GameObject = null;
                Transform = null;
            }
        }
    }
}