using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class TouchScreen : InputDevice
    {
        internal readonly List<Touch> Touches = new List<Touch>();
        internal const int MaxTouches = 8;
        internal Player Player;
        internal ulong Device;
        
        
        internal TouchScreen(ulong device, Player player)
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
                case SDL.EventType.TouchFingerDown:
                case SDL.EventType.TouchFingerMotion:
                case SDL.EventType.TouchFingerCancel:
                {
                    var touch = GetTouch((int)e.touchFinger.fingerID - 1);
                    {
                        touch.PositionDelta = new Vector2(e.touchFinger.x_delta * Window.GetWidth(), e.touchFinger.y_delta * Window.GetHeight());
                        touch.Position = new Vector2(e.touchFinger.x * Window.GetWidth(), e.touchFinger.y * Window.GetHeight());
                        touch.Pressure = e.touchFinger.pressure;

                        switch (e.type)
                        {
                            case SDL.EventType.TouchFingerUp: touch.Phase = Phase.Ended;break;
                            case SDL.EventType.TouchFingerDown: touch.Phase = Phase.Began; break;
                            case SDL.EventType.TouchFingerMotion: touch.Phase = Phase.Moved; break;
                            case SDL.EventType.TouchFingerCancel: touch.Phase = Phase.Canceled; break;
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
        
        internal int TouchCount()
        {
            int count = 0;

            foreach (var touch in Touches)
            {
                if (touch.Phase != Phase.None)
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}