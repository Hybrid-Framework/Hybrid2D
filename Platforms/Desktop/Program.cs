using static Engine.Internal.SDL2.SDL;
using System;
using Engine;
using Engine.Platforms;

public static class Program
{
    private static bool Initialized;
    
    public static void Main()
    {
        if (!Initialized)
        {
            Platform.Create(new PlatformDesktop(new Game()));
            Initialized = true;
        }
        
        Platform.Current.Run();
    }
}