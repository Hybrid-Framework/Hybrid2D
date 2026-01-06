using System;

namespace Hybrid
{
    // Application
    public static unsafe class Application
    {
        public static int TargetFrameRate
        {
            get;
            set;
        }
        
        public static bool VSync
        {
            set => SDL.SetRenderVSync(Graphics.Handle, value ? 1 : 0);
            get
            {
                SDL.GetRenderVSync(Graphics.Handle, out int vsync);
                {
                    return vsync > 0;
                }
            }
        }
        
        public static UnderlyingPlatform GetPlatform()
        {
            return Platform.GetSystem().GetUnderlyingPlatform();
        }
        
        public static UnderlyingDevice GetDevice()
        {
            return Platform.GetSystem().GetUnderlyingDevice();
        }
        
        public static void Quit()
        {
            Platform.Game.Quit();
        }
    }
}