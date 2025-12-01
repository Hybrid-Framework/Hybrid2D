window.Hybrid = window.Hybrid || {};

window.Hybrid.setFullscreen = function(value) 
{
    let elem = document.getElementById("canvas");
    if (!elem) return 0;

    try 
    {
        if (value)
        {
            elem.requestFullscreen?.() ||
            elem.webkitRequestFullscreen?.() ||
            elem.mozRequestFullScreen?.() ||
            elem.msRequestFullscreen?.();
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
