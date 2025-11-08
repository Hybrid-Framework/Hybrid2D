using System;

namespace Hybrid
{
    // Events
    internal static class Events
    {
        internal static Action<SDL.Event> OnEvent;
        
        
        internal static void Event(SDL.Event e)
        {
            SDL.EventType type = (SDL.EventType)e.type;
            
            if (type == SDL.EventType.Quit)
            {
                Platform.Current?.Quit();
                return;
            }
            
            OnEvent?.Invoke(e);
        }
    }
}