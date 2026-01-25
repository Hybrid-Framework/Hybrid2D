using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    // Keyboard
    internal partial class Keyboard : InputDevice
    {
        private static readonly Dictionary<Key, State> Buttons = new Dictionary<Key, State>();

        // Constructor
        internal Keyboard()
        {
            foreach (Key button in Enum.GetValues(typeof(Key)))
            {
                if (button != Key.Unknown)
                {
                    Buttons.Add(button, State.None);
                }
            }
        }

        // Reset
        internal override void OnStartOfFrame()
        {
            foreach (var key in Buttons.Keys)
            {
                if (GetButtonDown(key))
                {
                    Buttons[key] = State.Press;
                }

                if (GetButtonUp(key))
                {
                    Buttons[key] = State.None;
                }
            }
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Keyboard Up
                case SDL.EventType.KeyboardButtonUp:
                {
                    if (!e.keyboard.repeat)
                    {
                        var button = Mapping.GetKeyboardButtonFromSDLScanCode(e.keyboard.scanCode);
                        {
                            if (button != Key.Unknown)
                            {
                                if (Buttons.ContainsKey(button))
                                {
                                    Buttons[button] = State.Release;
                                }
                            }
                        }
                    }

                    break;
                }

                // Keyboard Down
                case SDL.EventType.KeyboardButtonDown:
                {
                    if (!e.keyboard.repeat)
                    {
                        var button = Mapping.GetKeyboardButtonFromSDLScanCode(e.keyboard.scanCode);
                        {
                            if (button != Key.Unknown)
                            {
                                if (Buttons.ContainsKey(button))
                                {
                                    Buttons[button] = State.Down | State.Press;
                                }
                            }
                        }
                    }

                    break;
                }
            }
        }
    }
    
    internal partial class Keyboard
    {
        // Get keyboard button pressed
        internal bool GetButton(Key button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Press) != 0;
            }

            return false;
        }
        
        // Get keyboard button released
        internal bool GetButtonUp(Key button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Release) != 0;
            }

            return false;
        }
        
        // Get keyboard button down (single frame)
        internal bool GetButtonDown(Key button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }
    }
}