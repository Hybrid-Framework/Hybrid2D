using System;

namespace Hybrid
{
    // Graphics Device (Events)
    public static partial class GraphicsDevice
    {
        public static Action OnOpened = null;
        public static Action OnClosed = null;
        public static Action OnFocus = null;
        public static Action OnUnfocus = null;
        public static Action OnMinimized = null;
        public static Action OnMaximized = null;
        public static Action OnMoved = null;
        public static Action OnResized = null;
        public static Action OnOrientation = null;
        
        
        internal static void OnEvent(SDL.Event e)
        {
            SDL.EventType type = (SDL.EventType)e.type;
            
            if (type == SDL.EventType.OrientationChanged) OnOrientation?.Invoke();
            if (type == SDL.EventType.Unfocused) OnUnfocus?.Invoke();
            if (type == SDL.EventType.Resized) OnResized?.Invoke();
            if (type == SDL.EventType.Focused) OnFocus?.Invoke();
            if (type == SDL.EventType.Moved) OnMoved?.Invoke();
        }
    }
}