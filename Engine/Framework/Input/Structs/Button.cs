using System;

namespace Hybrid
{
    public readonly partial struct Button : IEquatable<Button>
    {
        public static readonly Button South = new(SDL.GamepadButton.South);
        public static readonly Button East = new(SDL.GamepadButton.East);
        public static readonly Button West = new(SDL.GamepadButton.West);
        public static readonly Button North = new(SDL.GamepadButton.North);
        public static readonly Button Back = new(SDL.GamepadButton.Back);
        public static readonly Button Guide = new(SDL.GamepadButton.Guide);
        public static readonly Button Start = new(SDL.GamepadButton.Start);
        public static readonly Button LeftStick = new(SDL.GamepadButton.LeftStick);
        public static readonly Button RightStick = new(SDL.GamepadButton.RightStick);
        public static readonly Button LeftShoulder = new(SDL.GamepadButton.LeftShoulder);
        public static readonly Button RightShoulder = new(SDL.GamepadButton.RightShoulder);
        public static readonly Button DpadUp = new(SDL.GamepadButton.DpadUp);
        public static readonly Button DpadDown = new(SDL.GamepadButton.DpadDown);
        public static readonly Button DpadLeft = new(SDL.GamepadButton.DpadLeft);
        public static readonly Button DpadRight = new(SDL.GamepadButton.DpadRight);
        
        internal readonly SDL.GamepadButton Handle;
        

        private Button(SDL.GamepadButton button)
        {
            Handle = button;
        }
    }

    public readonly partial struct Button
    {
        public bool Equals(Button button)
        {
            return Handle == button.Handle;
        }

        public override bool Equals(object button)
        {
            if (button is Button other)
            {
                return Equals(other);
            }

            return false;
        }

        public static bool operator ==(Button a, Button b)
        {
            return a.Handle == b.Handle;
        }

        public static bool operator !=(Button a, Button b)
        {
            return a.Handle != b.Handle;
        }
        
        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public override string ToString()
        {
            return Handle.ToString();
        }
    }
}
