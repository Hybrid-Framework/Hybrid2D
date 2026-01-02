using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Gamepad : InputDevice
    {
        internal readonly Dictionary<GamepadButton, KeyState> Buttons = new Dictionary<GamepadButton, KeyState>();
        internal readonly Dictionary<GamepadAxis, float> Axis = new Dictionary<GamepadAxis, float>();
        internal float DeadZone = 0.2f;
        internal SDL.Gamepad* Handle;
        internal Player Player;
        internal uint Device;
        
        
        internal Gamepad(SDL.Gamepad* handle, uint device, Player player)
        {
            this.Device = device;
            this.Player = player;
            this.Handle = handle;
            
            foreach (GamepadButton button in Enum.GetValues(typeof(GamepadButton)))
            {
                Buttons.Add(button, KeyState.None);
            }
            
            foreach (GamepadAxis axis in Enum.GetValues(typeof(GamepadAxis)))
            {
                Axis.Add(axis, 0);
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
            
            Buttons.Clear();
            Axis.Clear();
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var button in Buttons.Keys)
            {
                if (GetKeyDown(button))
                {
                    Buttons[button] = KeyState.Press;
                }

                if (GetKeyUp(button))
                {
                    Buttons[button] = KeyState.None;
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
                    var button = (GamepadButton)e.gamepadButton.button;
                    {
                        if (Buttons.ContainsKey(button))
                        {
                            Buttons[button] = KeyState.Release;
                        }
                    }
                    
                    break;
                }
                
                // Gamepad Down
                case SDL.EventType.GamepadButtonDown:
                {
                    var button = (GamepadButton)e.gamepadButton.button;
                    {
                        if (Buttons.ContainsKey(button))
                        {
                            Buttons[button] = KeyState.Down | KeyState.Press;
                        }
                    }
                    
                    break;
                }
                
                // Gamepad Axis
                case SDL.EventType.GamepadAxisMotion:
                {
                    var axis = (GamepadAxis)e.gamepadAxis.axis;
            
                    if (Axis.ContainsKey(axis))
                    {
                        float raw = e.gamepadAxis.value;
                        float value = raw >= 0 ? raw / 32767.0f : raw / 32768.0f;

                        if (axis == GamepadAxis.LeftStickY || axis == GamepadAxis.RightStickY)
                        {
                            value *= -1;
                        }

                        if (Maths.Abs(value) < DeadZone)
                        {
                            value = 0f;
                        }
                        
                        Axis[axis] = value;
                    }
                    
                    break;
                }
            }
        }
        
        internal void Rumble(ushort low, ushort high, uint ms)
        {
            if (Handle != null)
            {
                SDL.RumbleGamepad(Handle, low, high, ms);
            }
        }

        internal bool GetKey(GamepadButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & KeyState.Press) != 0;
            }

            return false;
        }
        
        internal bool GetKeyDown(GamepadButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & KeyState.Down) != 0;
            }

            return false;
        }
        
        internal bool GetKeyUp(GamepadButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & KeyState.Release) != 0;
            }

            return false;
        }
        
        internal float GetAxis(GamepadAxis axis)
        {
            return Axis.GetValueOrDefault(axis);
        }
    }
}