using System;

namespace Hybrid
{
    public unsafe class WebOrientation : IPlatformOrientation
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
                    return Orientation.Portrait;
                
                case "Landscape":
                    return Orientation.Landscape;
                
                case "PortraitFlipped":
                    return Orientation.PortraitFlipped;
                
                case "LandscapeFlipped":
                    return Orientation.LandscapeFlipped;
                
                default:
                    return Orientation.Unknown;
            }
        }
    }
}