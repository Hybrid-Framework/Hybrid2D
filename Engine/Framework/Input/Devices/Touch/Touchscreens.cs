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
                DestroyTouchscreen(touchscreen.Device);
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

        private Touchscreen CreateTouchscreen(ulong device)
        {
            var found = GetTouchscreenByDevice(device);
            
            if (found == null)
            {
                for (int i = 0; i < MaxTouchscreens; i++)
                {
                    var player = (InputPlayer)i;
                    
                    if (GetTouchscreenByPlayer(player) == null)
                    {
                        Debug.Log($"Touchscreen {device} {player} connected");
                        
                        var touchscreen = new Touchscreen(device, player);
                        AllTouchscreens.Add(touchscreen);
                        return touchscreen;
                    }
                }
            }
            
            return found;
        }

        private void DestroyTouchscreen(ulong device)
        {
            var touchscreen = GetTouchscreenByDevice(device);
            
            if (touchscreen != null)
            {
                Debug.Log($"Touchscreen {touchscreen.Device} {touchscreen.Player} disconnected");
                
                AllTouchscreens.Remove(touchscreen);
                touchscreen.OnDispose();
            }
        }
        
        internal Touchscreen GetTouchscreenByPlayer(InputPlayer player)
        {
            foreach (var touchscreen in AllTouchscreens)
            {
                if (touchscreen.Player == player)
                {
                    return touchscreen;
                }
            }

            return null;
        }

        internal Touchscreen GetTouchscreenByDevice(ulong device)
        {
            foreach (var touchscreen in AllTouchscreens)
            {
                if (touchscreen.Device == device)
                {
                    return touchscreen;
                }
            }

            return null;
        }
    }
}