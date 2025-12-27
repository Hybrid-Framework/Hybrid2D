using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Input : Module<Input>
    {
        private Input() { }

        internal static KeyboardDevice KeyboardDevice = new KeyboardDevice();
        internal static MouseDevice MouseDevice = new MouseDevice();


        internal override void OnStartOfFrame()
        {
            KeyboardDevice.OnReset();
            MouseDevice.OnReset();
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            KeyboardDevice.OnEvent(e);
            MouseDevice.OnEvent(e);
        }

        // Dispose
        internal override void OnDispose()
        {
            KeyboardDevice.OnDispose();
            MouseDevice.OnDispose();
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
}