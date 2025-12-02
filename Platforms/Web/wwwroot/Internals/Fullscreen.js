window.HybridJS = window.HybridJS || {};


window.HybridJS.IsFullscreen = function(canvas)
{
    return ( document.fullscreenElement === canvas || document.webkitFullscreenElement === canvas || document.mozFullScreenElement === canvas || document.msFullscreenElement === canvas );
};

window.HybridJS.FullscreenElement = function()
{
    return ( document.fullscreenElement || document.webkitFullscreenElement || document.mozFullScreenElement || document.msFullscreenElement );
};

window.HybridJS.RequestFullscreen = function(canvas)
{
    return ( canvas.requestFullscreen || canvas.webkitRequestFullscreen || canvas.mozRequestFullScreen || canvas.msRequestFullscreen );
};

window.HybridJS.ExitFullscreen = function()
{
    return ( document.exitFullscreen || document.webkitExitFullscreen || document.mozCancelFullScreen || document.msExitFullscreen );
};


window.HybridJS.SetFullscreen = function(value)
{
    const canvas = HybridJS.GetCanvas();
    if (!canvas) return 0;

    try
    {
        if (value)
        {
            if (!HybridJS.IsFullscreen(canvas))
            {
                HybridJS.RequestFullscreen(canvas)?.call(canvas);
            }

            return 1;
        }
        else
        {
            if (document.visibilityState !== "visible")
            {
                return 0;
            }

            if (HybridJS.FullscreenElement())
            {
                HybridJS.ExitFullscreen()?.call(document);
            }

            return 1;
        }
    }
    catch
    {
        return 0;
    }
};

window.HybridJS.GetFullscreen = function()
{
    const canvas = HybridJS.GetCanvas();
    if (!canvas) return 0;
    
    return HybridJS.IsFullscreen(canvas) ? 1 : 0;
};
