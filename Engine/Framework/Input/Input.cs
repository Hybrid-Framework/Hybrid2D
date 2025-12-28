using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Input : Module<Input>
    {
        private Input() { }

        internal static Keyboards Keyboards { get; private set; } = new Keyboards();
        internal static Gamepads Gamepads { get; private set; } = new Gamepads();
        internal static Mouses Mouses { get; private set; } = new Mouses();


        internal override void OnStartOfFrame()
        {
            Keyboards.OnReset();
            Gamepads.OnReset();
            Mouses.OnReset();
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            Keyboards.OnEvent(e);
            Gamepads.OnEvent(e);
            Mouses.OnEvent(e);
        }

        // Dispose
        internal override void OnDispose()
        {
            Keyboards.OnDispose();
            Gamepads.OnDispose();
            Mouses.OnDispose();
        }
    }

    // Keyboard
    public partial class Input
    {
        public static bool GetKey(Key key, int playerID = -1)
        {
            var keyboard = Keyboards.GetKeyboardByPlayerID(playerID);

            if (keyboard != null)
            {
                return keyboard.GetKey(key);
            }
            
            return false;
        }
        
        public static bool GetKeyDown(Key key, int playerID = -1)
        {
            var keyboard = Keyboards.GetKeyboardByPlayerID(playerID);

            if (keyboard != null)
            {
                return keyboard.GetKeyDown(key);
            }
            
            return false;
        }
        
        public static bool GetKeyUp(Key key, int playerID = -1)
        {
            var keyboard = Keyboards.GetKeyboardByPlayerID(playerID);

            if (keyboard != null)
            {
                return keyboard.GetKeyUp(key);
            }
            
            return false;
        }
    }
    
    // Mouse
    public partial class Input
    {
        public static Vector2 MouseScrollDelta(int playerID = -1)
        {
            var mouse = Mouses.GetMouseByPlayerID(playerID);

            if (mouse != null)
            {
                return mouse.MouseScrollDelta.GetValue();
            }
            
            return Vector2.Zero;
        }
        
        public static Vector2 MousePosition(int playerID = -1)
        {
            var mouse = Mouses.GetMouseByPlayerID(playerID);

            if (mouse != null)
            {
                return mouse.MousePosition.GetValue();
            }
            
            return Vector2.Zero;
        }
        
        public static Vector2 MouseDelta(int playerID = -1)
        {
            var mouse = Mouses.GetMouseByPlayerID(playerID);

            if (mouse != null)
            {
                return mouse.MouseDelta.GetValue();
            }
            
            return Vector2.Zero;
        }
        
        public static bool GetMouseButton(int button, int playerID = -1)
        {
            var mouse = Mouses.GetMouseByPlayerID(playerID);

            if (mouse != null)
            {
                return mouse.GetMouseButton(button);
            }
            
            return false;
        }
        
        public static bool GetMouseButtonDown(int button, int playerID = -1)
        {
            var mouse = Mouses.GetMouseByPlayerID(playerID);

            if (mouse != null)
            {
                return mouse.GetMouseButtonDown(button);
            }
            
            return false;
        }
        
        public static bool GetMouseButtonUp(int button, int playerID = -1)
        {
            var mouse = Mouses.GetMouseByPlayerID(playerID);

            if (mouse != null)
            {
                return mouse.GetMouseButtonUp(button);
            }
            
            return false;
        }
    }
    
    // Gamepad
    public partial class Input
    {
        public static float GetGamepadDeadZone(int playerID = -1)
        {
            var gamepad = Gamepads.GetGamepadByPlayerID(playerID);

            if (gamepad != null)
            {
                return gamepad.GetGamepadDeadZone();
            }
            
            return 0;
        }
        
        public static void SetGamepadDeadZone(float value, int playerID = -1)
        {
            var gamepad = Gamepads.GetGamepadByPlayerID(playerID);

            if (gamepad != null)
            {
                gamepad.SetGamepadDeadZone(value);
            }
        }
        
        public static float GetGamepadAxis(Axis axis, int playerID = -1)
        {
            var gamepad = Gamepads.GetGamepadByPlayerID(playerID);

            if (gamepad != null)
            {
                return gamepad.GetGamepadAxis(axis);
            }
            
            return 0;
        }
        
        public static bool GetGamepadButton(Button button, int playerID = -1)
        {
            var gamepad = Gamepads.GetGamepadByPlayerID(playerID);

            if (gamepad != null)
            {
                return gamepad.GetGamepadButton(button);
            }
            
            return false;
        }
        
        public static bool GetGamepadButtonDown(Button button, int playerID = -1)
        {
            var gamepad = Gamepads.GetGamepadByPlayerID(playerID);

            if (gamepad != null)
            {
                return gamepad.GetGamepadButtonDown(button);
            }
            
            return false;
        }
        
        public static bool GetGamepadButtonUp(Button button, int playerID = -1)
        {
            var gamepad = Gamepads.GetGamepadByPlayerID(playerID);

            if (gamepad != null)
            {
                return gamepad.GetGamepadButtonUp(button);
            }
            
            return false;
        }
    }
}