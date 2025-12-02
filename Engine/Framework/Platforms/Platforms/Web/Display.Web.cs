using System;

namespace Hybrid
{
    internal unsafe class WebDisplay : IPlatformDisplay
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
        
        public bool SetTitle(string title)
        {
            return SDL.SetWindowTitle(Window.Handle, title);
        }

        public string GetTitle()
        {
            return SDL.GetWindowTitle(Window.Handle);
        }
        
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
        
        public bool SetResizable(bool resizable)
        {
            return SDL.SetWindowResizable(Window.Handle, resizable);
        }

        public bool GetResizable()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Resizable) != 0;
        }

        public bool Maximize()
        {
            return SDL.MaximizeWindow(Window.Handle);
        }
        
        public bool Minimize()
        {
            return SDL.MinimizeWindow(Window.Handle);
        }

        public bool Restore()
        {
            return SDL.RestoreWindow(Window.Handle);
        }
        
        public void Resize()
        {
            if (Platform.GetDisplay().GetFullscreen())
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