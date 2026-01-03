using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Input : Module<Input>
    {
        internal static TouchScreenKeyboard TouchScreenKeyboard { get; private set; } = new TouchScreenKeyboard();
        internal static TouchScreens TouchScreens { get; private set; } = new TouchScreens();
        internal static Keyboards Keyboards { get; private set; } = new Keyboards();
        internal static Gamepads Gamepads { get; private set; } = new Gamepads();
        internal static Mice Mice { get; private set; } = new Mice();

        private Input() { }

        
        // Start Of Frame
        internal override void OnStartOfFrame()
        {
            TouchScreenKeyboard.OnReset();
            TouchScreens.OnReset();
            Keyboards.OnReset();
            Gamepads.OnReset();
            Mice.OnReset();
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            TouchScreenKeyboard.OnEvent(e);
            TouchScreens.OnEvent(e);
            Keyboards.OnEvent(e);
            Gamepads.OnEvent(e);
            Mice.OnEvent(e);
        }

        // Dispose
        internal override void OnDispose()
        {
            TouchScreenKeyboard.OnDispose();
            TouchScreens.OnDispose();
            Keyboards.OnDispose();
            Gamepads.OnDispose();
            Mice.OnDispose();
        }
    }

    // Keyboard
    public partial class Input
    {
        public static bool GetKeyboardModifier(KeyModifier keyModifier, Player player = Player.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == Player.Any)
                {
                    if (keyboard.GetModifier(keyModifier))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetKeyboardButton(KeyboardButton keyboardButton, Player player = Player.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == Player.Any)
                {
                    if (keyboard.GetButton(keyboardButton))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetKeyboardButtonUp(KeyboardButton keyboardButton, Player player = Player.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == Player.Any)
                {
                    if (keyboard.GetButtonUp(keyboardButton))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetKeyboardButtonDown(KeyboardButton keyboardButton, Player player = Player.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == Player.Any)
                {
                    if (keyboard.GetButtonDown(keyboardButton))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
    
    // Mouse
    public partial class Input
    {
        public static float GetMouseAxis(MouseAxis axis, Player player = Player.Any)
        {
            foreach (var mouse in Mice.AllMice)
            {
                if (mouse.Player == player || player == Player.Any)
                {
                    var value = mouse.GetAxis(axis);

                    if (value != 0)
                    {
                        return value;
                    }
                }
            }
            
            return 0;
        }
        
        public static Vector2 GetMousePositionDelta(Player player = Player.Any)
        {
            foreach (var mouse in Mice.AllMice)
            {
                if (mouse.Player == player || player == Player.Any)
                {
                    var value = mouse.GetPositonDelta();

                    if (value.X != 0 || value.Y != 0)
                    {
                        return value;
                    }
                }
            }
            
            return Vector2.Zero;
        }
        
        public static Vector2 GetMouseScrollDelta(Player player = Player.Any)
        {
            foreach (var mouse in Mice.AllMice)
            {
                if (mouse.Player == player || player == Player.Any)
                {
                    var value = mouse.GetScrollDelta();

                    if (value.X != 0 || value.Y != 0)
                    {
                        return value;
                    }
                }
            }
            
            return Vector2.Zero;
        }
        
        public static Vector2 GetMousePosition(Player player = Player.Any)
        {
            foreach (var mouse in Mice.AllMice)
            {
                if (mouse.Player == player || player == Player.Any)
                {
                    var value = mouse.GetPositon();

                    if (value.X != 0 || value.Y != 0)
                    {
                        return value;
                    }
                }
            }
            
            return Vector2.Zero;
        }
        
        public static bool GetMouseButton(MouseButton button, Player player = Player.Any)
        {
            foreach (var mouse in Mice.AllMice)
            {
                if (mouse.Player == player || player == Player.Any)
                {
                    if (mouse.GetButton(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetMouseButtonUp(MouseButton button, Player player = Player.Any)
        {
            foreach (var mouse in Mice.AllMice)
            {
                if (mouse.Player == player || player == Player.Any)
                {
                    if (mouse.GetButtonUp(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetMouseButtonDown(MouseButton button, Player player = Player.Any)
        {
            foreach (var mouse in Mice.AllMice)
            {
                if (mouse.Player == player || player == Player.Any)
                {
                    if (mouse.GetButtonDown(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
    
    // Gamepad
    public partial class Input
    {
        public static float GetGamepadAxis(GamepadAxis axis, Player player = Player.Any)
        {
            foreach (var gamepad in Gamepads.AllGamepads)
            {
                if (gamepad.Player == player || player == Player.Any)
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
        
        public static bool GetGamepadButton(GamepadButton button, Player player = Player.Any)
        {
            foreach (var gamepad in Gamepads.AllGamepads)
            {
                if (gamepad.Player == player || player == Player.Any)
                {
                    if (gamepad.GetButton(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetGamepadButtonUp(GamepadButton button, Player player = Player.Any)
        {
            foreach (var gamepad in Gamepads.AllGamepads)
            {
                if (gamepad.Player == player || player == Player.Any)
                {
                    if (gamepad.GetButtonUp(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetGamepadButtonDown(GamepadButton button, Player player = Player.Any)
        {
            foreach (var gamepad in Gamepads.AllGamepads)
            {
                if (gamepad.Player == player || player == Player.Any)
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
        public static Touch GetTouch(int finger, Player player = Player.Any)
        {
            foreach (var touchscreen in TouchScreens.AllTouchscreens)
            {
                if (touchscreen.Player == player || player == Player.Any)
                {
                    return touchscreen.GetTouch(finger);
                }
            }

            return null;
        }
        
        public static int GetTouchCount(Player player = Player.Any)
        {
            foreach (var touchscreen in TouchScreens.AllTouchscreens)
            {
                if (touchscreen.Player == player || player == Player.Any)
                {
                    var value = touchscreen.TouchCount();
                    
                    if (value > 0)
                    {
                        return value;
                    }
                }
            }

            return 0;
        }
    }
}