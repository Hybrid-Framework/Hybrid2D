using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class TouchScreens : InputDevice
    {
        internal readonly List<TouchScreen> AllDevices = new List<TouchScreen>();
        internal const int MaxDevices = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var touchscreen in AllDevices.ToArray())
            {
                Destroy(touchscreen.Device);
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var touchscreen in AllDevices)
            {
                touchscreen.OnReset();
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
                    var touchscreen = Create(e.touchFinger.touchDeviceID);
                    {
                        touchscreen?.OnEvent(e);
                    }
                    
                    break;
                }
            }
        }
        
        internal void Destroy(ulong device)
        {
            var touchscreen = GetByDevice(device);
            
            if (touchscreen != null)
            {
                Debug.Log($"Touchscreen {touchscreen.Device} {touchscreen.Player} disconnected");
                
                AllDevices.Remove(touchscreen);
                touchscreen.OnDispose();
            }
        }

        internal TouchScreen Create(ulong device)
        {
            var found = GetByDevice(device);
            
            if (found == null)
            {
                for (int i = 0; i < MaxDevices; i++)
                {
                    var player = (Player)i;
                    
                    if (GetByPlayer(player) == null)
                    {
                        Debug.Log($"Touchscreen {device} {player} connected");
                        
                        var touchscreen = new TouchScreen(device, player);
                        AllDevices.Add(touchscreen);
                        return touchscreen;
                    }
                }
            }
            
            return found;
        }
        
        internal TouchScreen GetByPlayer(Player player)
        {
            foreach (var touchscreen in AllDevices)
            {
                if (touchscreen.Player == player)
                {
                    return touchscreen;
                }
            }

            return null;
        }

        internal TouchScreen GetByDevice(ulong device)
        {
            foreach (var touchscreen in AllDevices)
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