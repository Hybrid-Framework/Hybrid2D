using System;

namespace Hybrid
{
    internal class WebEvents : IPlatformEvents
    {
        public bool PollEvents(out SDL.Event e)
        {
            e = default;

            // Fetch Events
            string found = Emscripten.RunScriptString(
            @"
                (function(){
                    var evt = window.HybridJS.events.PollEvent();
                    return evt || '';
                })();
            ");

            // Process & Push Events
            if (!string.IsNullOrEmpty(found))
            {
                switch (found)
                {
                    case "resize":
                        SDL.Event resize = new SDL.Event();
                        resize.type = SDL.EventType.Resized;
                        SDL.PushEvent(ref resize);
                        break;
                    
                    default:
                        return false;
                }
            }

            // SDL Events
            if (SDL.PollEvent(out e))
            {
                return true;
            }

            return false;
        }
    }
}