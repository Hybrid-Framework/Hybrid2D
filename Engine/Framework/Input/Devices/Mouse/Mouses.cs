using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Mouses : InputDevice
    {
        internal readonly List<Mouse> AllMice = new List<Mouse>();
        internal const int MaxMice = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var mouse in AllMice.ToArray())
            {
                DestroyMouse(mouse.DeviceID);
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
                // Mouse Up
                case SDL.EventType.MouseButtonUp:
                {
                    var mouse = CreateMouse(e.mouseButton.mouseID);
                    {
                        mouse?.OnEvent(e);
                    }
                    
                    break;
                }
                
                // Mouse Down
                case SDL.EventType.MouseButtonDown:
                {
                    var mouse = CreateMouse(e.mouseButton.mouseID);
                    {
                        mouse?.OnEvent(e);
                    }
                    
                    break;
                }

                // Mouse Motion
                case SDL.EventType.MouseMotion:
                {
                    var mouse = CreateMouse(e.mouseMotion.mouseID);
                    {
                        mouse?.OnEvent(e);
                    }
                    
                    break;
                }

                // Mouse Wheel
                case SDL.EventType.MouseWheel:
                {
                    var mouse = CreateMouse(e.mouseWheel.mouseID);
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

        private Mouse CreateMouse(uint deviceID)
        {
            var found = GetMouseByDeviceID(deviceID);
            
            if (found == null)
            {
                for (int i = 0; i < MaxMice; i++)
                {
                    if (GetMouseByPlayerID(i) == null)
                    {
                        Debug.Log($"Mouse {deviceID} {i} added");
                        
                        var mouse = new Mouse(deviceID, i);
                        AllMice.Add(mouse);
                        return mouse;
                    }
                }
            }
            
            return found;
        }

        private void DestroyMouse(uint deviceID)
        {
            var mouse = GetMouseByDeviceID(deviceID);
            
            if (mouse != null)
            {
                Debug.Log($"Mouse {mouse.DeviceID} {mouse.PlayerID} removed");
                
                AllMice.Remove(mouse);
                mouse.OnDispose();
            }
        }
        
        internal Mouse GetMouseByPlayerID(int playerID)
        {
            foreach (var mouse in AllMice)
            {
                if (mouse.PlayerID == playerID)
                {
                    return mouse;
                }
            }

            return null;
        }

        internal Mouse GetMouseByDeviceID(uint deviceID)
        {
            foreach (var mouse in AllMice)
            {
                if (mouse.DeviceID == deviceID)
                {
                    return mouse;
                }
            }

            return null;
        }
    }
}