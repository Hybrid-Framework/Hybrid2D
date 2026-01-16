using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal static class Mapping
    {
        private static readonly Dictionary<SDL.ScanCode, Key> SDLScanCodes = new()
        {
            { SDL.ScanCode.A, Key.A },
            { SDL.ScanCode.B, Key.B },
            { SDL.ScanCode.C, Key.C },
            { SDL.ScanCode.D, Key.D },
            { SDL.ScanCode.E, Key.E },
            { SDL.ScanCode.F, Key.F },
            { SDL.ScanCode.G, Key.G },
            { SDL.ScanCode.H, Key.H },
            { SDL.ScanCode.I, Key.I },
            { SDL.ScanCode.J, Key.J },
            { SDL.ScanCode.K, Key.K },
            { SDL.ScanCode.L, Key.L },
            { SDL.ScanCode.M, Key.M },
            { SDL.ScanCode.N, Key.N },
            { SDL.ScanCode.O, Key.O },
            { SDL.ScanCode.P, Key.P },
            { SDL.ScanCode.Q, Key.Q },
            { SDL.ScanCode.R, Key.R },
            { SDL.ScanCode.S, Key.S },
            { SDL.ScanCode.T, Key.T },
            { SDL.ScanCode.U, Key.U },
            { SDL.ScanCode.V, Key.V },
            { SDL.ScanCode.W, Key.W },
            { SDL.ScanCode.X, Key.X },
            { SDL.ScanCode.Y, Key.Y },
            { SDL.ScanCode.Z, Key.Z },
            
            { SDL.ScanCode.F1, Key.F1 },
            { SDL.ScanCode.F2, Key.F2 },
            { SDL.ScanCode.F3, Key.F3 },
            { SDL.ScanCode.F4, Key.F4 },
            { SDL.ScanCode.F5, Key.F5 },
            { SDL.ScanCode.F6, Key.F6 },
            { SDL.ScanCode.F7, Key.F7 },
            { SDL.ScanCode.F8, Key.F8 },
            { SDL.ScanCode.F9, Key.F9 },
            { SDL.ScanCode.F10, Key.F10 },
            { SDL.ScanCode.F11, Key.F11 },
            { SDL.ScanCode.F12, Key.F12 },
            
            { SDL.ScanCode.Alpha0, Key.Alpha0 },
            { SDL.ScanCode.Alpha1, Key.Alpha1 },
            { SDL.ScanCode.Alpha2, Key.Alpha2 },
            { SDL.ScanCode.Alpha3, Key.Alpha3 },
            { SDL.ScanCode.Alpha4, Key.Alpha4 },
            { SDL.ScanCode.Alpha5, Key.Alpha5 },
            { SDL.ScanCode.Alpha6, Key.Alpha6 },
            { SDL.ScanCode.Alpha7, Key.Alpha7 },
            { SDL.ScanCode.Alpha8, Key.Alpha8 },
            { SDL.ScanCode.Alpha9, Key.Alpha9 },
            
            { SDL.ScanCode.Return, Key.Return },
            { SDL.ScanCode.Escape, Key.Escape },
            { SDL.ScanCode.Backspace, Key.Backspace },
            { SDL.ScanCode.Tab, Key.Tab },
            { SDL.ScanCode.Space, Key.Space },
            { SDL.ScanCode.Delete, Key.Delete },
            { SDL.ScanCode.CapsLock, Key.CapsLock },
            { SDL.ScanCode.PrintScreen, Key.PrintScreen },
            { SDL.ScanCode.ScrollLock, Key.ScrollLock },
            { SDL.ScanCode.Home, Key.Home },
            { SDL.ScanCode.End, Key.End },
            { SDL.ScanCode.PageUp, Key.PageUp },
            { SDL.ScanCode.PageDown, Key.PageDown },
            
            { SDL.ScanCode.UpArrow, Key.UpArrow },
            { SDL.ScanCode.DownArrow, Key.DownArrow },
            { SDL.ScanCode.LeftArrow, Key.LeftArrow },
            { SDL.ScanCode.RightArrow, Key.RightArrow },
            
            { SDL.ScanCode.LeftControl, Key.LeftControl },
            { SDL.ScanCode.RightControl, Key.RightControl },
            { SDL.ScanCode.LeftShift, Key.LeftShift },
            { SDL.ScanCode.RightShift, Key.RightShift },
            { SDL.ScanCode.LeftAlt, Key.LeftAlt },
            { SDL.ScanCode.RightAlt, Key.RightAlt },
        };
        
        private static readonly Dictionary<SDL.KeyCode, Key> SDLKeyCodes = new()
        {
            { SDL.KeyCode.A, Key.A },
            { SDL.KeyCode.B, Key.B },
            { SDL.KeyCode.C, Key.C },
            { SDL.KeyCode.D, Key.D },
            { SDL.KeyCode.E, Key.E },
            { SDL.KeyCode.F, Key.F },
            { SDL.KeyCode.G, Key.G },
            { SDL.KeyCode.H, Key.H },
            { SDL.KeyCode.I, Key.I },
            { SDL.KeyCode.J, Key.J },
            { SDL.KeyCode.K, Key.K },
            { SDL.KeyCode.L, Key.L },
            { SDL.KeyCode.M, Key.M },
            { SDL.KeyCode.N, Key.N },
            { SDL.KeyCode.O, Key.O },
            { SDL.KeyCode.P, Key.P },
            { SDL.KeyCode.Q, Key.Q },
            { SDL.KeyCode.R, Key.R },
            { SDL.KeyCode.S, Key.S },
            { SDL.KeyCode.T, Key.T },
            { SDL.KeyCode.U, Key.U },
            { SDL.KeyCode.V, Key.V },
            { SDL.KeyCode.W, Key.W },
            { SDL.KeyCode.X, Key.X },
            { SDL.KeyCode.Y, Key.Y },
            { SDL.KeyCode.Z, Key.Z },
            
            { SDL.KeyCode.F1, Key.F1 },
            { SDL.KeyCode.F2, Key.F2 },
            { SDL.KeyCode.F3, Key.F3 },
            { SDL.KeyCode.F4, Key.F4 },
            { SDL.KeyCode.F5, Key.F5 },
            { SDL.KeyCode.F6, Key.F6 },
            { SDL.KeyCode.F7, Key.F7 },
            { SDL.KeyCode.F8, Key.F8 },
            { SDL.KeyCode.F9, Key.F9 },
            { SDL.KeyCode.F10, Key.F10 },
            { SDL.KeyCode.F11, Key.F11 },
            { SDL.KeyCode.F12, Key.F12 },
            
            { SDL.KeyCode.Alpha0, Key.Alpha0 },
            { SDL.KeyCode.Alpha1, Key.Alpha1 },
            { SDL.KeyCode.Alpha2, Key.Alpha2 },
            { SDL.KeyCode.Alpha3, Key.Alpha3 },
            { SDL.KeyCode.Alpha4, Key.Alpha4 },
            { SDL.KeyCode.Alpha5, Key.Alpha5 },
            { SDL.KeyCode.Alpha6, Key.Alpha6 },
            { SDL.KeyCode.Alpha7, Key.Alpha7 },
            { SDL.KeyCode.Alpha8, Key.Alpha8 },
            { SDL.KeyCode.Alpha9, Key.Alpha9 },
            
            { SDL.KeyCode.Return, Key.Return },
            { SDL.KeyCode.Escape, Key.Escape },
            { SDL.KeyCode.Backspace, Key.Backspace },
            { SDL.KeyCode.Tab, Key.Tab },
            { SDL.KeyCode.Space, Key.Space },
            { SDL.KeyCode.Delete, Key.Delete },
            { SDL.KeyCode.CapsLock, Key.CapsLock },
            { SDL.KeyCode.PrintScreen, Key.PrintScreen },
            { SDL.KeyCode.ScrollLock, Key.ScrollLock },
            { SDL.KeyCode.Home, Key.Home },
            { SDL.KeyCode.End, Key.End },
            { SDL.KeyCode.PageUp, Key.PageUp },
            { SDL.KeyCode.PageDown, Key.PageDown },
            
            { SDL.KeyCode.UpArrow, Key.UpArrow },
            { SDL.KeyCode.DownArrow, Key.DownArrow },
            { SDL.KeyCode.LeftArrow, Key.LeftArrow },
            { SDL.KeyCode.RightArrow, Key.RightArrow },
            
            { SDL.KeyCode.LeftControl, Key.LeftControl },
            { SDL.KeyCode.RightControl, Key.RightControl },
            { SDL.KeyCode.LeftShift, Key.LeftShift },
            { SDL.KeyCode.RightShift, Key.RightShift },
            { SDL.KeyCode.LeftAlt, Key.LeftAlt },
            { SDL.KeyCode.RightAlt, Key.RightAlt },
        };
        
        private static readonly Dictionary<SDL.GamepadButton, Button> SDLGamepadButtons = new()
        {
            [SDL.GamepadButton.South] = Button.South,
            [SDL.GamepadButton.East] = Button.East,
            [SDL.GamepadButton.West] = Button.West,
            [SDL.GamepadButton.North] = Button.North,
            [SDL.GamepadButton.LeftShoulder] = Button.LeftShoulder,
            [SDL.GamepadButton.RightShoulder] = Button.RightShoulder,
            [SDL.GamepadButton.Back] = Button.Back,
            [SDL.GamepadButton.Start] = Button.Start,
            [SDL.GamepadButton.LeftStick] = Button.LeftStick,
            [SDL.GamepadButton.RightStick] = Button.RightStick,
            [SDL.GamepadButton.DpadDown] = Button.DpadDown,
            [SDL.GamepadButton.DpadRight] = Button.DpadRight,
            [SDL.GamepadButton.DpadLeft] = Button.DpadLeft,
            [SDL.GamepadButton.DpadUp] = Button.DpadDown
        };
        
        private static readonly Dictionary<SDL.GamepadAxis, Axis> SDLGamepadAxes = new()
        {
            [SDL.GamepadAxis.LeftStickX] = Axis.LeftX,
            [SDL.GamepadAxis.LeftStickY] = Axis.LeftY,
            [SDL.GamepadAxis.RightStickX] = Axis.RightX,
            [SDL.GamepadAxis.RightStickY] = Axis.RightY,
            [SDL.GamepadAxis.LeftTrigger] = Axis.LeftTrigger,
            [SDL.GamepadAxis.RightTrigger] = Axis.RightTrigger
        };
        
        internal static Key GetKeyboardButtonFromSDLScanCode(SDL.ScanCode scanCode)
        {
            return SDLScanCodes.GetValueOrDefault(scanCode);
        }

        internal static Key GetKeyboardButtonFromSDLKeyCode(SDL.KeyCode keyCode)
        {
            return SDLKeyCodes.GetValueOrDefault(keyCode);
        }
        
        internal static Button GetGamepadButtonFromSDL(SDL.GamepadButton button)
        {
            return SDLGamepadButtons.GetValueOrDefault(button);
        }
        
        internal static Axis GetGamepadAxisFromSDL(SDL.GamepadAxis axis)
        {
            return SDLGamepadAxes.GetValueOrDefault(axis);
        }

        internal static int GetMouseFromSDL(byte mouse)
        {
            return mouse switch
            {
                1 => 0, // Left
                2 => 2, // Middle
                3 => 1, // Right
                4 => 3,
                5 => 4,
                6 => 5,
                7 => 6,
                8 => 7,
                
                _ => -1
            };
        }
    }
}