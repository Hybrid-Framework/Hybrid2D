using System;

namespace Hybrid
{
    public readonly partial struct Touch : IEquatable<Touch>
    {
        public readonly ulong ID;
        public readonly float X;
        public readonly float Y;
        
        
        internal Touch(SDL.Finger finger)
        {
            ID = finger.id;
            X = finger.x;
            Y = finger.y;
        }
    }
    
    public readonly partial struct Touch
    {
        public bool Equals(Touch touch)
        {
            return ID == touch.ID;
        }

        public override bool Equals(object touch)
        {
            if (touch is Touch other)
            {
                return Equals(other);
            }

            return false;
        }

        public static bool operator ==(Touch a, Touch b)
        {
            return a.ID == b.ID;
        }

        public static bool operator !=(Touch a, Touch b)
        {
            return a.ID != b.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            return $"({ID}, {X:F3}, {Y:F3})";
        }
    }
}