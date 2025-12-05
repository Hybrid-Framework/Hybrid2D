using System;

namespace Hybrid
{
    internal class WindowEvents
    {
        internal void Push(SDL.EventType e)
        {
            if (!SDL.HasEvent(e))
            {
                SDL.Event custom = new SDL.Event()
                {
                    type = e
                };

                Window.Flags.OnEvent(custom);
                SDL.PushEvent(ref custom);
            }
        }

        internal void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                case SDL.EventType.Resized:
                {
                    Window.OnResized?.Invoke();
                    break;
                }
                
                case SDL.EventType.Orientation:
                {
                    Window.OnOrientation?.Invoke();
                    break;
                }
                
                case SDL.EventType.FullscreenOn:
                {
                    Window.OnFullscreen?.Invoke();
                    break;
                }
                
                case SDL.EventType.FullscreenOff:
                {
                    Window.OnFullscreen?.Invoke();
                    break;
                }
                
                case SDL.EventType.BorderlessOn:
                {
                    Window.OnBorder?.Invoke();
                    break;
                }
                
                case SDL.EventType.BorderlessOff:
                {
                    Window.OnBorder?.Invoke();
                    break;
                }

                case SDL.EventType.Maximized:
                {
                    Window.OnMaximized?.Invoke();
                    break;
                }
                
                case SDL.EventType.Minimized:
                {
                    Window.OnMinimized?.Invoke();
                    break;
                }
                
                case SDL.EventType.Moved:
                {
                    Window.OnMoved?.Invoke();
                    break;
                }
                
                case SDL.EventType.Restored:
                {
                    Window.OnRestore?.Invoke();
                    break;
                }
                
                case SDL.EventType.Hide:
                {
                    Window.OnHide?.Invoke();
                    break;
                }
                
                case SDL.EventType.Show:
                {
                    Window.OnShow?.Invoke();
                    break;
                }
                
                case SDL.EventType.Raised:
                {
                    Window.OnRaise?.Invoke();
                    break;
                }
                
                case SDL.EventType.Focused:
                {
                    Window.OnFocus?.Invoke();
                    break;
                }
                
                case SDL.EventType.Unfocused:
                {
                    Window.OnUnfocus?.Invoke();
                    break;
                }

                case SDL.EventType.MouseEnter:
                {
                    Window.OnMouseEnter?.Invoke();
                    break;
                }
                
                case SDL.EventType.MouseExit:
                {
                    Window.OnMouseExit?.Invoke();
                    break;
                }
                
                case SDL.EventType.SafeArea:
                {
                    Window.OnSafeArea?.Invoke();
                    break;
                }
            }
        }
    }
}