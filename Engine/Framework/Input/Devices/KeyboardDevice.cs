using System;

namespace Hybrid
{
    // Keyboard Device
    internal partial class KeyboardDevice : InputDevice
    {
        private List<Key> Down = new List<Key>();
        private List<Key> Press = new List<Key>();
        private List<Key> Release = new List<Key>();
        
        
        internal override void OnEvent(SDL.Event e)
        {
            Console.WriteLine($"Keyboard {e.type} {e.keyboard.keyboardID}");

            if (e.type == SDL.EventType.KeyboardButtonDown)
            {
                Key key = (Key)e.keyboard.keyCode;
            }
            
            if (e.type == SDL.EventType.KeyboardButtonUp)
            {
                Key key = (Key)e.keyboard.keyCode;
            }
        }
        
        internal override void Reset()
        {
            // called at start of frame before events & Game update
        }
    }
    
    
    // Properties & Methods
    internal partial class KeyboardDevice
    {
        internal bool GetKey(Key key)
        {
            return false;
        }

        internal bool GetKeyUp(Key key)
        {
            return false;
        }
        
        internal bool GetKeyDown(Key key)
        {
            return false;
        }
    }
}