using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    internal enum TextInputType : long
    {
        Default = 0, // Everything
        EmailOrURL = 2, // Letters, Symbols, Numbers (email or url focused)
        AlphaNumericSymbol = 4, // Letters, Symbols, Numbers
        Numeric = 6, // Number pad
    }
}