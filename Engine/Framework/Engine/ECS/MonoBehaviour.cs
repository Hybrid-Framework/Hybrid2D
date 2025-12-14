using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Internal
    public partial class MonoBehaviour : Component
    {
        // Dispose
        internal override void OnDispose()
        {
            StopAllCoroutines();
            
            base.OnDispose();
        }
    }
    
    // Coroutines API
    public partial class MonoBehaviour
    {
        public Coroutine StartCoroutine(IEnumerator enumerator)
        {
            return Coroutines.StartCoroutine(this, enumerator);
        }

        public void StopCoroutine(Coroutine coroutine)
        {
            Coroutines.StopCoroutine(this, coroutine);
        }
        
        public void StopAllCoroutines()
        {
            Coroutines.StopAllCoroutines(this);
        }
    }

    // Script API
    public partial class MonoBehaviour
    {
        public virtual void OnAwake() { } // Called before start when created

        public virtual void OnStart() { } // Called after awake when created

        public virtual void OnEnable() { } // Called when enabled

        public virtual void OnDisable() { } // Called when disabled

        public virtual void OnUpdate() { } // Called once per frame

        public virtual void OnFixedUpdate() { } // Called at fixed rate of Time.FixedDeltaTime

        public virtual void OnDestroy() { } // Called before object is destroy
    }
}