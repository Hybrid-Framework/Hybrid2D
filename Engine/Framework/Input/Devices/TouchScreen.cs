using System;

namespace Hybrid
{
    // Touch Device
    internal partial class TouchScreen : Device
    {
        internal override void OnEvent(SDL.Event e)
        {
            // Console.WriteLine($"Touch {e.type} {e.touchFinger.fingerID}");

            switch (e.type)
            {
                case SDL.EventType.TouchFingerUp:
                    break;

                case SDL.EventType.TouchFingerDown:
                    break;

                case SDL.EventType.TouchFingerMotion:
                    break;

                case SDL.EventType.TouchFingerCancel:
                    break;
            }
        }
    }
    

    // Properties & Methods
    internal partial class TouchScreen
    {
        internal int GetTouchCount()
        {
            return GetTouches().Length;
        }

        internal Touch[] GetTouches()
        {
            return null;
        }

        internal Touch GetTouch(int id)
        {
            return new Touch();
        }
    }
}