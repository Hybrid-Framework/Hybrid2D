using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Mice : InputDevice
    {
        internal readonly List<Mouse> AllMice = new List<Mouse>();
        internal const int MaxMice = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var mouse in AllMice.ToArray())
            {
                DestroyMouse(mouse.Device);
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var mouse in AllMice)
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
                    var mouse = CreateMouse(e.mouseDevice.mouseID);
                    {
                        mouse?.OnEvent(e);
                    }
                    
                    break;
                }

                // Mouse Disconnected
                case SDL.EventType.MouseDeviceRemoved:
                {
                    DestroyMouse(e.mouseDevice.mouseID);
                    break;
                }
            }
        }

        private Mouse CreateMouse(uint device)
        {
            var found = GetMouseByDevice(device);
            
            if (found == null)
            {
                for (int i = 0; i < MaxMice; i++)
                {
                    var player = (Player)i;
                    
                    if (GetMouseByPlayer(player) == null)
                    {
                        Debug.Log($"Mouse {device} {player} connected");
                        
                        var mouse = new Mouse(device, player);
                        AllMice.Add(mouse);
                        return mouse;
                    }
                }
            }
            
            return found;
        }

        private void DestroyMouse(uint device)
        {
            var mouse = GetMouseByDevice(device);
            
            if (mouse != null)
            {
                Debug.Log($"Mouse {mouse.Device} {mouse.Player} disconnected");
                
                AllMice.Remove(mouse);
                mouse.OnDispose();
            }
        }
        
        internal Mouse GetMouseByPlayer(Player player)
        {
            foreach (var mouse in AllMice)
            {
                if (mouse.Player == player)
                {
                    return mouse;
                }
            }

            return null;
        }

        internal Mouse GetMouseByDevice(uint device)
        {
            foreach (var mouse in AllMice)
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