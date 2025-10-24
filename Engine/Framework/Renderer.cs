using System;

namespace Hybrid
{
    // Renderer
    internal static unsafe partial class Renderer
    {
        public static Action OnCreated = null;
        public static Action OnDestroyed = null;
        
        
        internal static void Create(SDL.Window* window)
        {
            if (_handle == null)
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

    // Properties
    internal static unsafe partial class Renderer
    {
        private static SDL.Renderer* _handle;
        internal static SDL.Renderer* Handle
        {
            set => _handle = value;
            get
            {
                if (_handle == null)
                {
                    throw new Exception("Renderer instance does not exist");
                }

                return _handle;
            }
        }
    }
}