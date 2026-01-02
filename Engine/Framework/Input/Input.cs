using System;
using System.Collections.Generic;

namespace Hybrid
{
    // Internal
    public sealed partial class Input : Module<Input>
    {
        internal static Dictionary<string, InputAction> Actions { get; private set; } = new Dictionary<string, InputAction>();
        internal static Dictionary<string, InputVector> Vectors { get; private set; } = new Dictionary<string, InputVector>();
        internal static Dictionary<string, InputAxis> Axes { get; private set; } = new Dictionary<string, InputAxis>();
        
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
    
    // Actions
    public partial class Input
    {
        public static InputAction CreateAction(string name)
        {
            if (!Actions.TryGetValue(name, out InputAction action))
            {
                action = new InputAction(name);
                Actions[name] = action;
            }

            return action;
        }

        public static void DestroyAction(string name)
        {
            Actions.Remove(name);
        }
        
        public static bool GetButton(string name)
        {
            if (Actions.TryGetValue(name, out InputAction action))
            {
                if (action.GetKey())
                {
                    return true;
                }
            }

            return false;
        }

        public static bool GetButtonDown(string name)
        {
            if (Actions.TryGetValue(name, out InputAction action))
            {
                if (action.GetKeyDown())
                {
                    return true;
                }
            }

            return false;
        }
        
        public static bool GetButtonUp(string name)
        {
            if (Actions.TryGetValue(name, out InputAction action))
            {
                if (action.GetKeyUp())
                {
                    return true;
                }
            }

            return false;
        }
    }
    
    // Axis
    public partial class Input
    {
        public static InputAxis CreateAxis(string name)
        {
            if (!Axes.TryGetValue(name, out InputAxis axis))
            {
                axis = new InputAxis(name);
                Axes[name] = axis;
            }

            return axis;
        }

        public static void DestroyAxis(string name)
        {
            Axes.Remove(name);
        }
        
        public static float GetAxis(string name)
        {
            if (Axes.TryGetValue(name, out InputAxis axis))
            {
                var value = axis.Value();

                if (value != 0)
                {
                    return value;
                }
            }

            return 0;
        }
    }
    
    // Vector
    public partial class Input
    {
        public static InputVector CreateVector(string name)
        {
            if (!Vectors.TryGetValue(name, out InputVector vector))
            {
                vector = new InputVector(name);
                Vectors[name] = vector;
            }

            return vector;
        }

        public static void DestroyVector(string name)
        {
            Vectors.Remove(name);
        }
        
        public static Vector2 GetVector(string name)
        {
            if (Vectors.TryGetValue(name, out InputVector vector))
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
        public static bool GetKeyModifier(KeyModifier keyModifier, Player player = Player.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == Player.Any)
                {
                    if (keyboard.GetKeyModifier(keyModifier))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetKey(Key key, Player player = Player.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == Player.Any)
                {
                    if (keyboard.GetKey(key))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetKeyDown(Key key, Player player = Player.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == Player.Any)
                {
                    if (keyboard.GetKeyDown(key))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static bool GetKeyUp(Key key, Player player = Player.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == Player.Any)
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
                    if (mouse.GetKey(button))
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
                    if (mouse.GetKeyDown(button))
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
                    if (mouse.GetKeyUp(button))
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
                    if (gamepad.GetKey(button))
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
                    if (gamepad.GetKeyDown(button))
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
                    if (gamepad.GetKeyUp(button))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static void SetGamepadRumble(ushort low, ushort high, uint ms, Player player = Player.Any)
        {
            foreach (var gamepad in Gamepads.AllGamepads)
            {
                if (gamepad.Player == player || player == Player.Any)
                {
                    gamepad.Rumble(low, high, ms);
                }
            }
        }
    }
    
    // Touch
    public partial class Input
    {
        public static int TouchCount(Player player = Player.Any)
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
    }
}