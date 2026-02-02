using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    internal sealed class Exception : System.Exception
    {
        internal Exception() : base(SDL.GetError()) { }
        internal Exception(string message) : base($"{message}: {SDL.GetError()}") { }
    }
}