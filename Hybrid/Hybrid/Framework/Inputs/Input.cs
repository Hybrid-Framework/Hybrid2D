using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Input : Module
    {
        internal static TouchKeyboard TouchKeyboard = new TouchKeyboard();
        internal static Keyboard Keyboard = new Keyboard();
        internal static Gamepad Gamepad = new Gamepad();
        internal static Mouse Mouse = new Mouse();
        internal static Touch Touch = new Touch();

        
        internal override void OnStartOfFrame()
        {
            TouchKeyboard.OnStartOfFrame();
            Keyboard.OnStartOfFrame();
            Gamepad.OnStartOfFrame();
            Mouse.OnStartOfFrame();
            Touch.OnStartOfFrame();
        }

        internal override void OnEvent(SDL.Event e)
        {
            TouchKeyboard.OnEvent(e);
            Keyboard.OnEvent(e);
            Gamepad.OnEvent(e);
            Mouse.OnEvent(e);
            Touch.OnEvent(e);
        }

        internal override void Destroy()
        {
            TouchKeyboard.Destroy();
            Keyboard.Destroy();
            Gamepad.Destroy();
            Mouse.Destroy();
            Touch.Destroy();
        }
    }
    
    // Keyboard
    public sealed partial class Input
    {
        // Get keyboard button pressed
        public static bool GetKeyboardButton(Key key)
        {
            return Keyboard.GetButton(key);
        }
        
        // Get keyboard button released
        public static bool GetKeyboardButtonUp(Key key)
        {
            return Keyboard.GetButtonUp(key);
        }
        
        // Get keyboard button down (single frame)
        public static bool GetKeyboardButtonDown(Key key)
        {
            return Keyboard.GetButtonDown(key);
        }
    }
    
    // Mouse
    public sealed partial class Input
    {
        // Get mouse button pressed
        public static bool GetMouseButton(int index)
        {
            return Mouse.GetButton(index);
        }
        
        // Get mouse button released
        public static bool GetMouseButtonUp(int index)
        {
            return Mouse.GetButtonUp(index);
        }
        
        // Get mouse button down (single frame)
        public static bool GetMouseButtonDown(int index)
        {
            return Mouse.GetButtonDown(index);
        }
        
        // Get mouse positon delta
        public static Point GetMousePositonDelta()
        {
            return Mouse.GetPositonDelta();
        }
        
        // Get mouse scroll delta
        public static Point GetMouseScrollDelta()
        {
            return Mouse.GetScrollDelta();
        }

        // Get mouse positon
        public static Point GetMousePositon()
        {
            return Mouse.GetPositon();
        }

        // Show mouse
        public static void ShowMouse()
        {
            Mouse.Show();
        }
        
        // Hide mouse
        public static void HideMouse()
        {
            Mouse.Hide();
        }
    }
    
    // Gamepad
    public sealed partial class Input
    {
        // Rumble gamepad for ms
        public static void SetGamepadRumble(int index, float strength, float ms)
        {
            Gamepad.Rumble(index, strength, ms);
        }
        
        // Get gamepad button pressed
        public static bool GetGamepadButton(int index, Button button)
        {
            return Gamepad.GetButton(index, button);
        }
        
        // Get gamepad button released
        public static bool GetGamepadButtonUp(int index, Button button)
        {
            return Gamepad.GetButtonUp(index, button);
        }
        
        // Get gamepad button down (single frame)
        public static bool GetGamepadButtonDown(int index, Button button)
        {
            return Gamepad.GetButtonDown(index, button);
        }
        
        // Get gamepad axis
        public static float GetGamepadAxis(int index, Axis axis)
        {
            return Gamepad.GetAxis(index, axis);
        }
        
        // Set gamepad dead zone
        public static void SetGamepadDeadZone(int index, float deadZone)
        {
            Gamepad.SetDeadZone(index, deadZone);
        }

        // Get gamepad dead zone
        public static float GetGamepadDeadZone(int index)
        {
            return Gamepad.GetDeadZone(index);
        }
    }

    // Touch
    public sealed partial class Input
    {
        // Get touch pressed
        public static bool GetTouch(int index)
        {
            return Touch.GetTouch(index);
        }
        
        // Get touch released
        public static bool GetTouchUp(int index)
        {
            return Touch.GetTouchUp(index);
        }
        
        // Get touch down (single frame)
        public static bool GetTouchDown(int index)
        {
            return Touch.GetTouchDown(index);
        }
        
        // Get touch position delta
        public static Point GetTouchPositionDelta(int index)
        {
            return Touch.GetTouchPositionDelta(index);
        }
        
        // Get touch position
        public static Point GetTouchPosition(int index)
        {
            return Touch.GetTouchPosition(index);
        }
        
        // Get touch pressure
        public static float GetTouchPressure(int index)
        {
            return Touch.GetTouchPressure(index);
        }
        
        // Get touch count
        public static int GetTouchCount()
        {
            return Touch.GetTouchCount();
        }
    }
    
    // Touch Keyboard
    public sealed partial class Input
    {
        // Open screen keyboard
        public static void OpenTouchKeyboard()
        {
            TouchKeyboard.Open();
        }

        // Close screen keyboard
        public static void CloseTouchKeyboard()
        {
            TouchKeyboard.Close();
        }

        // Is screen keyboard visible
        public static bool IsTouchKeyboardVisible()
        {
            return TouchKeyboard.IsVisible();
        }
        
        // Is screen keyboard supported
        public static bool IsTouchKeyboardSupported()
        {
            return TouchKeyboard.IsSupported();
        }
        
        // Get screen keyboard text
        public static string GetTouchKeyboardText()
        {
            return TouchKeyboard.GetText();
        }
    }
    
    // Clipboard
    public sealed partial class Input
    {
        // Set clipboard text
        public static void SetClipboardText(string text)
        {
            SDL.SetClipboardText(text);
        }
        
        // Get clipboard text
        public static string GetClipboardText()
        {
            return SDL.GetClipboardText();
        }
    }
}