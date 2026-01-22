using Android.Content.PM;
using Org.Libsdl.App;
using System;

public abstract class Activity : SDLActivity
{
    protected override string[] GetLibraries()
    {
        return new[] { "SDL3", "SDL3_image", "SDL3_mixer", "SDL3_ttf" };
    }

    protected override void Main()
    {
        Entry();
    }

    public abstract void Entry();
}
