using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Gamepads : InputDevice
    {
        internal readonly List<Gamepad> AllGamepads = new List<Gamepad>();
        internal const int MaxGamepads = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var gamepad in AllGamepads.ToArray())
            {
                DestroyGamepad(gamepad.Device);
            }
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
                // Gamepad
                case SDL.EventType.GamepadButtonUp:
                case SDL.EventType.GamepadButtonDown:
                case SDL.EventType.GamepadAxisMotion:
                {
                    var gamepad = CreateGamepad(e.gamepadDevice.gamepadID);
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

        internal Gamepad CreateGamepad(uint device)
        {
            var found = GetGamepadByDevice(device);
            
            if (found == null)
            {
                for (int i = 0; i < MaxGamepads; i++)
                {
                    var player = (Player)i;
                    
                    if (GetGamepadByPlayer(player) == null)
                    {
                        var handle = SDL.OpenGamepad(device);

                        if (handle != null)
                        {
                            Debug.Log($"Gamepad {device} {player} connected");
                            
                            var gamepad = new Gamepad(handle, device, player);
                            AllGamepads.Add(gamepad);
                            return gamepad;
                        }
                    }
                }
            }

            return found;
        }

        internal void DestroyGamepad(uint device)
        {
            var gamepad = GetGamepadByDevice(device);
            
            if (gamepad != null)
            {
                Debug.Log($"Gamepad {gamepad.Device} {gamepad.Player} disconnected");
                
                AllGamepads.Remove(gamepad);
                gamepad.OnDispose();
            }
        }
        
        internal Gamepad GetGamepadByPlayer(Player player)
        {
            foreach (var gamepad in AllGamepads)
            {
                if (gamepad.Player == player)
                {
                    return gamepad;
                }
            }

            return null;
        }

        internal Gamepad GetGamepadByDevice(uint device)
        {
            foreach (var gamepad in AllGamepads)
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