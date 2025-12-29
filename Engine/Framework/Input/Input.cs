using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Input : Module<Input>
    {
        private Input() { }

        internal static Touchscreens Touchscreens { get; private set; } = new Touchscreens();
        internal static Keyboards Keyboards { get; private set; } = new Keyboards();
        internal static Gamepads Gamepads { get; private set; } = new Gamepads();
        internal static Mouses Mouses { get; private set; } = new Mouses();


        internal override void OnStartOfFrame()
        {
            Touchscreens.OnReset();
            Keyboards.OnReset();
            Gamepads.OnReset();
            Mouses.OnReset();
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            Touchscreens.OnEvent(e);
            Keyboards.OnEvent(e);
            Gamepads.OnEvent(e);
            Mouses.OnEvent(e);
        }

        // Dispose
        internal override void OnDispose()
        {
            Touchscreens.OnDispose();
            Keyboards.OnDispose();
            Gamepads.OnDispose();
            Mouses.OnDispose();
        }
    }

    // Keyboard
    public partial class Input
    {
        public static Modifier GetKeyModifiers(InputPlayer player = InputPlayer.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == InputPlayer.Any)
                {
                    return keyboard.GetKeyModifiers();
                }
            }
            
            return Modifier.None;
        }
        
        public static bool GetKey(Key key, InputPlayer player = InputPlayer.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == InputPlayer.Any)
                {
                    if (keyboard.GetKey(key))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetKeyDown(Key key, InputPlayer player = InputPlayer.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == InputPlayer.Any)
                {
                    if (keyboard.GetKeyDown(key))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetKeyUp(Key key, InputPlayer player = InputPlayer.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == InputPlayer.Any)
                {
                    if (keyboard.GetKeyUp(key))
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
        public static Vector2 MouseScrollDelta(InputPlayer player = InputPlayer.Any)
        {
            foreach (var mouse in Mouses.AllMice)
            {
                if (mouse.Player == player || player == InputPlayer.Any)
                {
                    return mouse.ScrollDelta.GetState();
                }
            }
            
            return Vector2.Zero;
        }
        
        public static Vector2 MousePosition(InputPlayer player = InputPlayer.Any)
        {
            foreach (var mouse in Mouses.AllMice)
            {
                if (mouse.Player == player || player == InputPlayer.Any)
                {
                    return mouse.Position.GetState();
                }
            }
            
            return Vector2.Zero;
        }
        
        public static Vector2 MouseDelta(InputPlayer player = InputPlayer.Any)
        {
            foreach (var mouse in Mouses.AllMice)
            {
                if (mouse.Player == player || player == InputPlayer.Any)
                {
                    return mouse.Delta.GetState();
                }
            }
            
            return Vector2.Zero;
        }
        
        public static bool GetMouseButton(int button, InputPlayer player = InputPlayer.Any)
        {
            foreach (var mouse in Mouses.AllMice)
            {
                if (mouse.Player == player || player == InputPlayer.Any)
                {
                    if (mouse.GetMouseButton(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetMouseButtonDown(int button, InputPlayer player = InputPlayer.Any)
        {
            foreach (var mouse in Mouses.AllMice)
            {
                if (mouse.Player == player || player == InputPlayer.Any)
                {
                    if (mouse.GetMouseButtonDown(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetMouseButtonUp(int button, InputPlayer player = InputPlayer.Any)
        {
            foreach (var mouse in Mouses.AllMice)
            {
                if (mouse.Player == player || player == InputPlayer.Any)
                {
                    if (mouse.GetMouseButtonUp(button))
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
        public static float GetGamepadAxis(Axis axis, InputPlayer player = InputPlayer.Any)
        {
            foreach (var gamepad in Gamepads.AllGamepads)
            {
                if (gamepad.Player == player || player == InputPlayer.Any)
                {
                    return gamepad.GetAxis(axis);
                }
            }
            
            return 0;
        }
        
        public static bool GetGamepadButton(Button button, InputPlayer player = InputPlayer.Any)
        {
            foreach (var gamepad in Gamepads.AllGamepads)
            {
                if (gamepad.Player == player || player == InputPlayer.Any)
                {
                    if (gamepad.GetButton(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetGamepadButtonDown(Button button, InputPlayer player = InputPlayer.Any)
        {
            foreach (var gamepad in Gamepads.AllGamepads)
            {
                if (gamepad.Player == player || player == InputPlayer.Any)
                {
                    if (gamepad.GetButtonDown(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetGamepadButtonUp(Button button, InputPlayer player = InputPlayer.Any)
        {
            foreach (var gamepad in Gamepads.AllGamepads)
            {
                if (gamepad.Player == player || player == InputPlayer.Any)
                {
                    if (gamepad.GetButtonUp(button))
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
        public static Touch GetTouch(int finger, InputPlayer player = InputPlayer.Any)
        {
            foreach (var touchscreen in Touchscreens.AllTouchscreens)
            {
                if (touchscreen.Player == player || player == InputPlayer.Any)
                {
                    return touchscreen.GetTouch(finger);
                }
            }

            return null;
        }
    }
}