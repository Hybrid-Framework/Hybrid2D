using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    internal class Keyboard : InputDevice
    {
        private readonly Dictionary<KeyboardButton, State> Buttons = new Dictionary<KeyboardButton, State>();
        private readonly Dictionary<KeyboardAxis, float> Axes = new Dictionary<KeyboardAxis, float>();
        
        
        // Constructor
        internal Keyboard(ulong device, Player player)
        {
            this.Device = device;
            this.Player = player;
            
            foreach (KeyboardButton key in Enum.GetValues(typeof(KeyboardButton)))
            {
                Buttons.Add(key, State.None);
            }
            
            foreach (KeyboardAxis axis in Enum.GetValues(typeof(KeyboardAxis)))
            {
                Axes.Add(axis, 0);
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var key in Buttons.Keys)
            {
                if (GetButtonDown(key))
                {
                    Buttons[key] = State.Press;
                }

                if (GetButtonUp(key))
                {
                    Buttons[key] = State.None;
                }
            }
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Keyboard Up
                case SDL.EventType.KeyboardButtonUp:
                {
                    var button = InputMapping.GetKeyboardButtonFromSDLKeyCode(e.keyboard.keyCode);
                    {
                        if (button != KeyboardButton.Unknown)
                        {
                            if (Buttons.ContainsKey(button))
                            {
                                Buttons[button] = State.Release;
                            }
                        }
                        
                        switch (button)
                        {
                            case KeyboardButton.RightArrow: Axes[KeyboardAxis.ArrowX] -= 1; break;
                            case KeyboardButton.LeftArrow: Axes[KeyboardAxis.ArrowX] += 1; break;
                            case KeyboardButton.DownArrow: Axes[KeyboardAxis.ArrowY] += 1; break;
                            case KeyboardButton.UpArrow: Axes[KeyboardAxis.ArrowY] -= 1; break;
                            case KeyboardButton.D: Axes[KeyboardAxis.KeyboardX] -= 1; break;
                            case KeyboardButton.A: Axes[KeyboardAxis.KeyboardX] += 1; break;
                            case KeyboardButton.S: Axes[KeyboardAxis.KeyboardY] += 1; break;
                            case KeyboardButton.W: Axes[KeyboardAxis.KeyboardY] -= 1; break;
                        }
                    }
                    
                    break;
                }
                
                // Keyboard Down
                case SDL.EventType.KeyboardButtonDown:
                {
                    var button = InputMapping.GetKeyboardButtonFromSDLKeyCode(e.keyboard.keyCode);
                    {
                        if (button != KeyboardButton.Unknown)
                        {
                            if (Buttons.ContainsKey(button))
                            {
                                Buttons[button] = State.Down | State.Press;
                            }
                        }
                        
                        switch (button)
                        {
                            case KeyboardButton.RightArrow: Axes[KeyboardAxis.ArrowX] += 1; break;
                            case KeyboardButton.LeftArrow: Axes[KeyboardAxis.ArrowX] -= 1; break;
                            case KeyboardButton.DownArrow: Axes[KeyboardAxis.ArrowY] -= 1; break;
                            case KeyboardButton.UpArrow: Axes[KeyboardAxis.ArrowY] += 1; break;
                            case KeyboardButton.D: Axes[KeyboardAxis.KeyboardX] += 1; break;
                            case KeyboardButton.A: Axes[KeyboardAxis.KeyboardX] -= 1; break;
                            case KeyboardButton.S: Axes[KeyboardAxis.KeyboardY] -= 1; break;
                            case KeyboardButton.W: Axes[KeyboardAxis.KeyboardY] += 1; break;
                        }
                    }
                    
                    break;
                }
            }
        }
        
        internal float GetAxis(KeyboardAxis axis)
        {
            return Axes.GetValueOrDefault(axis);
        }
        
        internal bool GetButton(KeyboardButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Press) != 0;
            }

            return false;
        }
        
        internal bool GetButtonUp(KeyboardButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Release) != 0;
            }

            return false;
        }
        
        internal bool GetButtonDown(KeyboardButton button)
        {
            if (Buttons.TryGetValue(button, out var state))
            {
                return (state & State.Down) != 0;
            }

            return false;
        }

        internal KeyboardModifier GetModifier()
        {
            return (KeyboardModifier)SDL.GetModState();
        }
        
        internal KeyboardButton[] GetDeviceButtons()
        {
            return Buttons.Keys.ToArray();
        }

        internal KeyboardAxis[] GetDeviceAxes()
        {
            return Axes.Keys.ToArray();
        }
    }
}