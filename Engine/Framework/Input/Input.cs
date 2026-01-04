using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Input : Module<Input>
    {
        private static readonly InputActions InputActions = new InputActions();
        
        private static readonly TouchScreenKeyboard TouchScreenKeyboard = new TouchScreenKeyboard();
        private static readonly TouchScreens TouchScreens = new TouchScreens();
        private static readonly Keyboards Keyboards = new Keyboards();
        private static readonly Gamepads Gamepads = new Gamepads();
        private static readonly Mouses Mouses = new Mouses();

        private Input() { }

        
        // Start Of Frame
        internal override void OnStartOfFrame()
        {
            TouchScreenKeyboard.OnReset();
            TouchScreens.OnReset();
            Keyboards.OnReset();
            Gamepads.OnReset();
            Mouses.OnReset();
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            TouchScreenKeyboard.OnEvent(e);
            TouchScreens.OnEvent(e);
            Keyboards.OnEvent(e);
            Gamepads.OnEvent(e);
            Mouses.OnEvent(e);
        }

        // Dispose
        internal override void OnDispose()
        {
            TouchScreenKeyboard.OnDispose();
            TouchScreens.OnDispose();
            Keyboards.OnDispose();
            Gamepads.OnDispose();
            Mouses.OnDispose();
        }
    }
    
    // Actions
    public partial class Input
    {
        public static T GetAction<T>(string name) where T : InputAction
        {
            return InputActions.GetAction<T>(name);
        }
        
        public static T CreateAction<T>(string name) where T : InputAction
        {
            return InputActions.CreateAction<T>(name);
        }
        
        public static void DestroyAction<T>(string name) where T : InputAction
        {
            InputActions.DestroyAction<T>(name);
        }
        
        public static bool GetButton(string name)
        {
            var button = InputActions.GetAction<InputButton>(name);

            if (button != null)
            {
                if (button.GetButton())
                {
                    return true;
                }
            }

            return false;
        }
        
        public static bool GetButtonUp(string name)
        {
            var button = InputActions.GetAction<InputButton>(name);

            if (button != null)
            {
                if (button.GetButtonUp())
                {
                    return true;
                }
            }

            return false;
        }
        
        public static bool GetButtonDown(string name)
        {
            var button = InputActions.GetAction<InputButton>(name);

            if (button != null)
            {
                if (button.GetButtonDown())
                {
                    return true;
                }
            }

            return false;
        }

        public static float GetAxis(string name)
        {
            var axis = InputActions.GetAction<InputAxis>(name);
            
            if (axis != null)
            {
                var value = axis.Value();

                if (value != 0)
                {
                    return value;
                }
            }

            return 0;
        }
        
        public static Vector2 GetVector(string name)
        {
            var vector = InputActions.GetAction<InputVector>(name);
            
            if (vector != null)
            {
                var value = vector.Value();

                if (value.X != 0 || value.Y != 0)
                {
                    return value;
                }
            }

            return Vector2.Zero;
        }
    }

    // Keyboard
    public partial class Input
    {
        public static float GetKeyboardAxis(KeyboardAxis axis, Player player = Player.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == Player.Any)
                {
                    var value = keyboard.GetAxis(axis);

                    if (value != 0)
                    {
                        return value;
                    }
                }
            }
            
            return 0;
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
        public static Vector2 GetMousePositionDelta(Player player = Player.Any)
        {
            foreach (var mouse in Mouses.AllMouses)
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
            foreach (var mouse in Mouses.AllMouses)
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
            foreach (var mouse in Mouses.AllMouses)
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
        
        public static float GetMouseAxis(MouseAxis axis, Player player = Player.Any)
        {
            foreach (var mouse in Mouses.AllMouses)
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
        
        public static bool GetMouseButton(MouseButton button, Player player = Player.Any)
        {
            foreach (var mouse in Mouses.AllMouses)
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
            foreach (var mouse in Mouses.AllMouses)
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
            foreach (var mouse in Mouses.AllMouses)
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
                    var value = touchscreen.GetTouchCount();
                    
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