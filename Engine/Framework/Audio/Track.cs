using System.IO;
using System;

namespace Hybrid
{
    internal sealed unsafe class Track
    {
        internal SDL.Track* Handle
        {
            get; set;
        }
        
        internal Track(SDL.Track* handle)
        {
            Handle = handle;
        }
    }
}