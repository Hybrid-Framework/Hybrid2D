using System;

namespace Hybrid
{
    // Rect
    public partial struct Rect : IEquatable<Rect>
    {
        public static readonly Rect Zero = new(0, 0, 0, 0);
        
        public float X;
        public float Y;
        public float W;
        public float H;
        

        public Rect(float x, float y, float w, float h)
        {
            this.X = x;
            this.Y = y;
            this.W = w;
            this.H = h;
        }

        public Rect(Vector2 position, Vector2 size)
        {
            this.X = position.X;
            this.Y = position.Y;
            this.W = size.X;
            this.H = size.Y;
        }

        public Rect()
        {
            
        }
    }
    
    // Operators
    public partial struct Rect
    {
        public static bool operator ==(Rect a, Rect b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Rect a, Rect b)
        {
            return !a.Equals(b);
        }
        
        public bool Equals(Rect r)
        {
            return Maths.Approximately(X, r.X) &&
                   Maths.Approximately(Y, r.Y) &&
                   Maths.Approximately(W, r.W) &&
                   Maths.Approximately(H, r.H);
        }

        public override bool Equals(object r)
        {
            if (r is Rect other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, W, H);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {W}, {H})";
        }
    }
    
    // SDL
    public partial struct Rect
    {
        internal static SDL.FRect? SDLFRect(Rect? rect)
        {
            if (rect.HasValue)
            {
                return new SDL.FRect()
                {
                    x = rect.Value.X,
                    y = rect.Value.Y,
                    w = rect.Value.W,
                    h = rect.Value.H
                };
            }

            return null;
        }
        
        internal static SDL.Rect? SDLRect(Rect? rect)
        {
            if (rect.HasValue)
            {
                return new SDL.Rect()
                {
                    x = (int)Maths.Round(rect.Value.X),
                    y = (int)Maths.Round(rect.Value.Y),
                    w = (int)Maths.Round(rect.Value.W),
                    h = (int)Maths.Round(rect.Value.H)
                };
            }

            return null;
        }
    }
}