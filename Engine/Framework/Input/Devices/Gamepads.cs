using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Gamepads : InputDevice
    {
        internal List<Gamepad> AllGamepads = new List<Gamepad>();
        internal const int MaxGamepads = 4;
        
        public Gamepads()
        {
            foreach (var id in SDL.GetGamepads(out var count))
            {
                AddGamepad(id);
            }
        }
        

        internal override void OnDispose()
        {
            foreach (var gamepad in AllGamepads)
            {
                gamepad.OnDispose();
            }
            
            AllGamepads.Clear();
        }

        internal override void OnReset()
        {
            foreach (var gamepad in AllGamepads)
            {
                gamepad.OnReset();
            }
        }

        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                case SDL.EventType.GamepadButtonUp:
                {
                    GetGamepadByID(e.gamepadButton.gamepadID)?.OnEvent(e);
                    break;
                }
                
                case SDL.EventType.GamepadButtonDown:
                {
                    GetGamepadByID(e.gamepadButton.gamepadID)?.OnEvent(e);
                    break;
                }
                
                case SDL.EventType.GamepadAxisMotion:
                {
                    GetGamepadByID(e.gamepadAxis.gamepadID)?.OnEvent(e);
                    break;
                }

                case SDL.EventType.GamepadDeviceAdded:
                {
                    AddGamepad(e.gamepadDevice.gamepadID);
                    break;
                }

                case SDL.EventType.GamepadDeviceRemoved:
                {
                    RemoveGamepad(e.gamepadDevice.gamepadID);
                    break;
                }
            }
        }

        internal void AddGamepad(uint gamepadID)
        {
            if (GetGamepadByID(gamepadID) == null)
            {
                for (int i = 0; i < MaxGamepads; i++)
                {
                    if (GetGamepadByIndex(i) == null)
                    {
                        var handle = SDL.OpenGamepad(gamepadID);

                        if (handle != null)
                        {
                            Debug.Log($"Gamepad {gamepadID} {i} added");
                            AllGamepads.Add(new Gamepad(handle, gamepadID, i));
                            return;
                        }
                    }
                }
            }
        }

        internal void RemoveGamepad(uint gamepadID)
        {
            var gamepad = GetGamepadByID(gamepadID);
            
            if (gamepad != null)
            {
                Debug.Log($"Gamepad {gamepad.GamepadID} {gamepad.Index} removed");
                AllGamepads.Remove(gamepad);
                gamepad.OnDispose();
            }
        }
        
        internal Gamepad GetGamepadByIndex(int index)
        {
            foreach (var gamepad in AllGamepads)
            {
                if (gamepad.Index == index)
                {
                    return gamepad;
                }
            }

            return null;
        }

        internal Gamepad GetGamepadByID(uint gamepadID)
        {
            foreach (var gamepad in AllGamepads)
            {
                if (gamepad.GamepadID == gamepadID)
                {
                    return gamepad;
                }
            }

            return null;
        }
    }
}