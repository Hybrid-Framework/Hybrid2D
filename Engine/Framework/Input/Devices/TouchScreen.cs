using System;

namespace Hybrid
{
    // Touchscreen API (prototype)
    public partial class TouchScreen : Device
    {
        private readonly List<Touch> Touches = new List<Touch>();
        private const int MaxTouches = 8;
        
        
        public int GetTouchCount()
        {
            return Touches.Count;
        }

        public Touch[] GetTouches()
        {
            return Touches.ToArray();
        }

        public Touch GetTouch(int index)
        {
            return FindByTouchID(index);
        }
    }
    
    // Touchscreen Handling
    public partial class TouchScreen
    {
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                case SDL.EventType.TouchFingerUp:
                    HandleTouchUp(e);
                    break;

                case SDL.EventType.TouchFingerDown:
                    HandleTouchDown(e);
                    break;

                case SDL.EventType.TouchFingerMotion:
                    HandleTouchMotion(e);
                    break;

                case SDL.EventType.TouchFingerCancel:
                    HandleTouchCancel(e);
                    break;
            }
        }

        private void HandleTouchUp(SDL.Event e)
        {
            var touch = FindByFingerID(e.touchFinger.fingerID);

            if (touch != null)
            {
                touch.Pressure = 0;
                touch.Phase = Phase.Ended;
            }
        }
        
        private void HandleTouchDown(SDL.Event e)
        {
            if (Touches.Count < MaxTouches)
            {
                if (FindEmptyIndex(out var index))
                {
                    int width = Window.Width;
                    int height = Window.Height;
                    
                    var touch = new Touch()
                    {
                        TouchID = index,
                        FingerID = e.touchFinger.fingerID,
                        Pressure = Maths.Clamp(e.touchFinger.pressure, 0, 1),
                        DeltaX = Maths.Clamp(e.touchFinger.x_delta, -1f, 1f) * width,
                        DeltaY = Maths.Clamp(e.touchFinger.y_delta, -1f, 1f) * height,
                        X = Maths.Clamp(e.touchFinger.x, 0f, 1f) * width,
                        Y = Maths.Clamp(e.touchFinger.y, 0f, 1f) * height,
                        Phase = Phase.Began,
                    };

                    Touches.Add(touch);
                }
            }
        }
        
        private void HandleTouchMotion(SDL.Event e)
        {
            var touch = FindByFingerID(e.touchFinger.fingerID);

            if (touch != null)
            {
                int width = Window.Width;
                int height = Window.Height;
                
                touch.Pressure = Maths.Clamp(e.touchFinger.pressure, 0, 1);
                touch.DeltaX = Maths.Clamp(e.touchFinger.x_delta, -1f, 1f) * width;
                touch.DeltaY = Maths.Clamp(e.touchFinger.y_delta, -1f, 1f) * height;
                touch.X = Maths.Clamp(e.touchFinger.x, 0f, 1f) * width;
                touch.Y = Maths.Clamp(e.touchFinger.y, 0f, 1f) * height;
                touch.Phase = Phase.Moved;
            }
        }
        
        private void HandleTouchCancel(SDL.Event e)
        {
            var touch = FindByFingerID(e.touchFinger.fingerID);

            if (touch != null)
            {
                touch.Pressure = 0;
                touch.Phase = Phase.Canceled;
            }
        }

        private bool FindEmptyIndex(out int index)
        {
            index = -1;

            for (int i = 0; i < MaxTouches; i++)
            {
                if (FindByTouchID(i) == null)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        private Touch FindByTouchID(int touchID)
        {
            foreach (var touch in Touches)
            {
                if (touch.TouchID == touchID)
                {
                    return touch;
                }
            }

            return null;
        }

        private Touch FindByFingerID(ulong finger)
        {
            foreach (var touch in Touches)
            {
                if (touch.FingerID == finger)
                {
                    return touch;
                }
            }

            return null;
        }
        
        internal override void Reset()
        {
            for (int i = Touches.Count - 1; i >= 0; i--)
            {
                var touch = Touches[i];
                
                if (touch.Phase == Phase.Ended || touch.Phase == Phase.Canceled)
                {
                    Touches.RemoveAt(i);
                    continue;
                }
                
                touch.Phase = Phase.Stationary;
                touch.DeltaX = 0;
                touch.DeltaY = 0;
            }
        }

        internal override void Dispose()
        {
            Touches.Clear();
        }
    }
}