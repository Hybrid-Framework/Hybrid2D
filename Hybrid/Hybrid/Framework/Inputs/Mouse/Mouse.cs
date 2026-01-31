using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    // Internal
    public partial class Mouse : Module
    {
        private static readonly Dictionary<int, State> Buttons = new Dictionary<int, State>();
        private static Point PositionDelta = Point.Zero;
        private static Point ScrollDelta = Point.Zero;
        private static Point Position = Point.Zero;
        private const int MaxButtons = 8;


        // Constructor
        internal Mouse()
        {
            for(int i=0; i<MaxButtons; i++)
            {
                Buttons.Add(i, State.None);
            }
        }

        // Reset
        internal override void OnStartOfFrame()
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
                    var button = Mapping.GetMouseFromSDL(e.mouseButton.button);
                    {
                        if (Buttons.ContainsKey(button))
                        {
                            Buttons[button] = State.Release;
                        }
                    }

                    break;
                }

                // Mouse Down
                case SDL.EventType.MouseButtonDown:
                {
                    var button = Mapping.GetMouseFromSDL(e.mouseButton.button);
                    {
                        if (Buttons.ContainsKey(button))
                        {
                            Buttons[button] = State.Down | State.Press;
                        }
                    }

                    break;
                }

                // Mouse Wheel
                case SDL.EventType.MouseWheel:
                {
                    ScrollDelta = new Point(Maths.Clamp(e.mouseWheel.x, -1, 1), Maths.Clamp(e.mouseWheel.y, -1, 1));
                    break;
                }

                // Mouse Motion
                case SDL.EventType.MouseMotion:
                {
                    PositionDelta = new Point(e.mouseMotion.x_relative, e.mouseMotion.y_relative);
                    Position = new Point(e.mouseMotion.x, e.mouseMotion.y);
                    break;
                }
            }
        }
    }
    
    public partial class Mouse
    {
        // Get mouse button pressed
        public static bool GetButton(int index)
        {
            if (Buttons.TryGetValue(index, out var state))
            {
                return (state & State.Press) != 0;
            }

            return false;
        }
        
        // Get mouse button released
        public static bool GetButtonUp(int index)
        {
            if (Buttons.TryGetValue(index, out var state))
            {
                return (state & State.Release) != 0;
            }

            return false;
        }
        
        // Get mouse button down (single frame)
        public static bool GetButtonDown(int index)
        {
            if (Buttons.TryGetValue(index, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }
        
        // Get mouse positon delta
        public static Point GetPositonDelta()
        {
            return PositionDelta;
        }
        
        // Get mouse scroll delta
        public static Point GetScrollDelta()
        {
            return ScrollDelta;
        }

        // Get mouse positon
        public static Point GetPositon()
        {
            return Position;
        }

        // Show mouse
        public static void ShowCursor()
        {
            SDL.ShowCursor();
        }
        
        // Hide mouse
        public static void HideCursor()
        {
            SDL.HideCursor();
        }
    }
}