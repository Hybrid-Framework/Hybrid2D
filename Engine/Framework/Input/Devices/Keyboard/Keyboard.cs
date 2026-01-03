using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Keyboard : InputDevice
    {
        internal readonly Dictionary<KeyboardButton, State> Buttons = new Dictionary<KeyboardButton, State>();
        internal Player Player;
        internal uint Device;
        
        
        internal Keyboard(uint device, Player player)
        {
            this.Device = device;
            this.Player = player;
            
            foreach (KeyboardButton key in Enum.GetValues(typeof(KeyboardButton)))
            {
                Buttons.Add(key, State.None);
            }
        }
        
        // Dispose
        internal override void OnDispose()
        {
            Buttons.Clear();
        }

        // Reset
        internal override void OnReset()
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
                    var key = (KeyboardButton)e.keyboard.keyCode;
                    {
                        if (Buttons.ContainsKey(key))
                        {
                            Buttons[key] = State.Release;
                        }
                    }
                    
                    break;
                }
                
                // Keyboard Down
                case SDL.EventType.KeyboardButtonDown:
                {
                    var key = (KeyboardButton)e.keyboard.keyCode;
                    {
                        if (Buttons.ContainsKey(key))
                        {
                            Buttons[key] = State.Down | State.Press;
                        }
                    }
                    
                    break;
                }
            }
        }
        
        internal bool GetModifier(KeyModifier keyModifier)
        {
            KeyModifier current = (KeyModifier)SDL.GetModState();
            {
                return (current & keyModifier) != 0;
            }
        }
        
        internal bool GetButton(KeyboardButton keyboardButton)
        {
            if (Buttons.TryGetValue(keyboardButton, out var state))
            {
                return (state & State.Press) != 0;
            }

            return false;
        }
        
        internal bool GetButtonUp(KeyboardButton keyboardButton)
        {
            if (Buttons.TryGetValue(keyboardButton, out var state))
            {
                return (state & State.Release) != 0;
            }

            return false;
        }
        
        internal bool GetButtonDown(KeyboardButton keyboardButton)
        {
            if (Buttons.TryGetValue(keyboardButton, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }
    }
}