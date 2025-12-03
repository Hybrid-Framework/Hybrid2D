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
            SDL.SetWindowFullscreen(Window.Handle, fullscreen);
        }

        public bool GetFullscreen()
        {
            return Window.HasFlags(SDL.WindowFlags.Fullscreen);
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
            return Window.HasFlags(SDL.WindowFlags.Resizable);
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

                SDL.SetWindowSize(Window.Handle, w, h);
            }
            else
            {
                Window.Restore();
            }
        }

        public bool GetMaximized()
        {
            var mobile = Platform.GetSystem().GetUnderlyingDevice() == UnderlyingDevice.Mobile;
            var maximized = Window.HasFlags(SDL.WindowFlags.Maximized);

            return maximized || mobile;
        }
    }

    
    // Minimize
    internal unsafe partial class WebDisplay
    {
        public void SetMinimized(bool minimized)
        {
            Window.Restore();
        }

        public bool GetMinimized()
        {
            return false;
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

                SDL.SetWindowSize(Window.Handle, w, h);
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