window.HybridJS = window.HybridJS || {};

window.HybridJS.GetCanvas = function() 
{
    return document.getElementById("canvas");
};

window.HybridJS.GetDocument = function() 
{
    return document.documentElement;
};

window.HybridJS.GetCanvasWidth = function() 
{
    const canvas = HybridJS.GetCanvas();
    return canvas ? canvas.width : 0;
};

window.HybridJS.GetCanvasHeight = function() 
{
    const canvas = HybridJS.GetCanvas();
    return canvas ? canvas.height : 0;
};

window.HybridJS.GetDocumentWidth = function()
{
    const document = HybridJS.GetDocument();
    return document ? document.clientWidth : 0;
};

window.HybridJS.GetDocumentHeight = function()
{
    const document = HybridJS.GetDocument();
    return document ? document.clientHeight : 0;
};

window.HybridJS.FillDocument = function()
{
    const canvas = HybridJS.GetCanvas();
    if (!canvas) return;

    const width = HybridJS.GetDocumentWidth();
    const height = HybridJS.GetDocumentHeight();

    canvas.width = width;
    canvas.height = height;
    canvas.style.width = width + 'px';
    canvas.style.height = height + 'px';
};

window.HybridJS.IsFillDocument = function(tolerance = 1) 
{
    const canvas = HybridJS.GetCanvas();
    if (!canvas) return 0;

    const document = HybridJS.GetDocument();
    if (!document) return 0;
    
    const width = document.clientWidth;
    const height = document.clientHeight;

    const canvasWidth = canvas.width;
    const canvasHeight = canvas.height;
    const dpi = window.devicePixelRatio || 1;

    const bufferWidth = Math.round(width * dpi);
    const bufferHeight = Math.round(height * dpi);

    const bufferCheck = Math.abs(canvasWidth - bufferWidth) <= tolerance && Math.abs(canvasHeight - bufferHeight) <= tolerance;
    const documentCheck = Math.abs(canvasWidth - width) <= tolerance && Math.abs(canvasHeight - height) <= tolerance;

    return (bufferCheck || documentCheck) ? 1 : 0;
};
