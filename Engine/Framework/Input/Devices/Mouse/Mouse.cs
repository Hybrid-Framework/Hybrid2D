using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Mouse : InputDevice
    {
        internal readonly Dictionary<MouseButton, KeyState> Buttons = new Dictionary<MouseButton, KeyState>();
        internal readonly Dictionary<MouseAxis, float> Axis = new Dictionary<MouseAxis, float>();
        internal Vector2 PositionDelta = Vector2.Zero;
        internal Vector2 ScrollDelta = Vector2.Zero;
        internal Vector2 Position = Vector2.Zero;
        internal Player Player;
        internal uint Device;
        
        
        internal Mouse(uint device, Player player)
        {
            this.Device = device;
            this.Player = player;

            foreach (MouseButton button in Enum.GetValues(typeof(MouseButton)))
            {
                Buttons.Add(button, KeyState.None);
            }
            
            foreach (MouseAxis axis in Enum.GetValues(typeof(MouseAxis)))
            {
                Axis.Add(axis, 0);
            }
        }
        
        // Dispose
        internal override void OnDispose()
        {
            Buttons.Clear();
            Axis.Clear();
        }

        // Reset
        internal override void OnReset()
        {
            PositionDelta = Vector2.Zero;
            ScrollDelta = Vector2.Zero;

            foreach (var axis in Axis.Keys)
            {
                Axis[axis] = 0f;
            }

            foreach (var button in Buttons.Keys)
            {
                if (GetKeyDown(button))
                {
                    Buttons[button] = KeyState.Press;
                }

                if (GetKeyUp(button))
                {
                    Buttons[button] = KeyState.None;
                }
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
                    var button = Remap(e.mouseButton.button);
                    {
                        if (Buttons.ContainsKey(button))
                        {
                            Buttons[button] = KeyState.Release;
                        }
                    }
                    
                    break;
                }
                
                // Mouse Down
                case SDL.EventType.MouseButtonDown:
                {
                    var button = Remap(e.mouseButton.button);
                    {
                        if (Buttons.ContainsKey(button))
                        {
                            Buttons[button] = KeyState.Down | KeyState.Press;
                        }
                    }
                    
                    break;
                }
                
                // Mouse Wheel
                case SDL.EventType.MouseWheel:
                {
                    var x = Maths.Clamp(e.mouseWheel.x, -1, 1);
                    var y = Maths.Clamp(e.mouseWheel.y, -1, 1);
                    
                    ScrollDelta = new Vector2(x, y);
                    
                    Axis[MouseAxis.ScrollX] = x;
                    Axis[MouseAxis.ScrollY] = y;
                    
                    break;
                }

                // Mouse Motion
                case SDL.EventType.MouseMotion:
                {
                    var x = e.mouseMotion.x;
                    var y = e.mouseMotion.y;
                    var deltaX = e.mouseMotion.x_relative;
                    var deltaY = e.mouseMotion.y_relative;
                    
                    PositionDelta = new Vector2(deltaX, deltaY);
                    Position = new Vector2(x, y);
                    
                    Axis[MouseAxis.MouseX] = deltaX;
                    Axis[MouseAxis.MouseY] = deltaY;
                    
                    break;
                }
            }
        }
        
        internal bool GetKey(MouseButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & KeyState.Press) != 0;
            }

            return false;
        }
        
        internal bool GetKeyDown(MouseButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & KeyState.Down) != 0;
            }

            return false;
        }
        
        internal bool GetKeyUp(MouseButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & KeyState.Release) != 0;
            }

            return false;
        }
        
        internal float GetAxis(MouseAxis axis)
        {
            return Axis.GetValueOrDefault(axis);
        }
        
        internal Vector2 GetPositonDelta()
        {
            return PositionDelta;
        }
        
        internal Vector2 GetScrollDelta()
        {
            return ScrollDelta;
        }

        internal Vector2 GetPositon()
        {
            return Position;
        }
        
        private MouseButton Remap(byte button)
        {
            return button switch
            {
                1 => MouseButton.Left,
                2 => MouseButton.Middle,
                3 => MouseButton.Right,
                _ => MouseButton.Unknown
            };
        }
    }
}