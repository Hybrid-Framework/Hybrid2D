using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    public enum TextInputType : long
    {
        Default = 0,
        Name = 1,
        Email = 2,
        Username = 3,
        Password = 4,
        Numeric = 6,
    }
}