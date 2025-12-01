window.Hybrid = window.Hybrid || {};

window.Hybrid.getOrientation = function () 
{
    if (screen.orientation && screen.orientation.type)
    {
        switch (screen.orientation.type)
        {
            case "portrait-primary": return "Portrait";
            case "portrait-secondary": return "PortraitFlipped";
            case "landscape-primary": return "Landscape";
            case "landscape-secondary": return "LandscapeFlipped";
        }
    }

    if (typeof window.orientation === "number")
    {
        switch (window.orientation)
        {
            case 0:   return "Portrait";
            case 180: return "PortraitFlipped";
            case 90:  return "Landscape";
            case -90: return "LandscapeFlipped";
        }
    }

    return "Unknown";
};
