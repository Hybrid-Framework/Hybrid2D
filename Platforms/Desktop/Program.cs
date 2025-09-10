using static Engine.Internal.SDL2.SDL;
using System;
using Engine;
using Engine.Platforms;

public static class Program
{
    public static void Main()
    {
        Platform.Create(new PlatformDesktop(new Game()));
        Platform.Current.Run();
    }
}