using System;

namespace Hybrid
{
    public static unsafe class Misc
    {
        // Open a url in browser
        public static void OpenURL(string url)
        {
            SDL.OpenURL(url);
        }

        // Take a screenshot and save as png (screenshot_yyyy-mm-dd-hh-mm-ss)
        public static void TakeScreenshot()
        {
            SDL.RenderPresent(Graphics.Handle);
            
            var surface = SDL.RenderReadPixels(Graphics.Handle, null);
            
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = $"screenshot_{timestamp}.png";
            
            SDL_image.SavePNG(surface, Storage.ResolvePath(fileName));
            
            SDL.DestroySurface(surface);
        }
    }
}