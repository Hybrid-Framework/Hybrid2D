using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Input : Module<Input>
    {
        private Input() { }
        
        internal static readonly VirtualInputs VirtualInputs = new VirtualInputs();
        internal static readonly TextInput TextInput = new TextInput();
        
        internal static readonly TouchScreen TouchScreen = new TouchScreen();
        internal static readonly Keyboard Keyboard = new Keyboard();
        internal static readonly Gamepad Gamepad = new Gamepad();
        internal static readonly Mouse Mouse = new Mouse();

        
        // Start Of Frame
        internal override void OnStartOfFrame()
        {
            TextInput.OnReset();
            
            TouchScreen.OnReset();
            Keyboard.OnReset();
            Gamepad.OnReset();
            Mouse.OnReset();
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            TextInput.OnEvent(e);
            
            TouchScreen.OnEvent(e);
            Keyboard.OnEvent(e);
            Gamepad.OnEvent(e);
            Mouse.OnEvent(e);
        }

        // Dispose
        internal override void OnDispose()
        {
            TextInput.OnDispose();
            
            TouchScreen.OnDispose();
            Keyboard.OnDispose();
            Gamepad.OnDispose();
            Mouse.OnDispose();
        }
    }
    
    // Actions
    public partial class Input
    {
        public static VirtualButton CreateVirtualButton(string name) => VirtualInputs.CreateVirtualButton(name);
        public static VirtualStick CreateVirtualStick(string name) => VirtualInputs.CreateVirtualStick(name);
        public static VirtualAxis CreateVirtualAxis(string name) => VirtualInputs.CreateVirtualAxis(name);
        
        public static void DestroyVirtualButton(string name) => VirtualInputs.DestroyVirtualButton(name);
        public static void DestroyVirtualStick(string name) => VirtualInputs.DestroyVirtualStick(name);
        public static void DestroyVirtualAxis(string name) => VirtualInputs.DestroyVirtualAxis(name);
        
        
        public static float GetVirtualAxis(string name)
        {
            var axis = VirtualInputs.CreateVirtualAxis(name);
            
            if (axis != null)
            {
                return axis.Value();
            }

            return 0;
        }
        
        public static Vector2 GetVirtualStick(string name)
        {
            var stick = VirtualInputs.CreateVirtualStick(name);
            
            if (stick != null)
            {
                return stick.Value();
            }

            return Vector2.Zero;
        }
        
        public static bool GetVirtualButton(string name)
        {
            var button = VirtualInputs.CreateVirtualButton(name);

            if (button != null)
            {
                return button.GetButton();
            }

            return false;
        }
        
        public static bool GetVirtualButtonUp(string name)
        {
            var button = VirtualInputs.CreateVirtualButton(name);

            if (button != null)
            {
                return button.GetButtonUp();
            }

            return false;
        }
        
        public static bool GetVirtualButtonDown(string name)
        {
            var button = VirtualInputs.CreateVirtualButton(name);

            if (button != null)
            {
                return button.GetButtonDown();
            }

            return false;
        }
    }
    
    // Text Input
    public partial class Input
    {
        public static string Text => TextInput.Text;
        
        
        public static void TextInputStart(TextInputMode mode = TextInputMode.Default, int limit = 0)
        {
            TextInput.TextInputStart(mode, limit);
        }

        public static void TextInputActive()
        {
            TextInput.TextInputActive();
        }
        
        public static void TextInputStop()
        {
            TextInput.TextInputStop();
        }

        public static void TextInputSetClipboardText(string text)
        {
            TextInput.TextInputSetClipboardText(text);
        }

        public static string TextInputGetClipboardText()
        {
            return TextInput.TextInputGetClipboardText();
        }
    }

    // Keyboard
    public partial class Input
    {
        public static KeyboardModifier KeyboardModifier => Keyboard.GetModifier();
        
        
        public static float GetKeyboardAxis(KeyboardAxis axis)
        {
            return Keyboard.GetAxis(axis);
        }
        
        public static bool GetKeyboardButton(KeyboardButton button)
        {
            return Keyboard.GetButton(button);
        }
        
        public static bool GetKeyboardButtonUp(KeyboardButton button)
        {
            return Keyboard.GetButtonUp(button);
        }
        
        public static bool GetKeyboardButtonDown(KeyboardButton button)
        {
            return Keyboard.GetButtonDown(button);
        }
    }
    
    // Mouse
    public partial class Input
    {
        public static Vector2 MousePositionDelta => Mouse.GetPositonDelta();
        public static Vector2 MouseScrollDelta => Mouse.GetScrollDelta();
        public static Vector2 MousePosition => Mouse.GetPositon();
        
        
        public static float GetMouseAxis(MouseAxis axis)
        {
            return Mouse.GetAxis(axis);
        }
        
        public static bool GetMouseButton(MouseButton button)
        {
            return Mouse.GetButton(button);
        }
        
        public static bool GetMouseButtonUp(MouseButton button)
        {
            return Mouse.GetButtonUp(button);
        }
        
        public static bool GetMouseButtonDown(MouseButton button)
        {
            return Mouse.GetButtonDown(button);
        }
    }
    
    // Gamepad
    public partial class Input
    {
        public static float GetGamepadAxis(GamepadAxis axis)
        {
            return Gamepad.GetAxis(axis);
        }
        
        public static bool GetGamepadButton(GamepadButton button)
        {
            return Gamepad.GetButton(button);
        }
        
        public static bool GetGamepadButtonUp(GamepadButton button)
        {
            return Gamepad.GetButtonUp(button);
        }
        
        public static bool GetGamepadButtonDown(GamepadButton button)
        {
            return Gamepad.GetButtonDown(button);
        }
    }
    
    // Touch
    public partial class Input
    {
        public static Touch GetTouch(int finger)
        {
            return TouchScreen.GetTouch(finger);
        }
        
        public static int GetTouchCount()
        {
            return TouchScreen.GetTouchCount();
        }
    }
}