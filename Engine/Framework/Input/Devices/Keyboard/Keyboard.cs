using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Keyboard : InputDevice
    {
        internal readonly Dictionary<Key, KeyState> Keys = new Dictionary<Key, KeyState>();
        internal Player Player;
        internal uint Device;
        
        
        internal Keyboard(uint device, Player player)
        {
            this.Device = device;
            this.Player = player;
            
            foreach (Key key in Enum.GetValues(typeof(Key)))
            {
                Keys.Add(key, KeyState.None);
            }
        }
        
        // Dispose
        internal override void OnDispose()
        {
            Keys.Clear();
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var key in Keys.Keys)
            {
                if (GetKeyDown(key))
                {
                    Keys[key] = KeyState.Press;
                }

                if (GetKeyUp(key))
                {
                    Keys[key] = KeyState.None;
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
                    var key = (Key)e.keyboard.keyCode;
                    {
                        if (Keys.ContainsKey(key))
                        {
                            Keys[key] = KeyState.Release;
                        }
                    }
                    
                    break;
                }
                
                // Keyboard Down
                case SDL.EventType.KeyboardButtonDown:
                {
                    var key = (Key)e.keyboard.keyCode;
                    {
                        if (Keys.ContainsKey(key))
                        {
                            Keys[key] = KeyState.Down | KeyState.Press;
                        }
                    }
                    
                    break;
                }
            }
        }
        
        internal bool GetKeyModifier(KeyModifier keyModifier)
        {
            KeyModifier current = (KeyModifier)SDL.GetModState();
            {
                return (current & keyModifier) != 0;
            }
        }
        
        internal bool GetKey(Key key)
        {
            if (Keys.TryGetValue(key, out var state))
            {
                return (state & KeyState.Press) != 0;
            }

            return false;
        }
        
        internal bool GetKeyDown(Key key)
        {
            if (Keys.TryGetValue(key, out var state))
            {
                return (state & KeyState.Down) != 0;
            }

            return false;
        }
        
        internal bool GetKeyUp(Key key)
        {
            if (Keys.TryGetValue(key, out var state))
            {
                return (state & KeyState.Release) != 0;
            }

            return false;
        }
    }
}