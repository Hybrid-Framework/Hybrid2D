using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Graphics : Module<Graphics>
    {
        private Graphics() { }
        
        // Create
        internal override void OnCreate()
        {
            Console.WriteLine("Graphics Created");

            var config = Platform.GetConfig();
            
            Handle = SDL.CreateRenderer(Window.Handle, null);
            VSync = config.VSync;
        }
        
        // Render
        internal override void OnRender()
        {
            // Presentation
            SDL.SetRenderDrawColor(Handle, 255, 128, 128, 255);
            SDL.RenderClear(Handle);
            
            // Rendering
            SDL.SetRenderDrawColor(Handle, 255, 255, 255, 255);
            SDL.RenderDebugText(Handle, 10, 10, $"Screen: {Window.Width} {Window.Height}");
            
            // Present
            SDL.RenderPresent(Handle);
        }

        // Destroy
        internal override void OnDestroy()
        {
            Console.WriteLine("Graphics Destroyed");

            if (Handle != null)
            {
                SDL.DestroyRenderer(Handle);
                Handle = null;
            }
        }
    }

    // Graphics API
    public unsafe partial class Graphics
    {
        internal static SDL.Renderer* Handle
        {
            private set;
            get;
        }
        
        public static bool VSync
        {
            set => SDL.SetRenderVSync(Handle, value ? 1 : 0);
            get
            {
                SDL.GetRenderVSync(Handle, out int vsync);
                {
                    return vsync > 0;
                }
            }
        }
    }
}