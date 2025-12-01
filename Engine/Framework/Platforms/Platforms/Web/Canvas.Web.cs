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
            if (Emscripten.RunScriptInt($"Hybrid.setFullscreen({(fullscreen ? 1 : 0)});") == 1)
            {
                var state = GetFullscreen();

                if (state)
                {
                    // Enter Fullscreen
                }
                else
                {
                    // Exit Fullscreen
                }

                return true;
            }

            return false;
        }

        public bool GetFullscreen()
        {
            return Emscripten.RunScriptInt("Hybrid.getFullscreen();") == 1;
        }
    }
}

// Fill Document
// Emscripten.RunScript
// (
// @"(() =>
// {
//      const c = document.getElementById('canvas');
//      if (!c) return;
//
//      const width = document.documentElement.clientWidth;
//      const height = document.documentElement.clientHeight;
//
//      c.width = width;
//      c.height = height;
//
//      c.style.width = width + 'px';
//      c.style.height = height + 'px';
//  })();
// ");
//
// int w = Emscripten.RunScriptInt("document.getElementById('canvas').width;");
// int h = Emscripten.RunScriptInt("document.getElementById('canvas').height;");
// Window.Size = new Vector2(w, h);