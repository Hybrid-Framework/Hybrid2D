using System;

namespace Hybrid
{
    public enum TextInputMode
    {
        Default,            // Everything
        Password,           // Everything
        Symbols,            // All Symbols
        Alpha,              // Letters, Space
        AlphaNumeric,       // Letters, Numbers, Space
        AlphaNumericSymbol, // Letters, Number, All Symbols, Space
        Numeric,            // Numbers, Symbols(-,.)
        Email,              // Letters, Numbers, Symbols(@._+-)
        Username,           // Letters & Numbers, Symbols(-_)
        Url,                // Letters, Numbers, Symbols(-_.~:/?#[]@!$&'()*+,;=)
    }
}