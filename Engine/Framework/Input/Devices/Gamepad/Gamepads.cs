using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Gamepads : InputDevice
    {
        internal readonly List<Gamepad> AllDevices = new List<Gamepad>();
        internal const int MaxDevices = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var gamepad in AllDevices.ToArray())
            {
                Destroy(gamepad.Device);
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var gamepad in AllDevices)
            {
                gamepad.OnReset();
            }
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Gamepad
                case SDL.EventType.GamepadButtonUp:
                case SDL.EventType.GamepadButtonDown:
                case SDL.EventType.GamepadAxisMotion:
                {
                    var gamepad = Create(e.gamepadDevice.gamepadID);
                    {
                        gamepad?.OnEvent(e);
                    }
                    
                    break;
                }
                
                // Gamepad Connected
                case SDL.EventType.GamepadDeviceAdded:
                {
                    Create(e.gamepadDevice.gamepadID);
                    break;
                }
                
                // Gamepad Disconnected
                case SDL.EventType.GamepadDeviceRemoved:
                {
                    Destroy(e.gamepadDevice.gamepadID);
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
                Debug.Log($"Gamepad {result.Device} {result.Player} disconnected");
                
                AllDevices.Remove(result);
                result.OnDispose();
            }
        }

        // Create
        internal Gamepad Create(uint device)
        {
            var result = GetByDevice(device);
            
            if (result == null)
            {
                for (int i = 0; i < MaxDevices; i++)
                {
                    var player = (Player)i;
                    
                    if (GetByPlayer(player) == null)
                    {
                        var handle = SDL.OpenGamepad(device);

                        if (handle != null)
                        {
                            Debug.Log($"Gamepad {device} {player} connected");
                            
                            result = new Gamepad(handle, device, player);
                            AllDevices.Add(result);
                            return result;
                        }
                    }
                }
            }

            return result;
        }
        
        // Get By Player
        internal Gamepad GetByPlayer(Player player)
        {
            foreach (var gamepad in AllDevices)
            {
                if (gamepad.Player == player)
                {
                    return gamepad;
                }
            }

            return null;
        }

        // Get By Device
        internal Gamepad GetByDevice(uint device)
        {
            foreach (var gamepad in AllDevices)
            {
                if (gamepad.Device == device)
                {
                    return gamepad;
                }
            }

            return null;
        }
    }
}