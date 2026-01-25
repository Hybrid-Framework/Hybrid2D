using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class GamepadHandle
    {
        internal Dictionary<Button, State> Buttons = new Dictionary<Button, State>();
        internal Dictionary<Axis, float> Axes = new Dictionary<Axis, float>();
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
                
                foreach (Button button in Enum.GetValues(typeof(Button)))
                {
                    Buttons.Add(button, State.None);
                }
            
                foreach (Axis axis in Enum.GetValues(typeof(Axis)))
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

        internal bool GetButton(Button button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Press) != 0;
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
        
        internal bool GetButtonDown(Button button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }
        
        internal float GetAxis(Axis axis)
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