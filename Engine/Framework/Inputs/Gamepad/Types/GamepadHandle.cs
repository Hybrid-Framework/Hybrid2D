using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class GamepadHandle
    {
        internal Dictionary<GamepadButton, State> Buttons = new Dictionary<GamepadButton, State>();
        internal Dictionary<GamepadAxis, float> Axes = new Dictionary<GamepadAxis, float>();
        internal float DeadZone = 0.2f;
        internal SDL.Gamepad* Handle;
        internal uint Device;
        internal int Index;
        
        
        // Constructor
        internal GamepadHandle(uint device, int index)
        {
            Handle = SDL.OpenGamepad(device);
            {
                Index = index;
                Device = device;
                
                foreach (GamepadButton button in Enum.GetValues(typeof(GamepadButton)))
                {
                    Buttons.Add(button, State.None);
                }
            
                foreach (GamepadAxis axis in Enum.GetValues(typeof(GamepadAxis)))
                {
                    Axes.Add(axis, 0);
                }
            }
        }

        // Reset
        internal void Reset()
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
        
        internal void Rumble(float strength, float ms)
        {
            SDL.RumbleGamepad(Handle, (ushort)strength, (ushort)strength, (uint)ms);
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
        
        internal void SetDeadZone(float deadZone)
        {
            DeadZone = deadZone;
        }

        internal float GetDeadZone()
        {
            return DeadZone;
        }
    }
}