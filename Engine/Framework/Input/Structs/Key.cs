using System;

namespace Hybrid
{
    public readonly partial struct Key : IEquatable<Key>
    {
        public static readonly Key A = new Key(SDL.KeyCode.A);
        public static readonly Key B = new Key(SDL.KeyCode.B);
        public static readonly Key C = new Key(SDL.KeyCode.C);
        public static readonly Key D = new Key(SDL.KeyCode.D);
        public static readonly Key E = new Key(SDL.KeyCode.E);
        public static readonly Key F = new Key(SDL.KeyCode.F);
        public static readonly Key G = new Key(SDL.KeyCode.G);
        public static readonly Key H = new Key(SDL.KeyCode.H);
        public static readonly Key I = new Key(SDL.KeyCode.I);
        public static readonly Key J = new Key(SDL.KeyCode.J);
        public static readonly Key K = new Key(SDL.KeyCode.K);
        public static readonly Key L = new Key(SDL.KeyCode.L);
        public static readonly Key M = new Key(SDL.KeyCode.M);
        public static readonly Key N = new Key(SDL.KeyCode.N);
        public static readonly Key O = new Key(SDL.KeyCode.O);
        public static readonly Key P = new Key(SDL.KeyCode.P);
        public static readonly Key Q = new Key(SDL.KeyCode.Q);
        public static readonly Key R = new Key(SDL.KeyCode.R);
        public static readonly Key S = new Key(SDL.KeyCode.S);
        public static readonly Key T = new Key(SDL.KeyCode.T);
        public static readonly Key U = new Key(SDL.KeyCode.U);
        public static readonly Key V = new Key(SDL.KeyCode.V);
        public static readonly Key W = new Key(SDL.KeyCode.W);
        public static readonly Key X = new Key(SDL.KeyCode.X);
        public static readonly Key Y = new Key(SDL.KeyCode.Y);
        public static readonly Key Z = new Key(SDL.KeyCode.Z);

        public static readonly Key Num0 = new Key(SDL.KeyCode.Num0);
        public static readonly Key Num1 = new Key(SDL.KeyCode.Num1);
        public static readonly Key Num2 = new Key(SDL.KeyCode.Num2);
        public static readonly Key Num3 = new Key(SDL.KeyCode.Num3);
        public static readonly Key Num4 = new Key(SDL.KeyCode.Num4);
        public static readonly Key Num5 = new Key(SDL.KeyCode.Num5);
        public static readonly Key Num6 = new Key(SDL.KeyCode.Num6);
        public static readonly Key Num7 = new Key(SDL.KeyCode.Num7);
        public static readonly Key Num8 = new Key(SDL.KeyCode.Num8);
        public static readonly Key Num9 = new Key(SDL.KeyCode.Num9);

        public static readonly Key F1 = new Key(SDL.KeyCode.F1);
        public static readonly Key F2 = new Key(SDL.KeyCode.F2);
        public static readonly Key F3 = new Key(SDL.KeyCode.F3);
        public static readonly Key F4 = new Key(SDL.KeyCode.F4);
        public static readonly Key F5 = new Key(SDL.KeyCode.F5);
        public static readonly Key F6 = new Key(SDL.KeyCode.F6);
        public static readonly Key F7 = new Key(SDL.KeyCode.F7);
        public static readonly Key F8 = new Key(SDL.KeyCode.F8);
        public static readonly Key F9 = new Key(SDL.KeyCode.F9);
        public static readonly Key F10 = new Key(SDL.KeyCode.F10);
        public static readonly Key F11 = new Key(SDL.KeyCode.F11);
        public static readonly Key F12 = new Key(SDL.KeyCode.F12);

        public static readonly Key LeftArrow = new Key(SDL.KeyCode.LeftArrow);
        public static readonly Key RightArrow = new Key(SDL.KeyCode.RightArrow);
        public static readonly Key UpArrow = new Key(SDL.KeyCode.UpArrow);
        public static readonly Key DownArrow = new Key(SDL.KeyCode.DownArrow);

        public static readonly Key LeftControl = new Key(SDL.KeyCode.LeftControl);
        public static readonly Key LeftShift = new Key(SDL.KeyCode.LeftShift);
        public static readonly Key LeftAlt = new Key(SDL.KeyCode.LeftAlt);
        public static readonly Key RightControl = new Key(SDL.KeyCode.RightControl);
        public static readonly Key RightShift = new Key(SDL.KeyCode.RightShift);
        public static readonly Key RightAlt = new Key(SDL.KeyCode.RightAlt);

        public static readonly Key Return = new Key(SDL.KeyCode.Return);
        public static readonly Key Escape = new Key(SDL.KeyCode.Escape);
        public static readonly Key Backspace = new Key(SDL.KeyCode.Backspace);
        public static readonly Key Tab = new Key(SDL.KeyCode.Tab);
        public static readonly Key Space = new Key(SDL.KeyCode.Space);
        public static readonly Key Delete = new Key(SDL.KeyCode.Delete);
        public static readonly Key CapsLock = new Key(SDL.KeyCode.CapsLock);
        public static readonly Key PrintScreen = new Key(SDL.KeyCode.PrintScreen);
        public static readonly Key ScrollLock = new Key(SDL.KeyCode.ScrollLock);
        public static readonly Key Pause = new Key(SDL.KeyCode.Pause);
        public static readonly Key Insert = new Key(SDL.KeyCode.Insert);
        public static readonly Key Home = new Key(SDL.KeyCode.Home);
        public static readonly Key End = new Key(SDL.KeyCode.End);
        public static readonly Key PageUp = new Key(SDL.KeyCode.PageUp);
        public static readonly Key PageDown = new Key(SDL.KeyCode.PageDown);
        public static readonly Key Plus = new Key(SDL.KeyCode.Plus);
        public static readonly Key Minus = new Key(SDL.KeyCode.Minus);
        public static readonly Key Equal = new Key(SDL.KeyCode.Equals);
        public static readonly Key LeftBracket = new Key(SDL.KeyCode.LeftBracket);
        public static readonly Key RightBracket = new Key(SDL.KeyCode.RightBracket);
        public static readonly Key Semicolon = new Key(SDL.KeyCode.Semicolon);
        public static readonly Key Quote = new Key(SDL.KeyCode.Quote);
        public static readonly Key Comma = new Key(SDL.KeyCode.Comma);
        public static readonly Key Period = new Key(SDL.KeyCode.Period);
        public static readonly Key Slash = new Key(SDL.KeyCode.Slash);
        public static readonly Key Backslash = new Key(SDL.KeyCode.Backslash);
        public static readonly Key Tilde = new Key(SDL.KeyCode.Tilde);
        public static readonly Key Pipe = new Key(SDL.KeyCode.Pipe);
        public static readonly Key At = new Key(SDL.KeyCode.At);
        public static readonly Key Exclamation = new Key(SDL.KeyCode.Exclamation);
        public static readonly Key Question = new Key(SDL.KeyCode.Question);
        public static readonly Key Hash = new Key(SDL.KeyCode.Hash);
        public static readonly Key Dollar = new Key(SDL.KeyCode.Dollar);
        public static readonly Key Percent = new Key(SDL.KeyCode.Percent);
        public static readonly Key Ampersand = new Key(SDL.KeyCode.Ampersand);
        public static readonly Key Caret = new Key(SDL.KeyCode.Caret);
        public static readonly Key Underscore = new Key(SDL.KeyCode.Underscore);
        public static readonly Key Apostrophe = new Key(SDL.KeyCode.Apostrophe);
        public static readonly Key LeftParenthesis = new Key(SDL.KeyCode.LeftParenthesis);
        public static readonly Key RightParenthesis = new Key(SDL.KeyCode.RightParenthesis);
        public static readonly Key LeftBrace = new Key(SDL.KeyCode.LeftBrace);
        public static readonly Key RightBrace = new Key(SDL.KeyCode.RightBrace);
        public static readonly Key Less = new Key(SDL.KeyCode.Less);
        public static readonly Key Greater = new Key(SDL.KeyCode.Greater);
        public static readonly Key PlusMinus = new Key(SDL.KeyCode.PlusMinus);
        public static readonly Key Grave = new Key(SDL.KeyCode.Grave);
        
        internal readonly SDL.KeyCode Handle;
        

        private Key(SDL.KeyCode keyCode)
        {
            Handle = keyCode;
        }
    }

    public readonly partial struct Key
    {
        public bool Equals(Key key)
        {
            return Handle == key.Handle;
        }

        public override bool Equals(object key)
        {
            if (key is Key other)
            {
                return Equals(other);
            }

            return false;
        }

        public static bool operator ==(Key a, Key b)
        {
            return a.Handle == b.Handle;
        }

        public static bool operator !=(Key a, Key b)
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