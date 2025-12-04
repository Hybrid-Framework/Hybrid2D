using System;

namespace Hybrid
{
    internal class WindowFlags
    {
        private static SDL.WindowFlags Flags
        {
            get; set;
        }

        internal void SetFlags(SDL.WindowFlags flags)
        {
            Flags |= flags;
        }

        internal void ClearFlags(SDL.WindowFlags flags)
        {
            Flags &= ~flags;
        }
        
        internal bool HasFlags(SDL.WindowFlags flags)
        {
            return (Flags & flags) == flags;
        }

        internal SDL.WindowFlags GetFlags()
        {
            return Flags;
        }

        internal void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                case SDL.EventType.FullscreenOn:
                {
                    SetFlags(SDL.WindowFlags.Fullscreen);
                    break;
                }
                
                case SDL.EventType.FullscreenOff:
                {
                    ClearFlags(SDL.WindowFlags.Fullscreen);
                    break;
                }
                
                case SDL.EventType.Maximized:
                {
                    ClearFlags(SDL.WindowFlags.Minimized);
                    SetFlags(SDL.WindowFlags.Maximized);
                    break;
                }
                
                case SDL.EventType.Minimized:
                {
                    ClearFlags(SDL.WindowFlags.Maximized);
                    SetFlags(SDL.WindowFlags.Minimized);
                    break;
                }

                case SDL.EventType.Restored:
                {
                    ClearFlags(SDL.WindowFlags.Minimized);
                    ClearFlags(SDL.WindowFlags.Maximized);
                    break;
                }
            }
        }
    }
}