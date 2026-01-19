using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Gamepad : Module
    {
        private static readonly Dictionary<int, GamepadHandle> Gamepads = new Dictionary<int, GamepadHandle>();
        
        
        // On Start Of Frame
        internal override void OnStartOfFrame()
        {
            foreach (var gamepad in Gamepads.Values)
            {
                gamepad.Reset();
            }
        }

        // Destroy
        internal override void Destroy()
        {
            foreach (var gamepad in Gamepads.Values)
            {
                Disconnect(gamepad.Device);
            }
        }

        // On Event
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Gamepad Up
                case SDL.EventType.GamepadButtonUp:
                {
                    var index = SDL.GetGamepadPlayerIndexForID(e.gamepadDevice.gamepadID);
                    {
                        if (Gamepads.TryGetValue(index, out var gamepad))
                        {
                            var button = Mapping.GetGamepadButtonFromSDL(e.gamepadButton.button);
                            {
                                if (button != Button.Unknown)
                                {
                                    if (gamepad.Buttons.ContainsKey(button))
                                    {
                                        gamepad.Buttons[button] = State.Release;
                                    }
                                }
                            }
                        }
                    }

                    break;
                }
                
                // Gamepad Down
                case SDL.EventType.GamepadButtonDown:
                {
                    var index = SDL.GetGamepadPlayerIndexForID(e.gamepadDevice.gamepadID);
                    {
                        if (Gamepads.TryGetValue(index, out var gamepad))
                        {
                            var button = Mapping.GetGamepadButtonFromSDL(e.gamepadButton.button);
                            {
                                if (button != Button.Unknown)
                                {
                                    if (gamepad.Buttons.ContainsKey(button))
                                    {
                                        gamepad.Buttons[button] = State.Down | State.Press;
                                    }
                                }
                            }
                        }
                    }

                    break;
                }
                
                // Gamepad Axis
                case SDL.EventType.GamepadAxisMotion:
                {
                    var index = SDL.GetGamepadPlayerIndexForID(e.gamepadDevice.gamepadID);
                    {
                        if (Gamepads.TryGetValue(index, out var gamepad))
                        {
                            var axis = Mapping.GetGamepadAxisFromSDL(e.gamepadAxis.axis);
                            {
                                if (axis != Axis.Unknown)
                                {
                                    if (gamepad.Axes.ContainsKey(axis))
                                    {
                                        float raw = e.gamepadAxis.value;
                                        float value = raw >= 0 ? raw / 32767.0f : raw / 32768.0f;

                                        if (axis == Axis.LeftY || axis == Axis.RightY) value *= -1;
                                        if (Maths.Abs(value) < gamepad.DeadZone) value = 0f;

                                        gamepad.Axes[axis] = value;
                                    }
                                }
                            }
                        }
                    }

                    break;
                }

                // Gamepad Connected
                case SDL.EventType.GamepadDeviceAdded:
                {
                    Connect(e.gamepadDevice.gamepadID);
                    break;
                }

                // Gamepad Disconnected
                case SDL.EventType.GamepadDeviceRemoved:
                {
                    Disconnect(e.gamepadDevice.gamepadID);
                    break;
                }
            }
        }

        private void Connect(uint device)
        {
            var index = SDL.GetGamepadPlayerIndexForID(device);
            {
                if (!Gamepads.ContainsKey(index))
                {
                    Gamepads[index] = new GamepadHandle(device, index);
                }
            }
        }

        private void Disconnect(uint device)
        {
            foreach(var gamepad in Gamepads.Values)
            {
                if (gamepad.Device == device)
                {
                    Gamepads.Remove(gamepad.Index);

                    if (gamepad.Handle != null)
                    {
                        SDL.CloseGamepad(gamepad.Handle);
                        gamepad.Handle = null;
                    }
                }
            }
        }
    }

    // Gamepads API
    public partial class Gamepad
    {
        // Rumble gamepad for ms
        public static void Rumble(int index, float strength, float ms)
        {
            if (Gamepads.TryGetValue(index, out var gamepad))
            {
                gamepad.Rumble(strength, ms);
            }
        }
        
        // Get gamepad button pressed
        public static bool GetButton(int index, Button button)
        {
            if (Gamepads.TryGetValue(index, out var gamepad))
            {
                return gamepad.GetButton(button);
            }

            return false;
        }
        
        // Get gamepad button released
        public static bool GetButtonUp(int index, Button button)
        {
            if (Gamepads.TryGetValue(index, out var gamepad))
            {
                return gamepad.GetButtonUp(button);
            }

            return false;
        }
        
        // Get gamepad button down (single frame)
        public static bool GetButtonDown(int index, Button button)
        {
            if (Gamepads.TryGetValue(index, out var gamepad))
            {
                return gamepad.GetButtonDown(button);
            }

            return false;
        }
        
        // Get gamepad axis
        public static float GetAxis(int index, Axis axis)
        {
            if (Gamepads.TryGetValue(index, out var gamepad))
            {
                return gamepad.GetAxis(axis);
            }

            return 0;
        }
        
        // Set gamepad dead zone
        public static void SetDeadZone(int index, float deadZone)
        {
            if (Gamepads.TryGetValue(index, out var gamepad))
            {
                gamepad.SetDeadZone(deadZone);
            }
        }

        // Get gamepad dead zone
        public static float GetDeadZone(int index)
        {
            if (Gamepads.TryGetValue(index, out var gamepad))
            {
                return gamepad.GetDeadZone();
            }

            return 0;
        }
    }
}