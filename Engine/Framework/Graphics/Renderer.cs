using System;

namespace Hybrid
{
    // Renderer
    internal static unsafe class Renderer
    {
        internal static SDL.Renderer* Handle
        {
            set;
            get;
        }
        
        
        internal static void Create(SDL.Window* window)
        {
            if (Handle != null) throw new Exception("Only one renderer instance allowed");
            
            Handle = SDL.CreateRenderer(window, null);
            SDL.SetRenderVSync(Handle, 1);
        }

        internal static void Destroy()
        {
            SDL.DestroyRenderer(Handle);
        }
    }
}