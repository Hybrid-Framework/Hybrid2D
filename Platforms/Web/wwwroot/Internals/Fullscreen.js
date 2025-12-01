window.Hybrid = window.Hybrid || {};

window.Hybrid.setFullscreen = function(value) 
{
    let element = document.getElementById("canvas");
    if (!element) return 0;

    try 
    {
        if (value)
        {
            element.requestFullscreen?.() ||
            element.webkitRequestFullscreen?.() ||
            element.mozRequestFullScreen?.() ||
            element.msRequestFullscreen?.();
        }
        else
        {
            document.exitFullscreen?.() ||
            document.webkitExitFullscreen?.() ||
            document.mozCancelFullScreen?.() ||
            document.msExitFullscreen?.();
        }
    }
    catch(e)
    {
        return 0;
    }

    return 1;
};

window.Hybrid.getFullscreen = function() 
{
    return document.fullscreenElement || document.webkitFullscreenElement || document.mozFullScreenElement || document.msFullscreenElement ? 1 : 0;
};
