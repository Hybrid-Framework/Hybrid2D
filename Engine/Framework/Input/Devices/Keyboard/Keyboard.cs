using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Keyboard : InputDevice
    {
        internal Dictionary<Key, InputKey> Keys { get; private set; } = new Dictionary<Key, InputKey>();
        internal InputPlayer Player;
        internal uint Device;
        
        
        internal Keyboard(uint device, InputPlayer player)
        {
            this.Device = device;
            this.Player = player;
            
            foreach (Key key in Enum.GetValues(typeof(Key)))
            {
                Keys.Add(key, new InputKey());
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
            foreach (var key in Keys.Values)
            {
                key.Reset();
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
                        var key = (Key)e.keyboard.keyCode;
                        {
                            if (key != Key.Unknown)
                            {
                                if (Keys.TryGetValue(key, out var inputKey))
                                {
                                    inputKey.SetState(State.Release);
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
                        var key = (Key)e.keyboard.keyCode;
                        {
                            if (key != Key.Unknown)
                            {
                                if (Keys.TryGetValue(key, out var inputKey))
                                {
                                    inputKey.SetState(State.Press | State.Down);
                                }
                            }
                        }
                    }
                    
                    break;
                }
            }
        }
        
        internal bool GetKeyModifier(Modifier modifier)
        {
            return ((Modifier)SDL.GetModState() & modifier) != 0;
        }
        
        internal bool GetKey(Key key)
        {
            if (Keys.TryGetValue(key, out var inputKey))
            {
                return inputKey.IsPressed();
            }

            return false;
        }
        
        internal bool GetKeyDown(Key key)
        {
            if (Keys.TryGetValue(key, out var inputKey))
            {
                return inputKey.IsDown();
            }

            return false;
        }
        
        internal bool GetKeyUp(Key key)
        {
            if (Keys.TryGetValue(key, out var inputKey))
            {
                return inputKey.IsReleased();
            }

            return false;
        }
    }
}