using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Mouses : InputDevice
    {
        internal readonly List<Mouse> AllDevices = new List<Mouse>();
        internal const int MaxDevices = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var mouse in AllDevices.ToArray())
            {
                Destroy(mouse.Device);
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var mouse in AllDevices)
            {
                mouse.OnReset();
            }
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Mouse
                case SDL.EventType.MouseButtonDown:
                case SDL.EventType.MouseButtonUp:
                case SDL.EventType.MouseMotion:
                case SDL.EventType.MouseWheel:
                {
                    var mouse = Create(e.mouseDevice.mouseID);
                    {
                        mouse?.OnEvent(e);
                    }
                    
                    break;
                }

                // Mouse Disconnected
                case SDL.EventType.MouseDeviceRemoved:
                {
                    Destroy(e.mouseDevice.mouseID);
                    break;
                }
            }
        }
        
        internal void Destroy(uint device)
        {
            var mouse = GetByDevice(device);
            
            if (mouse != null)
            {
                Debug.Log($"Mouse {mouse.Device} {mouse.Player} disconnected");
                
                AllDevices.Remove(mouse);
                mouse.OnDispose();
            }
        }

        internal Mouse Create(uint device)
        {
            var found = GetByDevice(device);
            
            if (found == null)
            {
                for (int i = 0; i < MaxDevices; i++)
                {
                    var player = (Player)i;
                    
                    if (GetByPlayer(player) == null)
                    {
                        Debug.Log($"Mouse {device} {player} connected");
                        
                        var mouse = new Mouse(device, player);
                        AllDevices.Add(mouse);
                        return mouse;
                    }
                }
            }
            
            return found;
        }
        
        internal Mouse GetByPlayer(Player player)
        {
            foreach (var mouse in AllDevices)
            {
                if (mouse.Player == player)
                {
                    return mouse;
                }
            }

            return null;
        }

        internal Mouse GetByDevice(uint device)
        {
            foreach (var mouse in AllDevices)
            {
                if (mouse.Device == device)
                {
                    return mouse;
                }
            }

            return null;
        }
    }
}