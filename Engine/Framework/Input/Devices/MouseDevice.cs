using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class MouseDevice : InputDevice
    {
        internal Dictionary<int, InputKey> Keys { get; private set; } = new Dictionary<int, InputKey>();
        internal InputVector ScrollDelta { get; private set; } = new InputVector();
        internal InputVector Position { get; private set; } = new InputVector();
        internal InputVector Delta { get; private set; } = new InputVector();
        
        internal MouseDevice()
        {
            for (int i = 0; i < 3; i++)
            {
                Keys.Add(i, new InputKey());
            }
        }
        
        
        // Reset
        internal override void OnReset()
        {
            Delta.SetValue(Vector2.Zero);
            ScrollDelta.SetValue(Vector2.Zero);
            
            foreach (var key in Keys.Values)
            {
                switch (key.GetState())
                {
                    case InputState.Press | InputState.Down:
                    {
                        key.SetState(InputState.Down);
                        break;
                    }
                    
                    case InputState.Release:
                    {
                        key.SetState(InputState.None);
                        break;
                    }
                }
            }
        }
        
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
                    Delta.SetValue(new Vector2(e.mouseMotion.x_relative, e.mouseMotion.y_relative));
                    Position.SetValue(new Vector2(e.mouseMotion.x, e.mouseMotion.y));
                    break;
                }
                
                // Mouse Wheel
                case SDL.EventType.MouseWheel:
                {
                    float x = Maths.Clamp(e.mouseWheel.x, -1, 1);
                    float y = Maths.Clamp(e.mouseWheel.y, -1, 1);
                    ScrollDelta.SetValue(new Vector2(x, y));
                    break;
                }
            }
        }
        
        internal bool GetMouseButton(int button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.Press();
            }

            return false;
        }
        
        internal bool GetMouseButtonDown(int button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.Down();
            }

            return false;
        }
        
        internal bool GetMouseButtonUp(int button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.Release();
            }

            return false;
        }
        
        private int Remap(byte button)
        {
            return button switch { 1 => 0, 2 => 2, 3 => 1, _ => -1 };
        }
    }
}