using System;

namespace Hybrid
{
    public readonly partial struct Axis : IEquatable<Axis>
    {
        public static readonly Axis LeftHorizontal = new(SDL.GamepadAxis.LeftHorizontal);
        public static readonly Axis LeftVertical = new(SDL.GamepadAxis.LeftVertical);
        public static readonly Axis RightHorizontal = new(SDL.GamepadAxis.RightHorizontal);
        public static readonly Axis RightVertical = new(SDL.GamepadAxis.RightVertical);
        public static readonly Axis LeftTrigger = new(SDL.GamepadAxis.LeftTrigger);
        public static readonly Axis RightTrigger = new(SDL.GamepadAxis.RightTrigger);
        
        internal readonly SDL.GamepadAxis Handle;
        

        private Axis(SDL.GamepadAxis axis)
        {
            Handle = axis;
        }
    }

    public readonly partial struct Axis
    {
        public bool Equals(Axis button)
        {
            return Handle == button.Handle;
        }

        public override bool Equals(object button)
        {
            if (button is Axis other)
            {
                return Equals(other);
            }

            return false;
        }

        public static bool operator ==(Axis a, Axis b)
        {
            return a.Handle == b.Handle;
        }

        public static bool operator !=(Axis a, Axis b)
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
