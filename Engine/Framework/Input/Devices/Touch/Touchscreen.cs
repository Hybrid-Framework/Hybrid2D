using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Touchscreen : InputDevice
    {
        internal List<Touch> Touches = new List<Touch>();
        internal const int MaxTouches = 8;
        internal InputPlayer Player;
        internal ulong Device;
        
        
        internal Touchscreen(ulong device, InputPlayer player)
        {
            this.Device = device;
            this.Player = player;

            for (int i = 0; i < MaxTouches; i++)
            {
                Touches.Add(new Touch(i));
            }
        }
        
        // Dispose
        internal override void OnDispose()
        {
            Touches.Clear();
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var touch in Touches)
            {
                touch.Reset();
            }
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Touch Up
                case SDL.EventType.TouchFingerUp:
                {
                    var touch = GetTouch((int)e.touchFinger.fingerID);
                    {
                        touch.SetState(Phase.Ended);
                    }
                    
                    break;
                }
                
                // Touch Down
                case SDL.EventType.TouchFingerDown:
                {
                    var touch = GetTouch((int)e.touchFinger.fingerID);
                    {
                        touch.SetState(Phase.Began);
                    }
                    
                    break;
                }
                
                // Touch Motion
                case SDL.EventType.TouchFingerMotion:
                {
                    var touch = GetTouch((int)e.touchFinger.fingerID);
                    {
                        touch.Delta.SetState(e.touchFinger.x_delta, e.touchFinger.y_delta);
                        touch.Position.SetState(e.touchFinger.x, e.touchFinger.y);
                        touch.SetState(Phase.Moved);
                    }
                    
                    break;
                }
                
                // Touch Cancel
                case SDL.EventType.TouchFingerCancel:
                {
                    var touch = GetTouch((int)e.touchFinger.fingerID);
                    {
                        touch.SetState(Phase.Canceled);
                    }
                    
                    break;
                }
            }
        }
        
        internal Touch GetTouch(int finger)
        {
            return Touches[(int)Maths.Clamp(finger, 0, MaxTouches - 1)];
        }
    }
}