using System;

namespace Hybrid
{
    // Keyboard Device
    internal partial class KeyboardDevice : InputDevice
    {
        internal override void OnEvent(SDL.Event e)
        {
            Console.WriteLine($"Keyboard {e.type}");

            switch (e.type)
            {
                case SDL.EventType.KeyboardButtonUp:
                    break;

                case SDL.EventType.KeyboardButtonDown:
                    break;
            }
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