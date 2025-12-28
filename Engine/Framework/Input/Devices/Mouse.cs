using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Mouse : InputDevice
    {
        internal Dictionary<int, InputKey> Keys { get; private set; } = new Dictionary<int, InputKey>();
        internal InputVector MouseScrollDelta { get; private set; } = new InputVector();
        internal InputVector MousePosition { get; private set; } = new InputVector();
        internal InputVector MouseDelta { get; private set; } = new InputVector();
        internal uint DeviceID;
        internal int PlayerID;
        
        
        internal Mouse(uint deviceID, int playerID)
        {
            this.PlayerID = playerID;
            this.DeviceID = deviceID;

            for (int i = 0; i < 8; i++)
            {
                Keys.Add(i, new InputKey());
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
            MouseScrollDelta.Reset();
            MouseDelta.Reset();
            
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
                // Mouse Up
                case SDL.EventType.MouseButtonUp:
                {
                    var key = Remap(e.mouseButton.button);

                    if (Keys.TryGetValue(key, out var inputKey))
                    {
                        inputKey.SetState(InputState.Release);
                    }
                    
                    break;
                }
                
                // Mouse Down
                case SDL.EventType.MouseButtonDown:
                {
                    var key = Remap(e.mouseButton.button);
            
                    if (Keys.TryGetValue(key, out var inputKey))
                    {
                        inputKey.SetState(InputState.Press | InputState.Down);
                    }
                    
                    break;
                }

                // Mouse Motion
                case SDL.EventType.MouseMotion:
                {
                    MouseDelta.SetValue(e.mouseMotion.x_relative, e.mouseMotion.y_relative);
                    MousePosition.SetValue(e.mouseMotion.x, e.mouseMotion.y);
                    break;
                }
                
                // Mouse Wheel
                case SDL.EventType.MouseWheel:
                {
                    MouseScrollDelta.SetValue(e.mouseWheel.x, e.mouseWheel.y, -1, 1);
                    break;
                }
            }
        }
        
        internal bool GetMouseButton(int button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.IsPressed();
            }

            return false;
        }
        
        internal bool GetMouseButtonDown(int button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.IsDown();
            }

            return false;
        }
        
        internal bool GetMouseButtonUp(int button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.IsReleased();
            }

            return false;
        }
        
        private int Remap(byte button)
        {
            return button switch
            {
                1 => 0,
                3 => 1,
                2 => 2,
                4 => 3,
                5 => 4,
                6 => 5,
                7 => 6,
                8 => 7,
                9 => 8,
                10 => 9,
                11 => 10,
                12 => 11,
                13 => 12,
                14 => 13,
                15 => 14,
                16 => 15,
                
                _ => -1
            };
        }
    }
}