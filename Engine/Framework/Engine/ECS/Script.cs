using System;

namespace Hybrid
{
    // Script API
    public class Script : Component
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