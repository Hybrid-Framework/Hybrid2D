using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Mouses : InputDevices
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
        
        // Destroy
        internal void Destroy(ulong device)
        {
            var result = GetByDevice(device);
            
            if (result != null)
            {
                Debug.Log($"Mouse {result.Device} {result.Player} disconnected");
                
                AllDevices.Remove(result);
                result.OnDispose();
            }
        }

        // Create
        internal Mouse Create(ulong device)
        {
            var result = GetByDevice(device);
            
            if (result == null)
            {
                for (int i = 0; i < MaxDevices; i++)
                {
                    var player = (Player)i;
                    
                    if (GetByPlayer(player) == null)
                    {
                        Debug.Log($"Mouse {device} {player} connected");
                        
                        result = new Mouse(device, player);
                        AllDevices.Add(result);
                        return result;
                    }
                }
            }
            
            return result;
        }
        
        // Get By Player
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

        // Get By Device
        internal Mouse GetByDevice(ulong device)
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