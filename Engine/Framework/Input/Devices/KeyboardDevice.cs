using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class KeyboardDevice : InputDevice
    {
        internal Dictionary<Key, InputKey> Keys { get; private set; } = new Dictionary<Key, InputKey>();

        internal KeyboardDevice()
        {
            foreach (Key key in Enum.GetValues(typeof(Key)))
            {
                Keys.Add(key, new InputKey());
            }
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
                // Keyboard Down
                case SDL.EventType.KeyboardButtonDown:
                {
                    if (!e.keyboard.repeat)
                    {
                        var key = (Key)e.keyboard.keyCode;
            
                        if (Keys.TryGetValue(key, out var inputKey))
                        {
                            inputKey.SetState(InputState.Press | InputState.Down);
                        }
                    }
                        
                    break;
                }
                    
                // Keyboard Up
                case SDL.EventType.KeyboardButtonUp:
                {
                    if (!e.keyboard.repeat)
                    {
                        var key = (Key)e.keyboard.keyCode;

                        if (Keys.TryGetValue(key, out var inputKey))
                        {
                            inputKey.SetState(InputState.Release);
                        }
                    }

                    break;
                }
            }
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