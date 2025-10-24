namespace Hybrid
{
    public static class Events
    {
        internal static void Event(SDL.EventType e)
        {
            // Quit
            if (e == SDL.EventType.Quit)
            {
                Platform.Current?.Quit();
                return;
            }
            
            // Window Events
            Window.Events(e);
        }
    }
}