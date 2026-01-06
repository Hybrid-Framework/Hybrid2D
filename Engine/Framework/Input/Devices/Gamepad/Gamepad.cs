﻿using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    internal unsafe class Gamepad : InputDevice
    {
        private readonly Dictionary<GamepadButton, State> Buttons = new Dictionary<GamepadButton, State>();
        private readonly Dictionary<GamepadAxis, float> Axes = new Dictionary<GamepadAxis, float>();
        private readonly float DeadZone = 0.2f;
        private SDL.Gamepad* Handle;

        internal uint Device;
        internal int Index;
        
        
        // Constructor
        internal Gamepad(SDL.Gamepad* handle, uint device, int index)
        {
            this.Handle = handle;
            this.Device = device;
            this.Index = index;
            
            foreach (GamepadButton button in Enum.GetValues(typeof(GamepadButton)))
            {
                Buttons.Add(button, State.None);
            }
            
            foreach (GamepadAxis axis in Enum.GetValues(typeof(GamepadAxis)))
            {
                Axes.Add(axis, 0);
            }
        }
        
        // Dispose
        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL.CloseGamepad(Handle);
                Handle = null;
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var button in Buttons.Keys)
            {
                if (GetButtonDown(button))
                {
                    Buttons[button] = State.Press;
                }

                if (GetButtonUp(button))
                {
                    Buttons[button] = State.None;
                }
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
                    var button = InputMapping.GetGamepadButtonFromSDL(e.gamepadButton.button);
                    {
                        if (button != GamepadButton.Unknown)
                        {
                            if (Buttons.ContainsKey(button))
                            {
                                Buttons[button] = State.Release;
                            }
                        }
                        
                        switch (button)
                        {
                            case GamepadButton.DpadRight: Axes[GamepadAxis.DpadX] -= 1; break;
                            case GamepadButton.DpadLeft: Axes[GamepadAxis.DpadX] += 1; break;
                            case GamepadButton.DpadDown: Axes[GamepadAxis.DpadY] += 1; break;
                            case GamepadButton.DpadUp: Axes[GamepadAxis.DpadY] -= 1; break;
                        }
                    }
                    
                    break;
                }
                
                // Gamepad Down
                case SDL.EventType.GamepadButtonDown:
                {
                    var button = InputMapping.GetGamepadButtonFromSDL(e.gamepadButton.button);
                    {
                        if (button != GamepadButton.Unknown)
                        {
                            if (Buttons.ContainsKey(button))
                            {
                                Buttons[button] = State.Down | State.Press;
                            }
                        }
                        
                        switch (button)
                        {
                            case GamepadButton.DpadRight: Axes[GamepadAxis.DpadX] += 1; break;
                            case GamepadButton.DpadLeft: Axes[GamepadAxis.DpadX] -= 1; break;
                            case GamepadButton.DpadDown: Axes[GamepadAxis.DpadY] -= 1; break;
                            case GamepadButton.DpadUp: Axes[GamepadAxis.DpadY] += 1; break;
                        }
                    }
                    
                    break;
                }
                
                // Gamepad Axis
                case SDL.EventType.GamepadAxisMotion:
                {
                    var axis = InputMapping.GetGamepadAxisFromSDL(e.gamepadAxis.axis);
                    {
                        if (axis != GamepadAxis.Unknown)
                        {
                            if (Axes.ContainsKey(axis))
                            {
                                float raw = e.gamepadAxis.value;
                                float value = raw >= 0 ? raw / 32767.0f : raw / 32768.0f;

                                if (axis == GamepadAxis.LeftY || axis == GamepadAxis.RightY) value *= -1;
                                if (Maths.Abs(value) < DeadZone) value = 0f;
                        
                                Axes[axis] = value;
                            }
                        }
                    }
                    
                    break;
                }
            }
        }

        internal bool GetButton(GamepadButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Press) != 0;
            }

            return false;
        }
        
        internal bool GetButtonUp(GamepadButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Release) != 0;
            }

            return false;
        }
        
        internal bool GetButtonDown(GamepadButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }
        
        internal float GetAxis(GamepadAxis axis)
        {
            return Axes.GetValueOrDefault(axis);
        }
    }
}