using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Mouse : InputDevice
    {
        internal readonly Dictionary<int, State> Buttons = new Dictionary<int, State>();
        internal Vector2 PositionDelta = Vector2.Zero;
        internal Vector2 ScrollDelta = Vector2.Zero;
        internal Vector2 Position = Vector2.Zero;
        internal Player Player;
        internal uint Device;
        
        
        internal Mouse(uint device, Player player)
        {
            this.Device = device;
            this.Player = player;

            for (int i = 0; i < 8; i++)
            {
                Buttons.Add(i, State.None);
            }
        }
        
        // Dispose
        internal override void OnDispose()
        {
            Buttons.Clear();
        }

        // Reset
        internal override void OnReset()
        {
            PositionDelta = Vector2.Zero;
            ScrollDelta = Vector2.Zero;
            
            foreach (var button in Buttons.Keys)
            {
                if (GetMouseButtonDown(button))
                {
                    Buttons[button] = State.Press;
                }

                if (GetMouseButtonUp(button))
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
                    var button = Remap(e.mouseButton.button);
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
                    var button = Remap(e.mouseButton.button);
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
                    ScrollDelta = new Vector2(Maths.Clamp(e.mouseWheel.x, -1, 1), Maths.Clamp(e.mouseWheel.y, -1, 1));
                    break;
                }

                // Mouse Motion
                case SDL.EventType.MouseMotion:
                {
                    PositionDelta = new Vector2(e.mouseMotion.x_relative, e.mouseMotion.y_relative);
                    Position = new Vector2(e.mouseMotion.x, e.mouseMotion.y);
                    break;
                }
            }
        }
        
        internal bool GetMouseButton(int button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Press) != 0;
            }

            return false;
        }
        
        internal bool GetMouseButtonDown(int button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }
        
        internal bool GetMouseButtonUp(int button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Release) != 0;
            }

            return false;
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