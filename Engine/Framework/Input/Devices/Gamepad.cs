using System;

namespace Hybrid
{
    // Gamepad API
    public unsafe partial class Gamepad : Device
    {
        private readonly HashSet<Button> Release = new HashSet<Button>();
        private readonly HashSet<Button> Press = new HashSet<Button>();
        private readonly HashSet<Button> Down = new HashSet<Button>();
        
        private float DeadZone { get; set; } = 0.2f;
        
        private float LeftStickX { get; set;}
        private float LeftStickY { get; set; }
        
        private float RightStickX { get; set; }
        private float RightStickY { get; set; }
        
        private float LeftTrigger { get; set; }
        private float RightTrigger { get; set; }

        private SDL.Gamepad* Handle;
        
        
        public bool GetButton(Button button)
        {
            return Press.Contains(button);
        }

        public bool GetButtonUp(Button button)
        {
            return Release.Contains(button);
        }
        
        public bool GetButtonDown(Button button)
        {
            return Down.Contains(button);
        }
        
        public float GetAxis(Axis axis)
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
        
        public void SetDeadZone(float value)
        {
            DeadZone = Maths.Clamp(value, 0f, 1f);
        }
    }
    
    // Gamepad Handling
    public unsafe partial class Gamepad
    {
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Handle Gamepad Add
                case SDL.EventType.GamepadDeviceAdded:
                {
                    if (Handle == null)
                    {
                        Handle = SDL.OpenGamepad(e.gamepadDevice.gamepadID);
                    }

                    break;
                }
                
                // Handle Gamepad Remove
                case SDL.EventType.GamepadDeviceRemoved:
                {
                    if (Handle != null)
                    {
                        if (e.gamepadDevice.gamepadID == SDL.GetGamepadID(Handle))
                        {
                            SDL.CloseGamepad(Handle);
                            Handle = null;
                        }
                    }
                    
                    break;
                }

                // Handle Gamepad Up
                case SDL.EventType.GamepadButtonUp:
                {
                    var key = (Button)e.gamepadButton.button;
                    Console.WriteLine($"Gamepad: {key}");

                    Press.Remove(key);
                    Release.Add(key);
                    
                    break;
                }

                // Handle Gamepad Down
                case SDL.EventType.GamepadButtonDown:
                {
                    var key = (Button)e.gamepadButton.button;
                    Console.WriteLine($"Gamepad: {key}");

                    if (!Press.Contains(key))
                    {
                        Down.Add(key);
                        Press.Add(key);
                    }
                    
                    break;
                }

                // Handle Gamepad Axis
                case SDL.EventType.GamepadAxisMotion:
                {
                    var axis = (Axis)e.gamepadAxis.axis;
                    var value = e.gamepadAxis.value >= 0 ? e.gamepadAxis.value / 32767f : e.gamepadAxis.value / 32768f;
                    var normalized = MathF.Abs(value) < DeadZone ? 0f : MathF.Sign(value) * (MathF.Abs(value) - DeadZone) / (1f - DeadZone);

                    switch (axis)
                    {
                        case Axis.LeftStickX: LeftStickX = normalized; break;
                        case Axis.LeftStickY: LeftStickY = -normalized; break;
                        case Axis.RightStickX: RightStickX = normalized; break;
                        case Axis.RightStickY: RightStickY = -normalized; break;
                        case Axis.LeftTrigger: LeftTrigger = normalized; break;
                        case Axis.RightTrigger: RightTrigger = normalized; break;
                    }
                    
                    break;
                }
            }
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