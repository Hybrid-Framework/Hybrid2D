using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public class Exception : System.Exception
    {
        public Exception() : base(SDL.GetError()) {}

        public Exception(string message) : base(message) {}

        public Exception(string message, Exception innerException) : base(message, innerException) {}
    }
}