using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    internal class Mouse : InputDevice
    {
        private readonly Dictionary<MouseButton, State> Buttons = new Dictionary<MouseButton, State>();
        private Point PositionDelta = Point.Zero;
        private Point ScrollDelta = Point.Zero;
        private Point Position = Point.Zero;
        
        
        // Constructor
        internal Mouse()
        {
            foreach (MouseButton button in Enum.GetValues(typeof(MouseButton)))
            {
                if (button != MouseButton.Unknown)
                {
                    Buttons.Add(button, State.None);
                }
            }
        }

        // Reset
        internal override void OnReset()
        {
            PositionDelta = Point.Zero;
            ScrollDelta = Point.Zero;

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
                    
                    ScrollDelta = new Point(x, y);
                    
                    break;
                }

                // Mouse Motion
                case SDL.EventType.MouseMotion:
                {
                    var x = e.mouseMotion.x;
                    var y = e.mouseMotion.y;
                    var deltaX = e.mouseMotion.x_relative;
                    var deltaY = e.mouseMotion.y_relative;
                    
                    PositionDelta = new Point(deltaX, deltaY);
                    Position = new Point(x, y);
                    
                    break;
                }
            }
        }
        
        internal Point GetPositonDelta()
        {
            return PositionDelta;
        }
        
        internal Point GetScrollDelta()
        {
            return ScrollDelta;
        }

        internal Point GetPositon()
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
    }
}