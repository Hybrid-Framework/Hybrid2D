using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal unsafe class Keyboards : InputDevice
    {
        internal readonly List<Keyboard> AllKeyboards = new List<Keyboard>();
        internal const int MaxKeyboards = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var keyboard in AllKeyboards)
            {
                keyboard.OnDispose();
            }
            
            AllKeyboards.Clear();
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

        private Keyboard CreateKeyboard(uint deviceID)
        {
            var found = GetKeyboardByDeviceID(deviceID);
            
            if (found == null)
            {
                for (int i = 0; i < MaxKeyboards; i++)
                {
                    if (GetKeyboardByPlayerID(i) == null)
                    {
                        Debug.Log($"Keyboard {deviceID} {i} added");
                        
                        var keyboard = new Keyboard(deviceID, i);
                        AllKeyboards.Add(keyboard);
                        return keyboard;
                    }
                }
            }
            
            return found;
        }

        private void DestroyKeyboard(uint deviceID)
        {
            var keyboard = GetKeyboardByDeviceID(deviceID);
            
            if (keyboard != null)
            {
                Debug.Log($"Keyboard {keyboard.DeviceID} {keyboard.PlayerID} removed");
                
                AllKeyboards.Remove(keyboard);
                keyboard.OnDispose();
            }
        }
        
        internal Keyboard GetKeyboardByPlayerID(int playerID)
        {
            foreach (var keyboard in AllKeyboards)
            {
                if (keyboard.PlayerID == playerID)
                {
                    return keyboard;
                }
            }

            return null;
        }

        internal Keyboard GetKeyboardByDeviceID(uint deviceID)
        {
            foreach (var keyboard in AllKeyboards)
            {
                if (keyboard.DeviceID == deviceID)
                {
                    return keyboard;
                }
            }

            return null;
        }
    }
}