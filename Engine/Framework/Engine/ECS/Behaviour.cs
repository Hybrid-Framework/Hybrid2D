using System;

namespace Hybrid
{
    // Behaviour
    public class Behaviour : Object
    {
        public GameObject GameObject { get; internal set; }
        public Transform Transform { get; internal set; }
        
        internal bool _Enabled = true;
        public bool Enabled
        {
            get => _Enabled;
            set
            {
                if (this is Component component)
                {
                    if (value != Enabled)
                    {
                        if (!value)
                        {
                            component.OnDisable();
                        }
                        else
                        {
                            component.OnEnable();
                        }
                    }
                }

                _Enabled = value;
            }
        }
    }
}