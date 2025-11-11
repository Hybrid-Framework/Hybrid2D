using System;

namespace Hybrid
{
    // Gamepad Device
    internal partial class GamepadDevice : InputDevice
    {
        internal override void OnEvent(SDL.Event e)
        {
            Console.WriteLine($"Gamepad {e.type} {e.gamepadButton.gamepadID}");

            switch (e.type)
            {
                case SDL.EventType.GamepadButtonUp:
                    break;

                case SDL.EventType.GamepadButtonDown:
                    break;

                case SDL.EventType.GamepadAxisMotion:
                    break;
            }
        }
    }
    
    
    // Properties & Methods
    internal partial class GamepadDevice
    {
        internal float GetAxis(Axis axis)
        {
            return 0;
        }
        
        internal bool GetButton(Button button)
        {
            return false;
        }

        internal bool GetButtonUp(Button button)
        {
            return false;
        }
        
        internal bool GetButtonDown(Button button)
        {
            return false;
        }
    }
}