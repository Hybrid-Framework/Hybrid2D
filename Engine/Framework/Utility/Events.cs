namespace Hybrid
{
    public static class Events
    {
        internal static void Event(SDL.Event e)
        {
            var type = (SDL.EventType)e.type;
            
            if (type == SDL.EventType.Quit)
            {
                Platform.Current?.Quit();
                return;
            }
            
            // Window Events
            Window.Events(e);
        }
    }
}