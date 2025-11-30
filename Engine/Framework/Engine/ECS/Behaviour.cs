using System;

namespace Hybrid
{
    // Internal
    public abstract partial class Behaviour : Object
    {
        // Dispose
        internal override void OnDispose()
        {
            GameObject = null;
            Transform = null;
            
            base.OnDispose();
        }
    }
    
    // Behaviour API
    public abstract partial class Behaviour
    {
        public GameObject GameObject { get; internal set; }
        public Transform Transform { get; internal set; }

        private bool _Enabled = true;
        public bool Enabled
        {
            get => _Enabled;
            set
            {
                if (this is Component component)
                {
                    if (_Enabled != value)
                    {
                        if (value)
                        {
                            component.OnEnable();
                        }
                        else
                        {
                            component.OnDisable();
                        }
                    }
                }

                _Enabled = value;
            }
        }
    }
}