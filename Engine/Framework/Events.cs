using static Hybrid.SDL2.SDL;
using System;

namespace Hybrid
{
    public static class Events
    {
        public static void Process(SDL_Event e)
        {
            Console.WriteLine($"Event: {e.type}");
            
            if (e.type == SDL_EventType.SDL_QUIT)
            {
                Platform.Current.IsRunning = false;
                return;
            }
        }
    }
}