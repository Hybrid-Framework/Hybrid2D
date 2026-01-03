using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Gamepad : InputDevice
    {
        internal readonly Dictionary<GamepadButton, State> Buttons = new Dictionary<GamepadButton, State>();
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
                Buttons.Add(button, State.None);
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
                    var button = (GamepadButton)e.gamepadButton.button;
                    {
                        if (Buttons.ContainsKey(button))
                        {
                            Buttons[button] = State.Release;
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
                            Buttons[button] = State.Down | State.Press;
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

                        if (axis == GamepadAxis.LeftY || axis == GamepadAxis.RightY) value *= -1;
                        if (Maths.Abs(value) < DeadZone) value = 0f;
                        
                        Axis[axis] = value;
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
            return Axis.GetValueOrDefault(axis);
        }
    }
}