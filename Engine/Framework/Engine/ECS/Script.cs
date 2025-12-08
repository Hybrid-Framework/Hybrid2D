using System;

namespace Hybrid
{
    // Script API
    public class Script : Component
    {
        public override void OnAwake() { } // Called before start when created

        public override void OnStart() { } // Called after awake when created

        public override void OnEnable() { } // Called when enabled

        public override void OnDisable() { } // Called when disabled

        public override void OnUpdate() { } // Called once per frame

        public override void OnFixedUpdate() { } // Called at fixed rate of Time.FixedDeltaTime

        public override void OnLateUpdate() { } // Called once per frame after update

        public override void OnDestroy() { } // Called before object is destroy
    }
}