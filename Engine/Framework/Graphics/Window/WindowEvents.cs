using System;

namespace Hybrid
{
    internal unsafe class WindowEvents
    {
        private void CallOnOrientation() => Console.WriteLine("OnOrientation");
        private void CallOnFullscreen() => Console.WriteLine("OnFullscreen");
        private void CallOnMaximized() => Console.WriteLine("OnMaximized");
        private void CallOnMinimized() => Console.WriteLine("OnMinimized");
        private void CallOnResized() => Console.WriteLine("OnResized");
        private void CallOnUnfocus() => Console.WriteLine("OnUnfocus");
        private void CallOnFocus() => Console.WriteLine("OnFocus");
        private void CallOnHide() => Console.WriteLine("OnHide");
        private void CallOnShow() => Console.WriteLine("OnShow");
        private void CallOnMoved() => Console.WriteLine("OnMoved");
        private void CallOnRestore() => Console.WriteLine("OnRestore");
        
        public static Action OnOrientation = null;
        public static Action OnFullscreen = null;
        public static Action OnMaximized = null;
        public static Action OnMinimized = null;
        public static Action OnResized = null;
        public static Action OnUnfocus = null;
        public static Action OnFocus = null;
        public static Action OnHide = null;
        public static Action OnShow = null;
        public static Action OnMoved = null;
        public static Action OnRestore = null;


        internal void RegisterEvents()
        {
            OnOrientation += CallOnOrientation;
            OnFullscreen += CallOnFullscreen;
            OnMaximized += CallOnMaximized;
            OnMinimized += CallOnMinimized;
            OnResized += CallOnResized;
            OnUnfocus += CallOnUnfocus;
            OnFocus += CallOnFocus;
            OnHide += CallOnHide;
            OnShow += CallOnShow;
            OnMoved += CallOnMoved;
            OnRestore += CallOnRestore;
        }

        internal void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                case SDL.EventType.Resized:
                {
                    OnResized?.Invoke();
                    break;
                }
                
                case SDL.EventType.Orientation:
                {
                    OnOrientation?.Invoke();
                    break;
                }
                
                case SDL.EventType.FullscreenOn:
                {
                    OnFullscreen?.Invoke();
                    break;
                }
                
                case SDL.EventType.FullscreenOff:
                {
                    OnFullscreen?.Invoke();
                    break;
                }

                case SDL.EventType.Maximized:
                {
                    OnMaximized?.Invoke();
                    break;
                }
                
                case SDL.EventType.Minimized:
                {
                    OnMinimized?.Invoke();
                    break;
                }
                
                case SDL.EventType.Moved:
                {
                    OnMoved?.Invoke();
                    break;
                }
                
                case SDL.EventType.Restored:
                {
                    OnRestore?.Invoke();
                    break;
                }
                
                case SDL.EventType.Hidden:
                {
                    OnHide?.Invoke();
                    break;
                }
                
                case SDL.EventType.Shown:
                {
                    OnShow?.Invoke();
                    break;
                }
                
                case SDL.EventType.Focused:
                {
                    OnFocus?.Invoke();
                    break;
                }
                
                case SDL.EventType.Unfocused:
                {
                    OnUnfocus?.Invoke();
                    break;
                }
            }
        }
    }
}