using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public readonly struct Bool
    {
        private readonly byte value;

        public Bool(bool value)
        {
            this.value = (byte)(value ? 1 : 0);
        }

        public static implicit operator bool(Bool value) => value.value != 0;
        public static implicit operator Bool(bool value) => new Bool(value);
    }
}