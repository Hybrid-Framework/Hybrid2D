using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Input : Module
    {
        internal Input() { }
        
        internal static readonly TouchScreen TouchScreen = new TouchScreen();
        internal static readonly Gamepads Gamepads = new Gamepads();
        internal static readonly Keyboard Keyboard = new Keyboard();
        internal static readonly Mouse Mouse = new Mouse();

        
        // Start Of Frame
        internal override void OnStartOfFrame()
        {
            TouchScreen.OnReset();
            Keyboard.OnReset();
            Gamepads.OnReset();
            Mouse.OnReset();
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            TouchScreen.OnEvent(e);
            Keyboard.OnEvent(e);
            Gamepads.OnEvent(e);
            Mouse.OnEvent(e);
        }

        // Dispose
        internal override void OnDispose()
        {
            TouchScreen.OnDispose();
            Keyboard.OnDispose();
            Gamepads.OnDispose();
            Mouse.OnDispose();
        }
    }

    // Keyboard
    public partial class Input
    {
        public static bool GetKeyboardButton(KeyboardButton button)
        {
            return Keyboard.GetButton(button);
        }
        
        public static bool GetKeyboardButtonUp(KeyboardButton button)
        {
            return Keyboard.GetButtonUp(button);
        }
        
        public static bool GetKeyboardButtonDown(KeyboardButton button)
        {
            return Keyboard.GetButtonDown(button);
        }
    }
    
    // Mouse
    public partial class Input
    {
        public static Vector2 GetMousePosition()
        {
            return Mouse.GetPositon();
        }
        
        public static Vector2 GetMouseScrollDelta()
        {
            return Mouse.GetScrollDelta();
        }
        
        public static Vector2 GetMousePositionDelta()
        {
            return Mouse.GetPositonDelta();
        }
        
        public static bool GetMouseButton(MouseButton button)
        {
            return Mouse.GetButton(button);
        }
        
        public static bool GetMouseButtonUp(MouseButton button)
        {
            return Mouse.GetButtonUp(button);
        }
        
        public static bool GetMouseButtonDown(MouseButton button)
        {
            return Mouse.GetButtonDown(button);
        }
    }
    
    // Gamepad
    public partial class Input
    {
        public static float GetGamepadAxis(GamepadAxis axis, int index)
        {
            foreach (var gamepad in Gamepads.AllDevices)
            {
                if (gamepad.Index == index)
                {
                    var value = gamepad.GetAxis(axis);

                    if (value != 0)
                    {
                        return value;
                    }
                }
            }
            
            return 0;
        }
        
        public static bool GetGamepadButton(GamepadButton button, int index)
        {
            foreach (var gamepad in Gamepads.AllDevices)
            {
                if (gamepad.Index == index)
                {
                    if (gamepad.GetButton(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetGamepadButtonUp(GamepadButton button, int index)
        {
            foreach (var gamepad in Gamepads.AllDevices)
            {
                if (gamepad.Index == index)
                {
                    if (gamepad.GetButtonUp(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetGamepadButtonDown(GamepadButton button, int index)
        {
            foreach (var gamepad in Gamepads.AllDevices)
            {
                if (gamepad.Index == index)
                {
                    if (gamepad.GetButtonDown(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
    
    // Touch
    public partial class Input
    {
        public static Touch GetTouch(int finger)
        {
            return TouchScreen.GetTouch(finger);
        }
        
        public static int GetTouchCount()
        {
            return TouchScreen.GetTouchCount();
        }
    }
}