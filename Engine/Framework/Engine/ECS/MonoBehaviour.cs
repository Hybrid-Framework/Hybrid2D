using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Internal
    public partial class MonoBehaviour : Component
    {
        // Destroy
        internal override void OnComponentDestroy()
        {
            StopAllCoroutines();
            StopAllInvokes();
        }
    }
    
    // Invoke API
    public partial class MonoBehaviour
    {
        public void StartInvokeRepeating(string name, float delay, float repeat)
        {
            Invoking.StartInvokeRepeating(this, name, delay, repeat);
        }
        
        public void StartInvoke(string name, float delay)
        {
            Invoking.StartInvoke(this, name, delay);
        }

        public void StopInvoke(string name)
        {
            Invoking.StopInvoke(this, name);
        }

        public void StopAllInvokes()
        {
            Invoking.StopAllInvokes(this);
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