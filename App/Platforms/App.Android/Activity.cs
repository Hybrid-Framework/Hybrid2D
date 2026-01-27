#if ANDROID
using Org.Libsdl.App;
using System;

namespace Hybrid
{
    public abstract class Activity : SDLActivity
    {
        protected override string[] GetLibraries() => ["SDL3", "SDL3_image", "SDL3_mixer", "SDL3_ttf"];
    
        protected override void Main()
        {
            // Entry point
        }
    }
}
#endif