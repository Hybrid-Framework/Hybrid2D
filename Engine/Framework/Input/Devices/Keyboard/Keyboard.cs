using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Keyboard : InputDevice
    {
        internal readonly Dictionary<Key, State> Keys = new Dictionary<Key, State>();
        internal Player Player;
        internal uint Device;
        
        
        internal Keyboard(uint device, Player player)
        {
            this.Device = device;
            this.Player = player;
            
            foreach (Key key in Enum.GetValues(typeof(Key)))
            {
                Keys.Add(key, State.None);
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
                    Keys[key] = State.Press;
                }

                if (GetKeyUp(key))
                {
                    Keys[key] = State.None;
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
                            Keys[key] = State.Release;
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
                            Keys[key] = State.Down | State.Press;
                        }
                    }
                    
                    break;
                }
            }
        }
        
        internal bool GetKeyModifier(Modifier modifier)
        {
            Modifier current = (Modifier)SDL.GetModState();
            {
                return (current & modifier) != 0;
            }
        }
        
        internal bool GetKey(Key key)
        {
            if (Keys.TryGetValue(key, out var state))
            {
                return (state & State.Press) != 0;
            }

            return false;
        }
        
        internal bool GetKeyDown(Key key)
        {
            if (Keys.TryGetValue(key, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }
        
        internal bool GetKeyUp(Key key)
        {
            if (Keys.TryGetValue(key, out var state))
            {
                return (state & State.Release) != 0;
            }

            return false;
        }
    }
}