using System;

namespace Hybrid
{
    // Gamepad Device
    internal unsafe class Gamepad : Device
    {
        private readonly HashSet<Button> Down = new HashSet<Button>();
        private readonly HashSet<Button> Press = new HashSet<Button>();
        private readonly HashSet<Button> Release = new HashSet<Button>();
        
        internal SDL.Gamepad* Handle { get; private set; }
        internal int Player { get; }
        internal uint HID { get; }
        

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
            if (e.type == SDL.EventType.GamepadButtonDown)
            {
                if (e.gamepadAxis.gamepadID == HID)
                {
                    // Axis Control
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
            return 0;
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