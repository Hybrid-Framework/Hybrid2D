window.Hybrid = window.Hybrid || {};

window.Hybrid.getDevice = function()
{
    try
    {
        const uap = new UAParser();
        const device = uap.getDevice();
        
        if (device.type === "mobile") return "Mobile";
        if (device.type === "tablet") return "Mobile";
        if (device.type === "console") return "Mobile";
        if (device.type === "embedded") return "Mobile";
        if (device.type === "smarttv") return "Mobile";
        if (device.type === "wearable") return "Mobile";
        if (device.type === "xr") return "Mobile";

        if (navigator.userAgent.includes("iPad")) return "Mobile";

        return "Desktop";
    }
    catch (e)
    {
        return "Unknown";
    }
};
