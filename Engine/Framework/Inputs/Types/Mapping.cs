using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal static class Mapping
    {
        private static readonly Dictionary<SDL.ScanCode, KeyboardButton> SDLScanCodes = new()
        {
            { SDL.ScanCode.A, KeyboardButton.A },
            { SDL.ScanCode.B, KeyboardButton.B },
            { SDL.ScanCode.C, KeyboardButton.C },
            { SDL.ScanCode.D, KeyboardButton.D },
            { SDL.ScanCode.E, KeyboardButton.E },
            { SDL.ScanCode.F, KeyboardButton.F },
            { SDL.ScanCode.G, KeyboardButton.G },
            { SDL.ScanCode.H, KeyboardButton.H },
            { SDL.ScanCode.I, KeyboardButton.I },
            { SDL.ScanCode.J, KeyboardButton.J },
            { SDL.ScanCode.K, KeyboardButton.K },
            { SDL.ScanCode.L, KeyboardButton.L },
            { SDL.ScanCode.M, KeyboardButton.M },
            { SDL.ScanCode.N, KeyboardButton.N },
            { SDL.ScanCode.O, KeyboardButton.O },
            { SDL.ScanCode.P, KeyboardButton.P },
            { SDL.ScanCode.Q, KeyboardButton.Q },
            { SDL.ScanCode.R, KeyboardButton.R },
            { SDL.ScanCode.S, KeyboardButton.S },
            { SDL.ScanCode.T, KeyboardButton.T },
            { SDL.ScanCode.U, KeyboardButton.U },
            { SDL.ScanCode.V, KeyboardButton.V },
            { SDL.ScanCode.W, KeyboardButton.W },
            { SDL.ScanCode.X, KeyboardButton.X },
            { SDL.ScanCode.Y, KeyboardButton.Y },
            { SDL.ScanCode.Z, KeyboardButton.Z },
            
            { SDL.ScanCode.F1, KeyboardButton.F1 },
            { SDL.ScanCode.F2, KeyboardButton.F2 },
            { SDL.ScanCode.F3, KeyboardButton.F3 },
            { SDL.ScanCode.F4, KeyboardButton.F4 },
            { SDL.ScanCode.F5, KeyboardButton.F5 },
            { SDL.ScanCode.F6, KeyboardButton.F6 },
            { SDL.ScanCode.F7, KeyboardButton.F7 },
            { SDL.ScanCode.F8, KeyboardButton.F8 },
            { SDL.ScanCode.F9, KeyboardButton.F9 },
            { SDL.ScanCode.F10, KeyboardButton.F10 },
            { SDL.ScanCode.F11, KeyboardButton.F11 },
            { SDL.ScanCode.F12, KeyboardButton.F12 },
            
            { SDL.ScanCode.Alpha0, KeyboardButton.Alpha0 },
            { SDL.ScanCode.Alpha1, KeyboardButton.Alpha1 },
            { SDL.ScanCode.Alpha2, KeyboardButton.Alpha2 },
            { SDL.ScanCode.Alpha3, KeyboardButton.Alpha3 },
            { SDL.ScanCode.Alpha4, KeyboardButton.Alpha4 },
            { SDL.ScanCode.Alpha5, KeyboardButton.Alpha5 },
            { SDL.ScanCode.Alpha6, KeyboardButton.Alpha6 },
            { SDL.ScanCode.Alpha7, KeyboardButton.Alpha7 },
            { SDL.ScanCode.Alpha8, KeyboardButton.Alpha8 },
            { SDL.ScanCode.Alpha9, KeyboardButton.Alpha9 },
            
            { SDL.ScanCode.Return, KeyboardButton.Return },
            { SDL.ScanCode.Escape, KeyboardButton.Escape },
            { SDL.ScanCode.Backspace, KeyboardButton.Backspace },
            { SDL.ScanCode.Tab, KeyboardButton.Tab },
            { SDL.ScanCode.Space, KeyboardButton.Space },
            { SDL.ScanCode.Delete, KeyboardButton.Delete },
            { SDL.ScanCode.CapsLock, KeyboardButton.CapsLock },
            { SDL.ScanCode.PrintScreen, KeyboardButton.PrintScreen },
            { SDL.ScanCode.ScrollLock, KeyboardButton.ScrollLock },
            { SDL.ScanCode.Home, KeyboardButton.Home },
            { SDL.ScanCode.End, KeyboardButton.End },
            { SDL.ScanCode.PageUp, KeyboardButton.PageUp },
            { SDL.ScanCode.PageDown, KeyboardButton.PageDown },
            
            { SDL.ScanCode.UpArrow, KeyboardButton.UpArrow },
            { SDL.ScanCode.DownArrow, KeyboardButton.DownArrow },
            { SDL.ScanCode.LeftArrow, KeyboardButton.LeftArrow },
            { SDL.ScanCode.RightArrow, KeyboardButton.RightArrow },
            
            { SDL.ScanCode.LeftControl, KeyboardButton.LeftControl },
            { SDL.ScanCode.RightControl, KeyboardButton.RightControl },
            { SDL.ScanCode.LeftShift, KeyboardButton.LeftShift },
            { SDL.ScanCode.RightShift, KeyboardButton.RightShift },
            { SDL.ScanCode.LeftAlt, KeyboardButton.LeftAlt },
            { SDL.ScanCode.RightAlt, KeyboardButton.RightAlt },
        };
        
        private static readonly Dictionary<SDL.KeyCode, KeyboardButton> SDLKeyCodes = new()
        {
            { SDL.KeyCode.A, KeyboardButton.A },
            { SDL.KeyCode.B, KeyboardButton.B },
            { SDL.KeyCode.C, KeyboardButton.C },
            { SDL.KeyCode.D, KeyboardButton.D },
            { SDL.KeyCode.E, KeyboardButton.E },
            { SDL.KeyCode.F, KeyboardButton.F },
            { SDL.KeyCode.G, KeyboardButton.G },
            { SDL.KeyCode.H, KeyboardButton.H },
            { SDL.KeyCode.I, KeyboardButton.I },
            { SDL.KeyCode.J, KeyboardButton.J },
            { SDL.KeyCode.K, KeyboardButton.K },
            { SDL.KeyCode.L, KeyboardButton.L },
            { SDL.KeyCode.M, KeyboardButton.M },
            { SDL.KeyCode.N, KeyboardButton.N },
            { SDL.KeyCode.O, KeyboardButton.O },
            { SDL.KeyCode.P, KeyboardButton.P },
            { SDL.KeyCode.Q, KeyboardButton.Q },
            { SDL.KeyCode.R, KeyboardButton.R },
            { SDL.KeyCode.S, KeyboardButton.S },
            { SDL.KeyCode.T, KeyboardButton.T },
            { SDL.KeyCode.U, KeyboardButton.U },
            { SDL.KeyCode.V, KeyboardButton.V },
            { SDL.KeyCode.W, KeyboardButton.W },
            { SDL.KeyCode.X, KeyboardButton.X },
            { SDL.KeyCode.Y, KeyboardButton.Y },
            { SDL.KeyCode.Z, KeyboardButton.Z },
            
            { SDL.KeyCode.F1, KeyboardButton.F1 },
            { SDL.KeyCode.F2, KeyboardButton.F2 },
            { SDL.KeyCode.F3, KeyboardButton.F3 },
            { SDL.KeyCode.F4, KeyboardButton.F4 },
            { SDL.KeyCode.F5, KeyboardButton.F5 },
            { SDL.KeyCode.F6, KeyboardButton.F6 },
            { SDL.KeyCode.F7, KeyboardButton.F7 },
            { SDL.KeyCode.F8, KeyboardButton.F8 },
            { SDL.KeyCode.F9, KeyboardButton.F9 },
            { SDL.KeyCode.F10, KeyboardButton.F10 },
            { SDL.KeyCode.F11, KeyboardButton.F11 },
            { SDL.KeyCode.F12, KeyboardButton.F12 },
            
            { SDL.KeyCode.Alpha0, KeyboardButton.Alpha0 },
            { SDL.KeyCode.Alpha1, KeyboardButton.Alpha1 },
            { SDL.KeyCode.Alpha2, KeyboardButton.Alpha2 },
            { SDL.KeyCode.Alpha3, KeyboardButton.Alpha3 },
            { SDL.KeyCode.Alpha4, KeyboardButton.Alpha4 },
            { SDL.KeyCode.Alpha5, KeyboardButton.Alpha5 },
            { SDL.KeyCode.Alpha6, KeyboardButton.Alpha6 },
            { SDL.KeyCode.Alpha7, KeyboardButton.Alpha7 },
            { SDL.KeyCode.Alpha8, KeyboardButton.Alpha8 },
            { SDL.KeyCode.Alpha9, KeyboardButton.Alpha9 },
            
            { SDL.KeyCode.Return, KeyboardButton.Return },
            { SDL.KeyCode.Escape, KeyboardButton.Escape },
            { SDL.KeyCode.Backspace, KeyboardButton.Backspace },
            { SDL.KeyCode.Tab, KeyboardButton.Tab },
            { SDL.KeyCode.Space, KeyboardButton.Space },
            { SDL.KeyCode.Delete, KeyboardButton.Delete },
            { SDL.KeyCode.CapsLock, KeyboardButton.CapsLock },
            { SDL.KeyCode.PrintScreen, KeyboardButton.PrintScreen },
            { SDL.KeyCode.ScrollLock, KeyboardButton.ScrollLock },
            { SDL.KeyCode.Home, KeyboardButton.Home },
            { SDL.KeyCode.End, KeyboardButton.End },
            { SDL.KeyCode.PageUp, KeyboardButton.PageUp },
            { SDL.KeyCode.PageDown, KeyboardButton.PageDown },
            
            { SDL.KeyCode.UpArrow, KeyboardButton.UpArrow },
            { SDL.KeyCode.DownArrow, KeyboardButton.DownArrow },
            { SDL.KeyCode.LeftArrow, KeyboardButton.LeftArrow },
            { SDL.KeyCode.RightArrow, KeyboardButton.RightArrow },
            
            { SDL.KeyCode.LeftControl, KeyboardButton.LeftControl },
            { SDL.KeyCode.RightControl, KeyboardButton.RightControl },
            { SDL.KeyCode.LeftShift, KeyboardButton.LeftShift },
            { SDL.KeyCode.RightShift, KeyboardButton.RightShift },
            { SDL.KeyCode.LeftAlt, KeyboardButton.LeftAlt },
            { SDL.KeyCode.RightAlt, KeyboardButton.RightAlt },
        };
        
        private static readonly Dictionary<SDL.GamepadButton, GamepadButton> SDLGamepadButtons = new()
        {
            [SDL.GamepadButton.South] = GamepadButton.South,
            [SDL.GamepadButton.East] = GamepadButton.East,
            [SDL.GamepadButton.West] = GamepadButton.West,
            [SDL.GamepadButton.North] = GamepadButton.North,
            [SDL.GamepadButton.LeftShoulder] = GamepadButton.LeftShoulder,
            [SDL.GamepadButton.RightShoulder] = GamepadButton.RightShoulder,
            [SDL.GamepadButton.Back] = GamepadButton.Back,
            [SDL.GamepadButton.Start] = GamepadButton.Start,
            [SDL.GamepadButton.LeftStick] = GamepadButton.LeftStick,
            [SDL.GamepadButton.RightStick] = GamepadButton.RightStick,
            [SDL.GamepadButton.DpadDown] = GamepadButton.DpadDown,
            [SDL.GamepadButton.DpadRight] = GamepadButton.DpadRight,
            [SDL.GamepadButton.DpadLeft] = GamepadButton.DpadLeft,
            [SDL.GamepadButton.DpadUp] = GamepadButton.DpadDown
        };
        
        private static readonly Dictionary<SDL.GamepadAxis, GamepadAxis> SDLGamepadAxes = new()
        {
            [SDL.GamepadAxis.LeftStickX] = GamepadAxis.LeftX,
            [SDL.GamepadAxis.LeftStickY] = GamepadAxis.LeftY,
            [SDL.GamepadAxis.RightStickX] = GamepadAxis.RightX,
            [SDL.GamepadAxis.RightStickY] = GamepadAxis.RightY,
            [SDL.GamepadAxis.LeftTrigger] = GamepadAxis.LeftTrigger,
            [SDL.GamepadAxis.RightTrigger] = GamepadAxis.RightTrigger
        };
        
        internal static KeyboardButton GetKeyboardButtonFromSDLScanCode(SDL.ScanCode scanCode)
        {
            return SDLScanCodes.GetValueOrDefault(scanCode);
        }

        internal static KeyboardButton GetKeyboardButtonFromSDLKeyCode(SDL.KeyCode keyCode)
        {
            return SDLKeyCodes.GetValueOrDefault(keyCode);
        }
        
        internal static GamepadButton GetGamepadButtonFromSDL(SDL.GamepadButton button)
        {
            return SDLGamepadButtons.GetValueOrDefault(button);
        }
        
        internal static GamepadAxis GetGamepadAxisFromSDL(SDL.GamepadAxis axis)
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