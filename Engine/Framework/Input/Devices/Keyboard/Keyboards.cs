using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Keyboards : InputDevice
    {
        internal readonly List<Keyboard> AllDevices = new List<Keyboard>();
        internal const int MaxDevices = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var keyboard in AllDevices.ToArray())
            {
                Destroy(keyboard.Device);
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var keyboard in AllDevices)
            {
                keyboard.OnReset();
            }
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Keyboard
                case SDL.EventType.KeyboardButtonUp:
                case SDL.EventType.KeyboardButtonDown:
                {
                    if (!e.keyboard.repeat)
                    {
                        if (e.keyboard.keyCode != SDL.KeyCode.Unknown)
                        {
                            var keyboard = Create(e.keyboardDevice.keyboardID);
                            {
                                keyboard?.OnEvent(e);
                            }
                        }
                    }
                    
                    break;
                }

                // Keyboard Disconnected
                case SDL.EventType.KeyboardDeviceRemoved:
                {
                    Destroy(e.keyboardDevice.keyboardID);
                    break;
                }
            }
        }
        
        // Destroy
        internal void Destroy(uint device)
        {
            var result = GetByDevice(device);
            
            if (result != null)
            {
                Debug.Log($"Keyboard {result.Device} {result.Player} disconnected");
                
                AllDevices.Remove(result);
                result.OnDispose();
            }
        }

        // Create
        internal Keyboard Create(uint device)
        {
            var result = GetByDevice(device);
            
            if (result == null)
            {
                for (int i = 0; i < MaxDevices; i++)
                {
                    var player = (Player)i;
                    
                    if (GetByPlayer(player) == null)
                    {
                        Debug.Log($"Keyboard {device} {player} connected");
                        
                        result = new Keyboard(device, player);
                        AllDevices.Add(result);
                        return result;
                    }
                }
            }
            
            return result;
        }
        
        // Get By Player
        internal Keyboard GetByPlayer(Player player)
        {
            foreach (var keyboard in AllDevices)
            {
                if (keyboard.Player == player)
                {
                    return keyboard;
                }
            }

            return null;
        }

        // Get By Device
        internal Keyboard GetByDevice(uint device)
        {
            foreach (var keyboard in AllDevices)
            {
                if (keyboard.Device == device)
                {
                    return keyboard;
                }
            }

            return null;
        }
    }
}