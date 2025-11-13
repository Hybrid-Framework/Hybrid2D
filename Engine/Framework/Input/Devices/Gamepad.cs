using System;

namespace Hybrid
{
    // Gamepad Device
    internal unsafe class Gamepad : Device
    {
        private readonly HashSet<Button> Down = new HashSet<Button>();
        private readonly HashSet<Button> Press = new HashSet<Button>();
        private readonly HashSet<Button> Release = new HashSet<Button>();
        
        internal float DeadZone { get; set; } = 0.2f;
        
        private SDL.Gamepad* Handle { get; set; }
        internal int Player { get; }
        internal uint HID { get; }
        
        private float LeftStickX;
        private float LeftStickY;
        private float LeftTrigger;
        private float RightStickX;
        private float RightStickY;
        private float RightTrigger;
        

        internal Gamepad(SDL.Gamepad* handle, uint hid, int player)
        {
            this.Player = player;
            this.Handle = handle;
            this.HID = hid;
        }
        
        internal override void OnEvent(SDL.Event e)
        {
            // Gamepad Press
            if (e.type == SDL.EventType.GamepadButtonDown)
            {
                if (e.gamepadButton.gamepadID == HID)
                {
                    var key = (Button)e.gamepadButton.button;
                    Console.WriteLine($"Gamepad ({Player}) {key}");

                    if (!Press.Contains(key))
                    {
                        Down.Add(key);
                        Press.Add(key);
                    }
                }
            }
            
            // Gamepad Release
            if (e.type == SDL.EventType.GamepadButtonUp)
            {
                if (e.gamepadButton.gamepadID == HID)
                {
                    var key = (Button)e.gamepadButton.button;
                    Console.WriteLine($"Gamepad ({Player}) {key}");

                    Press.Remove(key);
                    Release.Add(key);
                }
            }
            
            // Gamepad Axis
            if (e.type == SDL.EventType.GamepadAxisMotion)
            {
                if (e.gamepadAxis.gamepadID == HID)
                {
                    var axis = (Axis)e.gamepadAxis.axis;
                    var value = e.gamepadAxis.value >= 0 ? e.gamepadAxis.value / 32767f : e.gamepadAxis.value / 32768f;
                    var normalized = MathF.Abs(value) < DeadZone ? 0f : MathF.Sign(value) * (MathF.Abs(value) - DeadZone) / (1f - DeadZone);
                    
                    if (axis == Axis.LeftStickX) LeftStickX = normalized;
                    if (axis == Axis.LeftStickY) LeftStickY = -normalized;
                    
                    if (axis == Axis.RightStickX) RightStickX = normalized;
                    if (axis == Axis.RightStickY) RightStickY = -normalized;
                    
                    if (axis == Axis.LeftTrigger) LeftTrigger = normalized;
                    if (axis == Axis.RightTrigger) RightTrigger = normalized;
                }
            }
        }
        
        internal bool GetButton(Button button)
        {
            return Press.Contains(button);
        }

        internal bool GetButtonUp(Button button)
        {
            return Release.Contains(button);
        }
        
        internal bool GetButtonDown(Button button)
        {
            return Down.Contains(button);
        }
        
        internal float GetAxis(Axis axis)
        {
            return axis switch
            {
                Axis.LeftStickX => LeftStickX,
                Axis.LeftStickY => LeftStickY,
                Axis.RightStickX => RightStickX,
                Axis.RightStickY => RightStickY,
                Axis.LeftTrigger => LeftTrigger,
                Axis.RightTrigger => RightTrigger,
                
                _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, "Unknown axis type")
            };
        }
        
        internal override void Reset()
        {
            Release.Clear();
            Down.Clear();
        }
        
        internal override void Dispose()
        {
            if (Handle != null)
            {
                SDL.CloseGamepad(Handle);
                Handle = null;
            }
            
            Down.Clear();
            Press.Clear();
            Release.Clear();
        }
    }
}