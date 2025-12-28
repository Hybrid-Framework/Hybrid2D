using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Input : Module<Input>
    {
        private Input() { }

        internal static KeyboardDevice KeyboardDevice = new KeyboardDevice();
        internal static MouseDevice MouseDevice = new MouseDevice();
        internal static Gamepads Gamepads = new Gamepads();


        internal override void OnStartOfFrame()
        {
            Gamepads.OnReset();
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            Gamepads.OnEvent(e);
        }

        // Dispose
        internal override void OnDispose()
        {
            Gamepads.OnDispose();
        }
    }

    // Keyboard
    public partial class Input
    {
        public static bool GetKey(Key key)
        {
            return KeyboardDevice.GetKey(key);
        }
        
        public static bool GetKeyDown(Key key)
        {
            return KeyboardDevice.GetKeyDown(key);
        }
        
        public static bool GetKeyUp(Key key)
        {
            return KeyboardDevice.GetKeyUp(key);
        }
    }
    
    // Mouse
    public partial class Input
    {
        public static Vector2 MouseScrollDelta => MouseDevice.ScrollDelta.GetValue();
        public static Vector2 MousePosition => MouseDevice.Position.GetValue();
        public static Vector2 MouseDelta => MouseDevice.Delta.GetValue();
        
        
        public static bool GetMouseButton(int button)
        {
            return MouseDevice.GetMouseButton(button);
        }
        
        public static bool GetMouseButtonDown(int button)
        {
            return MouseDevice.GetMouseButtonDown(button);
        }
        
        public static bool GetMouseButtonUp(int button)
        {
            return MouseDevice.GetMouseButtonUp(button);
        }
    }
    
    // Gamepad
    public partial class Input
    {
        private static float _DeadZone { get; set; }
        public static float DeadZone
        {
            get => _DeadZone;
            set => _DeadZone = Maths.Clamp(value, 0, 1);
        }
        
        public static float GetAxis(Axis axis, int player)
        {
            var gamepad = Gamepads.GetGamepadByIndex(player);

            if (gamepad != null)
            {
                return gamepad.GetAxis(axis);
            }
            
            return 0;
        }
        
        public static bool GetButton(Button button, int player)
        {
            var gamepad = Gamepads.GetGamepadByIndex(player);

            if (gamepad != null)
            {
                return gamepad.GetButton(button);
            }
            
            return false;
        }
        
        public static bool GetButtonDown(Button button, int player)
        {
            var gamepad = Gamepads.GetGamepadByIndex(player);

            if (gamepad != null)
            {
                return gamepad.GetButtonDown(button);
            }
            
            return false;
        }
        
        public static bool GetButtonUp(Button button, int player)
        {
            var gamepad = Gamepads.GetGamepadByIndex(player);

            if (gamepad != null)
            {
                return gamepad.GetButtonUp(button);
            }
            
            return false;
        }
    }
}