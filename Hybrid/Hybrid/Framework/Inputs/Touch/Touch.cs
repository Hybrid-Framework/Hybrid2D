using System.Collections.Generic;
using System;

namespace Hybrid
{
    public partial class Touch : Module
    {
        private static readonly Dictionary<int, TouchHandle> Touches = new Dictionary<int, TouchHandle>();
        private const int MaxTouches = 10;


        // Constructor
        internal Touch()
        {
            for (int i = 0; i < MaxTouches; i++)
            {
                Touches.Add(i, new TouchHandle());
            }
        }

        // Reset
        internal override void OnStartOfFrame()
        {
            foreach (var touch in Touches.Values)
            {
                touch.Reset();
            }
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                case SDL.EventType.TouchFingerUp:
                case SDL.EventType.TouchFingerDown:
                case SDL.EventType.TouchFingerMotion:
                case SDL.EventType.TouchFingerCancel:
                {
                    if (Touches.TryGetValue((int)e.touchFinger.fingerID - 1, out var touch))
                    {
                        Debug.Log($"Hybridtouch: {(int)e.touchFinger.fingerID - 1}");
                        
                        if (touch != null)
                        {
                            float width = Window.GetWidth();
                            float height = Window.GetHeight();
                            
                            touch.PositionDelta = new Point(Maths.Clamp(e.touchFinger.x_delta * width, 0, width), Maths.Clamp(e.touchFinger.y_delta * height, 0, height));
                            touch.Position = new Point(Maths.Clamp(e.touchFinger.x * width, 0, width), Maths.Clamp(e.touchFinger.y * height, 0, height));
                            touch.Pressure = e.touchFinger.pressure;

                            switch (e.type)
                            {
                                case SDL.EventType.TouchFingerUp: touch.State = State.Release; break;
                                case SDL.EventType.TouchFingerDown: touch.State = State.Down; break;
                                case SDL.EventType.TouchFingerMotion: touch.State = State.Press; break;
                                case SDL.EventType.TouchFingerCancel: touch.State = State.Release; break;
                            }
                        }
                    }

                    break;
                }
            }
        }
    }
    
    public partial class Touch
    {
        // Get touch pressed
        public static bool GetTouch(int index)
        {
            if (Touches.TryGetValue(index, out var touch))
            {
                return touch.GetTouch();
            }

            return false;
        }
        
        // Get touch released
        public static bool GetTouchUp(int index)
        {
            if (Touches.TryGetValue(index, out var touch))
            {
                return touch.GetTouchUp();
            }

            return false;
        }
        
        // Get touch down (single frame)
        public static bool GetTouchDown(int index)
        {
            if (Touches.TryGetValue(index, out var touch))
            {
                return touch.GetTouchDown();
            }

            return false;
        }
        
        // Get touch position delta
        public static Point GetTouchPositionDelta(int index)
        {
            if (Touches.TryGetValue(index, out var touch))
            {
                return touch.GetPositionDelta();
            }

            return new Point();
        }
        
        // Get touch position
        public static Point GetTouchPosition(int index)
        {
            if (Touches.TryGetValue(index, out var touch))
            {
                return touch.GetPosition();
            }

            return new Point();
        }
        
        // Get touch pressure
        public static float GetTouchPressure(int index)
        {
            if (Touches.TryGetValue(index, out var touch))
            {
                return touch.GetPressure();
            }

            return 0;
        }
        
        // Get touch count
        public static int GetTouchCount()
        {
            int count = 0;

            foreach (var touch in Touches.Values)
            {
                if (touch.State != State.None)
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}