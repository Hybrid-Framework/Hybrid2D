using System;

namespace Hybrid
{
    // Renderer
    internal static unsafe partial class Renderer
    {
        internal static SDL.Renderer* Handle
        {
            set;
            get;
        }
        
        public static Action OnDestroyed = null;
        public static Action OnCreated = null;
        
        
        internal static void Create(SDL.Window* window)
        {
            if (Handle == null)
            {
                Handle = SDL.CreateRenderer(window, null);
                SDL.SetRenderVSync(Handle, 1);
                
                OnCreated?.Invoke();
            }
            else
            {
                throw new Exception("Only one renderer instance allowed");
            }
        }

        internal static void Destroy()
        {
            SDL.DestroyRenderer(Handle);
            
            OnDestroyed?.Invoke();
        }
    }
}