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
        private void Destroy(uint device)
        {
            var result = GetByDevice(device);
            
            if (result != null)
            {
                Debug.Log($"Gamepad {result.Device} {result.Index} disconnected");
                AllDevices.Remove(result);
                result.OnDispose();
            }
        }

        // Create
        private Gamepad Create(uint device)
        {
            var result = GetByDevice(device);
            
            if (result == null)
            {
                for (int i = 0; i < MaxDevices; i++)
                {
                    if (GetByIndex(i) == null)
                    {
                        var handle = SDL.OpenGamepad(device);

                        if (handle != null)
                        {
                            Debug.Log($"Gamepad {device} {i} connected");
                            result = new Gamepad(handle, device, i);
                            AllDevices.Add(result);
                            return result;
                        }
                    }
                }
            }

            return result;
        }
        
        // Get By Player
        private Gamepad GetByIndex(int index)
        {
            foreach (var gamepad in AllDevices)
            {
                if (gamepad.Index == index)
                {
                    return gamepad;
                }
            }

            return null;
        }

        // Get By Device
        private Gamepad GetByDevice(uint device)
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