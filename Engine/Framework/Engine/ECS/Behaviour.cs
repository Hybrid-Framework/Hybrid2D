using System;

namespace Hybrid
{
    public class Behaviour : Object
    {
        public GameObject GameObject { get; internal set; }
        public Transform Transform { get; internal set; }
        
        
        protected internal virtual void OnProcess()
        {
            
        }
    }
}