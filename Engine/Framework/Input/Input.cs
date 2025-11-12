using System;

namespace Hybrid
{
    // Input
    public partial class Input : Module
    {
        internal static TouchScreen TouchScreen { get; private set; }
        internal static Keyboard Keyboard { get; private set; }
        internal static Gamepads Gamepads { get; private set; }
        internal static Mouse Mouse { get; private set; }

        internal Input(Config config)
        {
            TouchScreen = new TouchScreen();
            Keyboard = new Keyboard();
            Gamepads = new Gamepads();
            Mouse = new Mouse();
        }
        
        
        // Keyboard
        public static bool GetKeyDown(Key key) => Keyboard.GetKeyDown(key);
        public static bool GetKeyUp(Key key) => Keyboard.GetKeyUp(key);
        public static bool GetKey(Key key) => Keyboard.GetKey(key);
        
        // Mouse
        public static bool GetMouseButtonDown(int button) => Mouse.GetMouseButtonDown(button);
        public static bool GetMouseButtonUp(int button) => Mouse.GetMouseButtonUp(button);
        public static bool GetMouseButton(int button) => Mouse.GetMouseButton(button);
        public static Vector2 MousePositionDelta => Mouse.PositionDelta;
        public static Vector2 MouseScrollDelta => Mouse.ScrollDelta;
        public static Vector2 MousePosition => Mouse.Position;

        // Gamepad
        public static bool GetButtonDown(Button button, int player = 0) => Gamepads.GetButtonDown(button, player);
        public static bool GetButtonUp(Button button, int player = 0) => Gamepads.GetButtonUp(button, player);
        public static bool GetButton(Button button, int player = 0) => Gamepads.GetButton(button, player);
        public static float GetAxis(Axis axis, int player = 0) => Gamepads.GetAxis(axis, player);
        
        // Touches
        public static Touch GetTouch(int id) => TouchScreen.GetTouch(id);
        public static int TouchCount => TouchScreen.GetTouchCount();
        public static Touch[] Touches() => TouchScreen.GetTouches();
    }

    // Device Events
    public partial class Input
    {
        internal override void OnFrameStart()
        {
            TouchScreen.Reset();
            Keyboard.Reset();
            Gamepads.Reset();
            Mouse.Reset();
        }

        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Keyboard
                case SDL.EventType.KeyboardButtonUp:
                case SDL.EventType.KeyboardButtonDown:
                case SDL.EventType.KeyboardDeviceAdded:
                case SDL.EventType.KeyboardDeviceRemoved:
                    Keyboard.OnEvent(e);
                    break;
                
                // Mouse
                case SDL.EventType.MouseWheel:
                case SDL.EventType.MouseMotion:
                case SDL.EventType.MouseButtonUp:
                case SDL.EventType.MouseButtonDown:
                case SDL.EventType.MouseDeviceAdded:
                case SDL.EventType.MouseDeviceRemoved:
                    Mouse.OnEvent(e);
                    break;
                
                // Gamepad
                case SDL.EventType.GamepadButtonUp:
                case SDL.EventType.GamepadButtonDown:
                case SDL.EventType.GamepadAxisMotion:
                case SDL.EventType.GamepadDeviceAdded:
                case SDL.EventType.GamepadDeviceRemoved:
                    Gamepads.OnEvent(e);
                    break;
                
                // Touchscreen
                case SDL.EventType.TouchFingerUp:
                case SDL.EventType.TouchFingerDown:
                case SDL.EventType.TouchFingerCancel:
                case SDL.EventType.TouchFingerMotion:
                    TouchScreen.OnEvent(e);
                    break;
            }
        }

        internal override void Dispose()
        {
            Console.WriteLine("Input Disposed");
            
            TouchScreen.Dispose();
            Keyboard.Dispose();
            Gamepads.Dispose();
            Mouse.Dispose();
        }
    }
}