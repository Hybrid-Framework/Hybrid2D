using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    // Keyboard
    public sealed partial class Keyboard : Module
    {
        private static readonly Dictionary<KeyboardButton, State> Buttons = new Dictionary<KeyboardButton, State>();

        // Constructor
        internal Keyboard()
        {
            foreach (KeyboardButton button in Enum.GetValues(typeof(KeyboardButton)))
            {
                if (button != KeyboardButton.Unknown)
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
                            if (button != KeyboardButton.Unknown)
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
                            if (button != KeyboardButton.Unknown)
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
    
    public partial class Keyboard
    {
        public static bool GetButton(KeyboardButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Press) != 0;
            }

            return false;
        }
        
        public static bool GetButtonUp(KeyboardButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Release) != 0;
            }

            return false;
        }
        
        public static bool GetButtonDown(KeyboardButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }
    }
}