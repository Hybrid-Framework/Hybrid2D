window.Hybrid = window.Hybrid || {};

window.Hybrid.fillDocument = function() 
{
    const canvas = document.getElementById('canvas');
    if (!canvas) return;

    const width = document.documentElement.clientWidth;
    const height = document.documentElement.clientHeight;

    canvas.width = width;
    canvas.height = height;
    canvas.style.width = width + 'px';
    canvas.style.height = height + 'px';
};

window.Hybrid.getWidth = function() 
{
    const canvas = document.getElementById('canvas');
    return canvas ? canvas.width : 0;
};

window.Hybrid.getHeight = function() 
{
    const canvas = document.getElementById('canvas');
    return canvas ? canvas.height : 0;
};