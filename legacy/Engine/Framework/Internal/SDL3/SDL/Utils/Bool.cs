using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public readonly struct Bool
    {
        private readonly byte _value;

        public Bool(bool value)
        {
            _value = (byte)(value ? 1 : 0);
        }

        public static implicit operator bool(Bool value) => value._value != 0;
        public static implicit operator Bool(bool value) => new Bool(value);
    }
}