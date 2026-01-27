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