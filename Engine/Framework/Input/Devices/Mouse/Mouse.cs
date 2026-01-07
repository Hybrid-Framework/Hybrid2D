using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    internal class Mouse : InputDevice
    {
        private readonly Dictionary<MouseButton, State> Buttons = new Dictionary<MouseButton, State>();
        private readonly Dictionary<MouseAxis, float> Axes = new Dictionary<MouseAxis, float>();
        private Vector2 PositionDelta = Vector2.Zero;
        private Vector2 ScrollDelta = Vector2.Zero;
        private Vector2 Position = Vector2.Zero;
        
        
        // Constructor
        internal Mouse()
        {
            foreach (MouseButton button in Enum.GetValues(typeof(MouseButton)))
            {
                Buttons.Add(button, State.None);
            }
            
            foreach (MouseAxis axis in Enum.GetValues(typeof(MouseAxis)))
            {
                Axes.Add(axis, 0);
            }
        }

        // Reset
        internal override void OnReset()
        {
            PositionDelta = Vector2.Zero;
            ScrollDelta = Vector2.Zero;

            foreach (var axis in Axes.Keys)
            {
                Axes[axis] = 0f;
            }

            foreach (var button in Buttons.Keys)
            {
                if (GetButtonDown(button))
                {
                    Buttons[button] = State.Press;
                }

                if (GetButtonUp(button))
                {
                    Buttons[button] = State.None;
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
                    var button = InputMapping.GetMouseButtonFromSDL(e.mouseButton.button);
                    {
                        if (button != MouseButton.Unknown)
                        {
                            if (Buttons.ContainsKey(button))
                            {
                                Buttons[button] = State.Release;
                            }
                        }
                    }
                    
                    break;
                }
                
                // Mouse Down
                case SDL.EventType.MouseButtonDown:
                {
                    var button = InputMapping.GetMouseButtonFromSDL(e.mouseButton.button);
                    {
                        if (button != MouseButton.Unknown)
                        {
                            if (Buttons.ContainsKey(button))
                            {
                                Buttons[button] = State.Down | State.Press;
                            }
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
                    
                    Axes[MouseAxis.ScrollX] = x;
                    Axes[MouseAxis.ScrollY] = y;
                    
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
                    
                    Axes[MouseAxis.MouseX] = deltaX;
                    Axes[MouseAxis.MouseY] = deltaY;
                    
                    break;
                }
            }
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
        
        internal bool GetButton(MouseButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Press) != 0;
            }

            return false;
        }
        
        internal bool GetButtonUp(MouseButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Release) != 0;
            }

            return false;
        }
        
        internal bool GetButtonDown(MouseButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }
        
        internal float GetAxis(MouseAxis axis)
        {
            return Axes.GetValueOrDefault(axis);
        }
    }
}