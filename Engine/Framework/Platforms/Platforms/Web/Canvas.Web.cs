using System;

namespace Hybrid
{
    // Orientation
    internal unsafe partial class WebCanvas : IPlatformCanvas
    {
        public Orientation GetOrientation()
        {
            string orientation = Emscripten.RunScriptString("Hybrid.getOrientation();");

            return orientation switch
            {
                "Portrait" => Orientation.PortraitPrimary,
                "Landscape" => Orientation.LandscapePrimary,
                "PortraitFlipped" => Orientation.PortraitSecondary,
                "LandscapeFlipped" => Orientation.LandscapeSecondary,
                
                _ => Orientation.Unknown,
            };
        }
    }
    
    // Fullscreen
    internal unsafe partial class WebCanvas
    {
        public bool SetFullscreen(bool fullscreen)
        {
            return Emscripten.RunScriptInt($"Hybrid.setFullscreen({(fullscreen ? 1 : 0)});") == 1;
        }

        public bool GetFullscreen()
        {
            return Emscripten.RunScriptInt("Hybrid.getFullscreen();") == 1;
        }
    }

    // Resize
    internal unsafe partial class WebCanvas
    {
        public void Resize()
        {
            var mobile = Platform.GetSystem().GetUnderlyingDevice() == UnderlyingDevice.Mobile;
            var fullscreen = Platform.GetCanvas().GetFullscreen();

            if (mobile || fullscreen)
            {
                Emscripten.RunScript("Hybrid.fillDocument();");

                int w = Emscripten.RunScriptInt("Hybrid.getWidth();");
                int h = Emscripten.RunScriptInt("Hybrid.getHeight();");

                SDL.SetWindowSize(Window.Handle, w, h);
            }
            else
            {
                SDL.SetWindowSize(Window.Handle, Platform.GetConfig().Width, Platform.GetConfig().Height);
            }
        }
    }
}