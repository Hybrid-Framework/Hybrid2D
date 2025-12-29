using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Keyboards : InputDevice
    {
        internal readonly List<Keyboard> AllKeyboards = new List<Keyboard>();
        internal const int MaxKeyboards = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var keyboard in AllKeyboards.ToArray())
            {
                DestroyKeyboard(keyboard.Device);
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var keyboard in AllKeyboards)
            {
                keyboard.OnReset();
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
                    var keyboard = CreateKeyboard(e.keyboard.keyboardID);
                    {
                        keyboard?.OnEvent(e);
                    }
                    
                    break;
                }
                
                // Keyboard Down
                case SDL.EventType.KeyboardButtonDown:
                {
                    var keyboard = CreateKeyboard(e.keyboard.keyboardID);
                    {
                        keyboard?.OnEvent(e);
                    }
                    
                    break;
                }

                // Keyboard Disconnected
                case SDL.EventType.KeyboardDeviceRemoved:
                {
                    DestroyKeyboard(e.keyboardDevice.keyboardID);
                    break;
                }
            }
        }

        private Keyboard CreateKeyboard(uint device)
        {
            var found = GetKeyboardByDevice(device);
            
            if (found == null)
            {
                for (int i = 0; i < MaxKeyboards; i++)
                {
                    var player = (InputPlayer)i;
                    
                    if (GetKeyboardByPlayer(player) == null)
                    {
                        Debug.Log($"Keyboard {device} {player} connected");
                        
                        var keyboard = new Keyboard(device, player);
                        AllKeyboards.Add(keyboard);
                        return keyboard;
                    }
                }
            }
            
            return found;
        }

        private void DestroyKeyboard(uint device)
        {
            var keyboard = GetKeyboardByDevice(device);
            
            if (keyboard != null)
            {
                Debug.Log($"Keyboard {keyboard.Device} {keyboard.Player} disconnected");
                
                AllKeyboards.Remove(keyboard);
                keyboard.OnDispose();
            }
        }
        
        internal Keyboard GetKeyboardByPlayer(InputPlayer player)
        {
            foreach (var keyboard in AllKeyboards)
            {
                if (keyboard.Player == player)
                {
                    return keyboard;
                }
            }

            return null;
        }

        internal Keyboard GetKeyboardByDevice(uint device)
        {
            foreach (var keyboard in AllKeyboards)
            {
                if (keyboard.Device == device)
                {
                    return keyboard;
                }
            }

            return null;
        }
    }
}