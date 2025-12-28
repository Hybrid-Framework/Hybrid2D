using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Gamepads : InputDevice
    {
        internal readonly List<Gamepad> AllGamepads = new List<Gamepad>();
        internal const int MaxGamepads = 4;

        // Constructor
        internal Gamepads()
        {
            // Register Gamepads
            foreach (var gamepad in SDL.GetGamepads(out var count))
            {
                CreateGamepad(gamepad);
            }
        }

        // Dispose
        internal override void OnDispose()
        {
            foreach (var gamepad in AllGamepads)
            {
                gamepad.OnDispose();
            }
            
            AllGamepads.Clear();
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var gamepad in AllGamepads)
            {
                gamepad.OnReset();
            }
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Gamepad Up
                case SDL.EventType.GamepadButtonUp:
                {
                    var gamepad = CreateGamepad(e.gamepadButton.gamepadID);
                    {
                        gamepad?.OnEvent(e);
                    }
                    
                    break;
                }
                
                // Gamepad Down
                case SDL.EventType.GamepadButtonDown:
                {
                    var gamepad = CreateGamepad(e.gamepadButton.gamepadID);
                    {
                        gamepad?.OnEvent(e);
                    }
                    
                    break;
                }
                
                // Gamepad Axis
                case SDL.EventType.GamepadAxisMotion:
                {
                    var gamepad = CreateGamepad(e.gamepadAxis.gamepadID);
                    {
                        gamepad?.OnEvent(e);
                    }
                    
                    break;
                }
                
                // Gamepad Connected
                case SDL.EventType.GamepadDeviceAdded:
                {
                    CreateGamepad(e.gamepadDevice.gamepadID);
                    break;
                }
                
                // Gamepad Disconnected
                case SDL.EventType.GamepadDeviceRemoved:
                {
                    DestroyGamepad(e.gamepadDevice.gamepadID);
                    break;
                }
            }
        }

        internal Gamepad CreateGamepad(uint deviceID)
        {
            var found = GetGamepadByDeviceID(deviceID);
            
            if (found == null)
            {
                for (int i = 0; i < MaxGamepads; i++)
                {
                    if (GetGamepadByPlayerID(i) == null)
                    {
                        var handle = SDL.OpenGamepad(deviceID);

                        if (handle != null)
                        {
                            Debug.Log($"Gamepad {deviceID} {i} added");
                            
                            var gamepad = new Gamepad(handle, deviceID, i);
                            AllGamepads.Add(gamepad);
                            return gamepad;
                        }
                    }
                }
            }

            return found;
        }

        internal void DestroyGamepad(uint deviceID)
        {
            var gamepad = GetGamepadByDeviceID(deviceID);
            
            if (gamepad != null)
            {
                Debug.Log($"Gamepad {gamepad.DeviceID} {gamepad.PlayerID} removed");
                
                AllGamepads.Remove(gamepad);
                gamepad.OnDispose();
            }
        }
        
        internal Gamepad GetGamepadByPlayerID(int playerID)
        {
            foreach (var gamepad in AllGamepads)
            {
                if (gamepad.PlayerID == playerID)
                {
                    return gamepad;
                }
            }

            return null;
        }

        internal Gamepad GetGamepadByDeviceID(uint deviceID)
        {
            foreach (var gamepad in AllGamepads)
            {
                if (gamepad.DeviceID == deviceID)
                {
                    return gamepad;
                }
            }

            return null;
        }
    }
}