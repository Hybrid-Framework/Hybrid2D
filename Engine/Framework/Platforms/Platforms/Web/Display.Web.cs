using System;

namespace Hybrid
{
    // Title
    internal unsafe partial class WebDisplay : IPlatformDisplay
    {
        public void SetTitle(string title)
        {
            SDL.SetWindowTitle(Window.Handle, title);
        }

        public string GetTitle()
        {
            return SDL.GetWindowTitle(Window.Handle);
        }
    }


    // Fullscreen
    internal unsafe partial class WebDisplay
    {
        public void SetFullscreen(bool fullscreen)
        {
            Emscripten.RunScriptInt($"HybridJS.SetFullscreen({(fullscreen ? 1 : 0)});");
        }

        public bool GetFullscreen()
        {
            return Emscripten.RunScriptInt("HybridJS.GetFullscreen();") == 1;
        }
    }

    
    // Resizable
    internal unsafe partial class WebDisplay
    {
        public void SetResizable(bool resizable)
        {
            SDL.SetWindowResizable(Window.Handle, resizable);
        }

        public bool GetResizable()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Resizable) != 0;
        }
    }
    

    // Maximize
    internal unsafe partial class WebDisplay
    {
        public void SetMaximized(bool maximized)
        {
            if (maximized)
            {
                Emscripten.RunScript("HybridJS.FillDocument();");

                int w = Emscripten.RunScriptInt("HybridJS.GetCanvasWidth();");
                int h = Emscripten.RunScriptInt("HybridJS.GetCanvasHeight();");

                Window.Size = new Vector2(w, h);
            }
            else
            {
                Restore();
            }
        }

        public bool GetMaximized()
        {
            var mobile = Platform.GetSystem().GetUnderlyingDevice() == UnderlyingDevice.Mobile;
            var maximized = Emscripten.RunScriptInt("HybridJS.IsFillDocument();") == 1;

            return maximized || mobile;
        }
    }

    
    // Minimize
    internal unsafe partial class WebDisplay
    {
        public void SetMinimized(bool minimized)
        {
            Restore();
        }

        public bool GetMinimized()
        {
            return false;
        }
    }

    
    // Restore
    internal unsafe partial class WebDisplay
    {
        public void Restore()
        {
            Window.Restore();
        }
    }
    
    
    // Resize
    internal unsafe partial class WebDisplay
    {
        public void Resize()
        {
            if (Platform.GetDisplay().GetFullscreen() || Platform.GetDisplay().GetMaximized())
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
    
    // Orientation
    internal unsafe partial class WebDisplay
    {
        public Orientation GetOrientation()
        {
            var orientation = Emscripten.RunScriptString("HybridJS.GetOrientation();");

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
}