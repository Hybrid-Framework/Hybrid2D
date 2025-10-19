using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public sealed class Exception : System.Exception
    {
        public Exception() : base(SDL.GetError()) { }
        public Exception(string message) : base($"{message}: {SDL.GetError()}") { }
    }
}