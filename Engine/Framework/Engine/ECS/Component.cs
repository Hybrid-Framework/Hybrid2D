using System;

namespace Hybrid
{
    // Internal
    public abstract partial class Component : Behaviour
    {
        // Dispose
        internal override void OnDispose()
        {
            if (GameObject != null)
            {
                // Destroy Component
                if (GameObject.DestroyComponent(this))
                {
                    OnComponentDestroy();
                }
            }
            
            base.OnDispose();
        }
    }
    
    // Component API
    public abstract partial class Component
    {
        public bool DidAwake { get; internal set; } = false;
        public bool DidStart { get; internal set; } = false;
        
        private bool _Enabled { get; set; } = true;
        public bool Enabled
        {
            get => _Enabled;
            set
            {
                if (value != _Enabled)
                {
                    if(value) OnComponentEnable();
                    if(!value) OnComponentDisable();
                }

                _Enabled = value;
            }
        }


        internal virtual void OnComponentAwake()
        {
            if (this is MonoBehaviour monoBehaviour)
            {
                monoBehaviour.OnAwake();
            }
        }

        internal virtual void OnComponentStart()
        {
            if (this is MonoBehaviour monoBehaviour)
            {
                monoBehaviour.OnStart();
            }
        }

        internal virtual void OnComponentEnable()
        {
            if (this is MonoBehaviour monoBehaviour)
            {
                monoBehaviour.OnEnable();
            }
        }

        internal virtual void OnComponentDisable()
        {
            if (this is MonoBehaviour monoBehaviour)
            {
                monoBehaviour.OnDisable();
            }
        }

        internal virtual void OnComponentUpdate()
        {
            if (this is MonoBehaviour monoBehaviour)
            {
                monoBehaviour.OnUpdate();
            }
        }

        internal virtual void OnComponentFixedUpdate()
        {
            if (this is MonoBehaviour monoBehaviour)
            {
                monoBehaviour.OnFixedUpdate();
            }
        }

        internal virtual void OnComponentDestroy()
        {
            if (this is MonoBehaviour monoBehaviour)
            {
                monoBehaviour.OnDestroy();
            }
        }
    }
}