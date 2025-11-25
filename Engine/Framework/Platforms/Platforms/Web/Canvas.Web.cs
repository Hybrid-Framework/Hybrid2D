using System;

namespace Hybrid
{
    public class WebCanvas : IPlatformCanvas
    {
        public Orientation GetNaturalOrientation()
        {
            return GetOrientation();
        }
        
        public Orientation GetOrientation()
        {
            var orientation = Emscripten.RunScriptString
            (
                @"(() =>
                {
                    // Modern API
                    if (screen.orientation && screen.orientation.type)
                    {
                        switch(screen.orientation.type)
                        {
                            case 'portrait-primary': return 'Portrait';
                            case 'portrait-secondary': return 'PortraitFlipped';
                            case 'landscape-primary': return 'Landscape';
                            case 'landscape-secondary': return 'LandscapeFlipped';
                        }
                    }

                    // Fallback
                    if (typeof window.orientation === 'number')
                    {
                        switch(window.orientation)
                        {
                            case 0: return 'Portrait';
                            case 180: return 'PortraitFlipped';
                            case 90: return 'Landscape';
                            case -90: return 'LandscapeFlipped';
                        }
                    }

                    return 'Unknown';

                })();"
            );
            
            switch (orientation)
            {
                case "Portrait":
                    return Orientation.PortraitPrimary;
                
                case "Landscape":
                    return Orientation.LandscapePrimary;
                
                case "PortraitFlipped":
                    return Orientation.PortraitSecondary;
                
                case "LandscapeFlipped":
                    return Orientation.LandscapeSecondary;
                
                default:
                    return Orientation.Unknown;
            }
        }
        
        public void HandleResize()
        {
            
        }
    }
}