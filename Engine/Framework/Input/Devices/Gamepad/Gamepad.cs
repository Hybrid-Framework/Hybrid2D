using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Gamepad : InputDevice
    {
        internal Dictionary<Button, InputKey> Keys { get; private set; } = new Dictionary<Button, InputKey>();
        internal Dictionary<Axis, InputAxis> Axis { get; private set; } = new Dictionary<Axis, InputAxis>();
        internal InputAxis DeadZone { get; private set; } = new InputAxis();
        
        internal SDL.Gamepad* Handle { get; private set; }
        internal InputPlayer Player { get; private set; }
        internal uint Device { get; private set; }
        
        
        internal Gamepad(SDL.Gamepad* handle, uint device, InputPlayer player)
        {
            this.Device = device;
            this.Player = player;
            this.Handle = handle;
            
            foreach (Button key in Enum.GetValues(typeof(Button)))
            {
                Keys.Add(key, new InputKey());
            }
            
            foreach (Axis axis in Enum.GetValues(typeof(Axis)))
            {
                Axis.Add(axis, new InputAxis());
            }
            
            DeadZone.SetState(0.2f);
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
                        inputKey.SetState(State.Down | State.Hold);
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

                        if (Maths.Abs(value) >= DeadZone.GetState())
                        {
                            inputAxis.SetState(value);
                        }
                    }
                    
                    break;
                }
            }
        }

        internal float GetAxis(Axis axis)
        {
            if (Axis.TryGetValue(axis, out var inputAxis))
            {
                return inputAxis.GetState();
            }

            return 0;
        }
        
        internal bool GetButton(Button button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.Held();
            }

            return false;
        }
        
        internal bool GetButtonDown(Button button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.Down();
            }

            return false;
        }
        
        internal bool GetButtonUp(Button button)
        {
            if (Keys.TryGetValue(button, out var inputKey))
            {
                return inputKey.Released();
            }

            return false;
        }
    }
}