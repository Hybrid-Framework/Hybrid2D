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
                return action.GetKey();
            }

            return false;
        }

        public static bool GetButtonDown(string name)
        {
            if (Actions.TryGetValue(name, out InputAction action))
            {
                return action.GetKeyDown();
            }

            return false;
        }
        
        public static bool GetButtonUp(string name)
        {
            if (Actions.TryGetValue(name, out InputAction action))
            {
                return action.GetKeyUp();
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
                return axis.Value();
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
                return vector.Value();
            }

            return Vector2.Zero;
        }
    }

    // Keyboard
    public partial class Input
    {
        public static bool GetKeyModifier(Modifier modifier, Player player = Player.Any)
        {
            foreach (var keyboard in Keyboards.AllKeyboards)
            {
                if (keyboard.Player == player || player == Player.Any)
                {
                    if (keyboard.GetKeyModifier(modifier))
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
        public static Vector2 GetMousePositionDelta(Player player = Player.Any)
        {
            foreach (var mouse in Mice.AllMice)
            {
                if (mouse.Player == player || player == Player.Any)
                {
                    return mouse.GetPositonDelta();
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
                    return mouse.GetScrollDelta();
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
                    return mouse.GetPositon();
                }
            }
            
            return Vector2.Zero;
        }
        
        public static bool GetMouseButton(int button, Player player = Player.Any)
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
        
        public static bool GetMouseButtonDown(int button, Player player = Player.Any)
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
        
        public static bool GetMouseButtonUp(int button, Player player = Player.Any)
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
        public static float GetGamepadAxis(Axis axis, Player player = Player.Any)
        {
            foreach (var gamepad in Gamepads.AllGamepads)
            {
                if (gamepad.Player == player || player == Player.Any)
                {
                    return gamepad.GetAxis(axis);
                }
            }
            
            return 0;
        }
        
        public static bool GetGamepadButton(Button button, Player player = Player.Any)
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
        
        public static bool GetGamepadButtonDown(Button button, Player player = Player.Any)
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
        
        public static bool GetGamepadButtonUp(Button button, Player player = Player.Any)
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
        
        public static void GamepadRumble(ushort low, ushort high, uint ms, Player player = Player.Any)
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