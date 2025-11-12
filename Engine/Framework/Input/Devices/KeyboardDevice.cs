using System;

namespace Hybrid
{
    // Keyboard Device
    internal partial class KeyboardDevice : InputDevice
    {
        private readonly HashSet<Key> Down = new HashSet<Key>();
        private readonly HashSet<Key> Press = new HashSet<Key>();
        private readonly HashSet<Key> Release = new HashSet<Key>();
        
        
        internal override void OnEvent(SDL.Event e)
        {
            if (e.type == SDL.EventType.KeyboardButtonDown)
            {
                var key = (Key)e.keyboard.keyCode;

                if (!Press.Contains(key))
                {
                    Down.Add(key);
                    Press.Add(key);
                }
            }
            
            if (e.type == SDL.EventType.KeyboardButtonUp)
            {
                Key key = (Key)e.keyboard.keyCode;

                Press.Remove(key);
                Release.Add(key);
            }
        }
        
        internal override void Reset()
        {
            Down.Clear();
            Release.Clear();
        }
    }
    
    // Properties & Methods
    internal partial class KeyboardDevice
    {
        internal bool GetKey(Key key)
        {
            return Press.Contains(key);
        }

        internal bool GetKeyUp(Key key)
        {
            return Release.Contains(key);
        }
        
        internal bool GetKeyDown(Key key)
        {
            return Down.Contains(key);
        }
    }
}