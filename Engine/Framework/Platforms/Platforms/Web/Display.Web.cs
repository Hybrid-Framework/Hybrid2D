using System;

namespace Hybrid
{
    // Title
    internal unsafe partial class WebDisplay : IPlatformDisplay
    {
        public bool SetTitle(string title)
        {
            return SDL.SetWindowTitle(Window.Handle, title);
        }

        public string GetTitle()
        {
            return SDL.GetWindowTitle(Window.Handle);
        }
    }


    // Fullscreen
    internal unsafe partial class WebDisplay
    {
        public bool SetFullscreen(bool fullscreen)
        {
            return SDL.SetWindowFullscreen(Window.Handle, fullscreen);
        }

        public bool GetFullscreen()
        {
            return Window.Flags.HasFlags(SDL.WindowFlags.Fullscreen);
        }
    }
    
    
    // Borderless
    internal unsafe partial class WebDisplay
    {
        public bool SetBorderless(bool borderless)
        {
            return false;
        }

        public bool GetBorderless()
        {
            return false;
        }
    }

    
    // Resizable
    internal unsafe partial class WebDisplay
    {
        public bool SetResizable(bool resizable)
        {
            return SDL.SetWindowResizable(Window.Handle, resizable);
        }

        public bool GetResizable()
        {
            return Window.Flags.HasFlags(SDL.WindowFlags.Resizable);
        }
    }
    

    // Maximize
    internal unsafe partial class WebDisplay
    {
        public bool SetMaximized(bool maximized)
        {
            if (maximized)
            {
                Emscripten.RunScript("HybridJS.FillDocument();");

                int w = Emscripten.RunScriptInt("HybridJS.GetCanvasWidth();");
                int h = Emscripten.RunScriptInt("HybridJS.GetCanvasHeight();");

                return SDL.SetWindowSize(Window.Handle, w, h);
            }
            
            Window.Restore();
            return true;
        }

        public bool GetMaximized()
        {
            var mobile = Platform.GetSystem().GetUnderlyingDevice() == UnderlyingDevice.Mobile;
            var maximized = Window.Flags.HasFlags(SDL.WindowFlags.Maximized);
            
            return maximized || mobile;
        }
    }

    
    // Minimize
    internal unsafe partial class WebDisplay
    {
        public bool SetMinimized(bool minimized)
        {
            return false;
        }

        public bool GetMinimized()
        {
            return false;
        }
    }
    
    
    // Resize
    internal unsafe partial class WebDisplay
    {
        public bool Resize()
        {
            if (Platform.GetDisplay().GetFullscreen() || Platform.GetDisplay().GetMaximized())
            {
                Emscripten.RunScript("HybridJS.FillDocument();");

                int w = Emscripten.RunScriptInt("HybridJS.GetCanvasWidth();");
                int h = Emscripten.RunScriptInt("HybridJS.GetCanvasHeight();");

                return SDL.SetWindowSize(Window.Handle, w, h);
            }
            
            Window.Restore();
            return true;
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