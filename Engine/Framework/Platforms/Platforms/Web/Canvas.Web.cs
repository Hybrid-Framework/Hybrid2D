using System;

namespace Hybrid
{
    // Orientation
    internal unsafe partial class WebCanvas : IPlatformCanvas
    {
        public Orientation GetOrientation()
        {
            string orientation = Emscripten.RunScriptString("HybridJS.GetOrientation();");

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
            return Emscripten.RunScriptInt($"HybridJS.SetFullscreen({(fullscreen ? 1 : 0)});") == 1;
        }

        public bool GetFullscreen()
        {
            var mobile = Platform.GetSystem().GetUnderlyingDevice() == UnderlyingDevice.Mobile;
            var fullscreen = Emscripten.RunScriptInt("HybridJS.GetFullscreen();") == 1;
            
            return fullscreen || mobile;
        }
    }

    // Resize
    internal unsafe partial class WebCanvas
    {
        public void Resize()
        {
            if (Platform.GetCanvas().GetFullscreen())
            {
                Emscripten.RunScript("HybridJS.FillDocument();");

                int w = Emscripten.RunScriptInt("HybridJS.GetCanvasWidth();");
                int h = Emscripten.RunScriptInt("HybridJS.GetCanvasHeight();");

                Window.Size = new Vector2(w, h);
            }
            else
            {
                Window.Restore();
            }
        }
    }
}