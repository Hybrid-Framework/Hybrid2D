using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class TouchScreen : InputDevice
    {
        private readonly List<Touch> Touches = new List<Touch>();
        private const int MaxTouches = 8;
        
        
        // Constructor
        internal TouchScreen()
        {
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
                // Touch
                case SDL.EventType.TouchFingerUp:
                case SDL.EventType.TouchFingerDown:
                case SDL.EventType.TouchFingerMotion:
                case SDL.EventType.TouchFingerCancel:
                {
                    var touch = GetTouch((int)e.touchFinger.fingerID - 1);
                    {
                        touch.PositionDelta = new Point(e.touchFinger.x_delta * Window.GetWidth(), e.touchFinger.y_delta * Window.GetHeight());
                        touch.Position = new Point(e.touchFinger.x * Window.GetWidth(), e.touchFinger.y * Window.GetHeight());
                        touch.Pressure = e.touchFinger.pressure;

                        switch (e.type)
                        {
                            case SDL.EventType.TouchFingerUp: touch.TouchPhase = TouchPhase.Ended;break;
                            case SDL.EventType.TouchFingerDown: touch.TouchPhase = TouchPhase.Began; break;
                            case SDL.EventType.TouchFingerMotion: touch.TouchPhase = TouchPhase.Moved; break;
                            case SDL.EventType.TouchFingerCancel: touch.TouchPhase = TouchPhase.Canceled; break;
                        }
                    }
                    
                    break;
                }
            }
        }
        
        internal Touch GetTouch(int finger)
        {
            return Touches[(int)Maths.Clamp(finger, 0, MaxTouches - 1)];
        }
        
        internal int GetTouchCount()
        {
            int count = 0;

            foreach (var touch in Touches)
            {
                if (touch.TouchPhase != TouchPhase.None)
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}