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
        
        internal void Destroy(uint device)
        {
            var gamepad = GetByDevice(device);
            
            if (gamepad != null)
            {
                Debug.Log($"Gamepad {gamepad.Device} {gamepad.Player} disconnected");
                
                AllDevices.Remove(gamepad);
                gamepad.OnDispose();
            }
        }

        internal Gamepad Create(uint device)
        {
            var found = GetByDevice(device);
            
            if (found == null)
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
                            
                            var gamepad = new Gamepad(handle, device, player);
                            AllDevices.Add(gamepad);
                            return gamepad;
                        }
                    }
                }
            }

            return found;
        }
        
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