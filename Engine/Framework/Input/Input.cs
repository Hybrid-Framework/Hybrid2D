using System;

namespace Hybrid
{
    // Input
    public partial class Input : Module
    {
        public static TouchScreen TouchScreen { get; private set; }
        public static Keyboard Keyboard { get; private set; }
        public static Gamepad Gamepad { get; private set; }
        public static Mouse Mouse { get; private set; }

        internal Input(Config config)
        {
            TouchScreen = new TouchScreen();
            Keyboard = new Keyboard();
            Gamepad = new Gamepad();
            Mouse = new Mouse();
        }
    }

    // Device Events
    public partial class Input
    {
        internal override void OnEvent(SDL.Event e)
        {
            // Reset States
            TouchScreen.Reset();
            Keyboard.Reset();
            Gamepad.Reset();
            Mouse.Reset();
            
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
                    Gamepad.OnEvent(e);
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
            Gamepad.Dispose();
            Mouse.Dispose();
        }
    }
}