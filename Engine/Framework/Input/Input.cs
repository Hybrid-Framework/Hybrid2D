using System;

namespace Hybrid
{
    // Input
    public partial class Input : Module
    {
        internal static KeyboardDevice KeyboardDevice { get; private set; }
        internal static GamepadDevice GamepadDevice { get; private set; }
        internal static MouseDevice MouseDevice { get; private set; }
        internal static TouchDevice TouchDevice { get; private set; }


        internal Input(Config config)
        {
            KeyboardDevice = new KeyboardDevice();
            GamepadDevice = new GamepadDevice();
            MouseDevice = new MouseDevice();
            TouchDevice = new TouchDevice();
        }
        
        // Keyboard
        public static bool GetKey(Key key) => KeyboardDevice.GetKey(key);
        public static bool GetKeyUp(Key key) => KeyboardDevice.GetKeyUp(key);
        public static bool GetKeyDown(Key key) => KeyboardDevice.GetKeyDown(key);
        
        // Mouse
        public static Vector2 MousePosition => MouseDevice.Position;
        public static Vector2 MousePositionDelta => MouseDevice.Delta;
        public static Vector2 MouseScrollDelta => MouseDevice.ScrollDelta;
        public static bool GetMouseButton(int button) => MouseDevice.GetMouseButton(button);
        public static bool GetMouseButtonUp(int button) => MouseDevice.GetMouseButtonUp(button);
        public static bool GetMouseButtonDown(int button) => MouseDevice.GetMouseButtonDown(button);

        // Gamepad
        public static float GetAxis(Axis axis) => GamepadDevice.GetAxis(axis);
        public static bool GetButton(Button button) => GamepadDevice.GetButton(button);
        public static bool GetButtonUp(Button button) => GamepadDevice.GetButtonUp(button);
        public static bool GetButtonDown(Button button) => GamepadDevice.GetButtonDown(button);
        
        // Touches
        public static int TouchCount => TouchDevice.GetTouchCount();
        public static Touch[] Touches() => TouchDevice.GetTouches();
        public static Touch GetTouch(int id) => TouchDevice.GetTouch(id);
    }

    // Device Events
    public partial class Input
    {
        internal override void OnUpdate()
        {
            KeyboardDevice.Reset();
            GamepadDevice.Reset();
            MouseDevice.Reset();
            TouchDevice.Reset();
        }

        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Keyboard
                case SDL.EventType.KeyboardButtonUp:
                case SDL.EventType.KeyboardButtonDown:
                    KeyboardDevice.OnEvent(e);
                    break;
                
                // Mouse
                case SDL.EventType.MouseWheel:
                case SDL.EventType.MouseMotion:
                case SDL.EventType.MouseButtonUp:
                case SDL.EventType.MouseButtonDown:
                    MouseDevice.OnEvent(e);
                    break;
                
                // Gamepad
                case SDL.EventType.GamepadButtonUp:
                case SDL.EventType.GamepadButtonDown:
                case SDL.EventType.GamepadAxisMotion:
                    GamepadDevice.OnEvent(e);
                    break;
                
                // Touch
                case SDL.EventType.TouchFingerUp:
                case SDL.EventType.TouchFingerDown:
                case SDL.EventType.TouchFingerMotion:
                case SDL.EventType.TouchFingerCancel:
                    TouchDevice.OnEvent(e);
                    break;
            }
        }

        internal override void Dispose()
        {
            Console.WriteLine("Input Disposed");
        }
    }
}