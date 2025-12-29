using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Touchscreens : InputDevice
    {
        internal readonly List<Touchscreen> AllTouchscreens = new List<Touchscreen>();
        internal const int MaxTouchscreens = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var touchscreen in AllTouchscreens.ToArray())
            {
                DestroyTouchscreen(touchscreen.DeviceID);
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var touchscreen in AllTouchscreens)
            {
                touchscreen.OnReset();
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
                    var touchscreen = CreateTouchscreen(e.touchFinger.touchDeviceID);
                    {
                        touchscreen?.OnEvent(e);
                    }
                    
                    break;
                }
            }
        }

        private Touchscreen CreateTouchscreen(ulong deviceID)
        {
            var found = GetTouchscreenByDeviceID(deviceID);
            
            if (found == null)
            {
                for (int i = 0; i < MaxTouchscreens; i++)
                {
                    if (GetTouchscreenByPlayerID(i) == null)
                    {
                        Debug.Log($"Touchscreen {deviceID} {i} added");
                        
                        var touchscreen = new Touchscreen(deviceID, i);
                        AllTouchscreens.Add(touchscreen);
                        return touchscreen;
                    }
                }
            }
            
            return found;
        }

        private void DestroyTouchscreen(ulong deviceID)
        {
            var touchscreen = GetTouchscreenByDeviceID(deviceID);
            
            if (touchscreen != null)
            {
                Debug.Log($"Touchscreen {touchscreen.DeviceID} {touchscreen.PlayerID} removed");
                
                AllTouchscreens.Remove(touchscreen);
                touchscreen.OnDispose();
            }
        }
        
        internal Touchscreen GetTouchscreenByPlayerID(int playerID)
        {
            foreach (var touchscreen in AllTouchscreens)
            {
                if (touchscreen.PlayerID == playerID)
                {
                    return touchscreen;
                }
            }

            return null;
        }

        internal Touchscreen GetTouchscreenByDeviceID(ulong deviceID)
        {
            foreach (var touchscreen in AllTouchscreens)
            {
                if (touchscreen.DeviceID == deviceID)
                {
                    return touchscreen;
                }
            }

            return null;
        }
    }
}