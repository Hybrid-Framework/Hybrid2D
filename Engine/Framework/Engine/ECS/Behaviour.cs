using System;

namespace Hybrid
{
    // Behaviour
    public abstract class Behaviour : Object
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