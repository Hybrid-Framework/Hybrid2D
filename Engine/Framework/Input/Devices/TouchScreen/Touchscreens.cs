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
        
        // Destroy
        internal void Destroy(ulong device)
        {
            var result = GetByDevice(device);
            
            if (result != null)
            {
                Debug.Log($"Touchscreen {result.Device} {result.Player} disconnected");
                
                AllDevices.Remove(result);
                result.OnDispose();
            }
        }

        // Create
        internal TouchScreen Create(ulong device)
        {
            var result = GetByDevice(device);
            
            if (result == null)
            {
                for (int i = 0; i < MaxDevices; i++)
                {
                    var player = (Player)i;
                    
                    if (GetByPlayer(player) == null)
                    {
                        Debug.Log($"Touchscreen {device} {player} connected");
                        
                        result = new TouchScreen(device, player);
                        AllDevices.Add(result);
                        return result;
                    }
                }
            }
            
            return result;
        }
        
        // Get By Player
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

        // Get By Device
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