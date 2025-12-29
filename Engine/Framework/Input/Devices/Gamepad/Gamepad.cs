using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Gamepad : InputDevice
    {
        internal Dictionary<Button, InputKey> Keys { get; private set; } = new Dictionary<Button, InputKey>();
        internal Dictionary<Axis, InputAxis> Axis { get; private set; } = new Dictionary<Axis, InputAxis>();
        internal SDL.Gamepad* Handle { get; private set; }
        internal float DeadZone { get; private set; }
        internal uint DeviceID { get; private set; }
        internal int PlayerID { get; private set; }
        
        
        internal Gamepad(SDL.Gamepad* handle, uint deviceID, int playerID)
        {
            this.DeviceID = deviceID;
            this.PlayerID = playerID;
            this.Handle = handle;
            
            foreach (Button key in Enum.GetValues(typeof(Button)))
            {
                Keys.Add(key, new InputKey());
            }
            
            foreach (Axis axis in Enum.GetValues(typeof(Axis)))
            {
                Axis.Add(axis, new InputAxis());
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
            
            Keys.Clear();
            Axis.Clear();
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var axis in Axis.Values)
            {
                axis.Reset();
            }
            
            foreach (var key in Keys.Values)
            {
                key.Reset();
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
                    var key = (Button)e.gamepadButton.button;

                    if (Keys.TryGetValue(key, out var inputKey))
                    {
                        inputKey.SetState(State.Release);
                    }
                    
                    break;
                }
                
                // Gamepad Down
                case SDL.EventType.GamepadButtonDown:
                {
                    var key = (Button)e.gamepadButton.button;
            
                    if (Keys.TryGetValue(key, out var inputKey))
                    {
                        inputKey.SetState(State.Press | State.Down);
                    }
                    
                    break;
                }
                
                // Gamepad Axis
                case SDL.EventType.GamepadAxisMotion:
                {
                    var axis = (Axis)e.gamepadAxis.axis;
            
                    if (Axis.TryGetValue(axis, out var inputAxis))
                    {
                        float raw = e.gamepadAxis.value;
                        float value = raw >= 0 ? raw / 32767.0f : raw / 32768.0f;

                        if (Maths.Abs(value) >= DeadZone)
                        {
                            inputAxis.SetState(value);
                        }
                    }
                    
                    break;
                }
            }
        }

        internal float GetGamepadDeadZone()
        {
            return DeadZone;
        }

        internal void SetGamepadDeadZone(float value)
        {
            DeadZone = Maths.Clamp(value, 0, 1);
        }

        internal float GetGamepadAxis(Axis axis)
        {
            if (Axis.TryGetValue(axis, out var inputAxis))
            {
                return inputAxis.GetState();
            }

            return 0;
        }
        
        internal bool GetGamepadButton(Button button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.IsPressed();
            }

            return false;
        }
        
        internal bool GetGamepadButtonDown(Button button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.IsDown();
            }

            return false;
        }
        
        internal bool GetGamepadButtonUp(Button button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.IsReleased();
            }

            return false;
        }
    }
}