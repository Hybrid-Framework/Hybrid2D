using System;

namespace Hybrid
{
    internal static class Events
    {
        internal static Action<SDL.Event> OnEvent;
        
        internal static void Event(SDL.Event e)
        {
            var type = (SDL.EventType)e.type;
            
            if (type == SDL.EventType.Quit)
            {
                Platform.Current?.Quit();
                return;
            }
            
            OnEvent?.Invoke(e);
        }
    }
}