using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Gamepad : InputDevice
    {
        internal readonly Dictionary<Button, State> Buttons = new Dictionary<Button, State>();
        internal readonly Dictionary<Axis, float> Axis = new Dictionary<Axis, float>();
        internal float DeadZone = 0.2f;
        internal SDL.Gamepad* Handle;
        internal Player Player;
        internal uint Device;
        
        
        internal Gamepad(SDL.Gamepad* handle, uint device, Player player)
        {
            this.Device = device;
            this.Player = player;
            this.Handle = handle;
            
            foreach (Button button in Enum.GetValues(typeof(Button)))
            {
                Buttons.Add(button, State.None);
            }
            
            foreach (Axis axis in Enum.GetValues(typeof(Axis)))
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
                    Buttons[button] = State.Hold;
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
                    var button = (Button)e.gamepadButton.button;
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
                    var button = (Button)e.gamepadButton.button;
                    {
                        if (Buttons.ContainsKey(button))
                        {
                            Buttons[button] = State.Down | State.Hold;
                        }
                    }
                    
                    break;
                }
                
                // Gamepad Axis
                case SDL.EventType.GamepadAxisMotion:
                {
                    var axis = (Axis)e.gamepadAxis.axis;
            
                    if (Axis.ContainsKey(axis))
                    {
                        float raw = e.gamepadAxis.value;
                        float value = raw >= 0 ? raw / 32767.0f : raw / 32768.0f;

                        if (axis == Hybrid.Axis.LeftStickY || axis == Hybrid.Axis.RightStickY)
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

        internal bool GetButton(Button button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Hold) != 0;
            }

            return false;
        }
        
        internal bool GetButtonDown(Button button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }
        
        internal bool GetButtonUp(Button button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Release) != 0;
            }

            return false;
        }
        
        internal float GetAxis(Axis axis)
        {
            return Axis.GetValueOrDefault(axis);
        }
    }
}