using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Create Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateRenderer(IntPtr window, byte* name);
    public static IntPtr CreateRenderer(IntPtr window, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_CreateRenderer(window, utf8);
        }
    }
    
    // Destroy Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyRenderer(IntPtr renderer);
    public static void DestroyRenderer(IntPtr renderer)
    {
        SDL_DestroyRenderer(renderer);
    }
    
    // Set Render Target
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderTarget(IntPtr renderer, IntPtr texture);
    public static bool SetRenderTarget(IntPtr renderer, IntPtr texture)
    {
        return SDL_SetRenderTarget(renderer, texture);
    }
    
    // Get Render Target
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetRenderTarget(IntPtr renderer);
    public static IntPtr GetRenderTarget(IntPtr renderer)
    {
        return SDL_GetRenderTarget(renderer);
    }
    
    // Set Render Logical Presentation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderLogicalPresentation(IntPtr renderer, int w, int h, SDL.Presentation presentation);
    public static bool SetRenderLogicalPresentation(IntPtr renderer, int w, int h, SDL.Presentation presentation)
    {
        return SDL_SetRenderLogicalPresentation(renderer, w, h, presentation);
    }
    
    // Get Render Logical Presentation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderLogicalPresentation(IntPtr renderer, out int w, out int h, out SDL.Presentation presentation);
    public static bool GetRenderLogicalPresentation(IntPtr renderer, out int w, out int h, out SDL.Presentation presentation)
    {
        return SDL_GetRenderLogicalPresentation(renderer, out w, out h, out presentation);
    }
    
    // Get Render Logical Presentation Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderLogicalPresentationRect(IntPtr renderer, out SDL.FRect rect);
    public static bool GetRenderLogicalPresentationRect(IntPtr renderer, out SDL.FRect rect)
    {
        return SDL_GetRenderLogicalPresentationRect(renderer, out rect);
    }
    
    // Set Render Viewport
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderViewport(IntPtr renderer, SDL.Rect* rect);
    public static bool SetRenderViewport(IntPtr renderer, SDL.Rect? rect)
    {
        SDL.Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_SetRenderViewport(renderer, rv);
    }
    
    // Get Render Viewport
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderViewport(IntPtr renderer, out SDL.Rect rect);
    public static bool GetRenderViewport(IntPtr renderer, out SDL.Rect rect)
    {
        return SDL_GetRenderViewport(renderer, out rect);
    }
    
    // Render Viewport Set
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderViewportSet(IntPtr renderer);
    public static bool RenderViewportSet(IntPtr renderer)
    {
        return SDL_RenderViewportSet(renderer);
    }
    
    // Set Render Clip Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderClipRect(IntPtr renderer, SDL.Rect* rect);
    public static bool SetRenderClipRect(IntPtr renderer, SDL.Rect? rect)
    {
        SDL.Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_SetRenderClipRect(renderer, rv);
    }
    
    // Get Render Clip Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderClipRect(IntPtr renderer, out SDL.Rect rect);
    public static bool GetRenderClipRect(IntPtr renderer, out SDL.Rect rect)
    {
        return SDL_GetRenderClipRect(renderer, out rect);
    }
    
    // Render Clip Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderClipEnabled(IntPtr renderer);
    public static bool RenderClipEnabled(IntPtr renderer)
    {
        return SDL_RenderClipEnabled(renderer);
    }
    
    // Set Render Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderScale(IntPtr renderer, float x, float y);
    public static bool SetRenderScale(IntPtr renderer, float x, float y)
    {
        return SDL_SetRenderScale(renderer, x, y);
    }
    
    // Get Render Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderScale(IntPtr renderer, out float x, out float y);
    public static bool GetRenderScale(IntPtr renderer, out float x, out float y)
    {
        return SDL_GetRenderScale(renderer, out x, out y);
    }
    
    // Set Render VSync
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderVSync(IntPtr renderer, int vsync);
    public static bool SetRenderVSync(IntPtr renderer, int vsync)
    {
        return SDL_SetRenderVSync(renderer, vsync);
    }
    
    // Get Render VSync
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderVSync(IntPtr renderer, out int vsync);
    public static bool GetRenderVSync(IntPtr renderer, out int vsync)
    {
        return SDL_GetRenderVSync(renderer, out vsync);
    }
    
    // Set Render Color Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderColorScale(IntPtr renderer, float scale);
    public static bool SetRenderColorScale(IntPtr renderer, float scale)
    {
        return SDL_SetRenderColorScale(renderer, scale);
    }
    
    // Get Render Color Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderColorScale(IntPtr renderer, out float scale);
    public static bool GetRenderColorScale(IntPtr renderer, out float scale)
    {
        return SDL_GetRenderColorScale(renderer, out scale);
    }
    
    // Set Render Draw Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderDrawBlendMode(IntPtr renderer, SDL.BlendMode mode);
    public static bool SetRenderDrawBlendMode(IntPtr renderer, SDL.BlendMode mode)
    {
        return SDL_SetRenderDrawBlendMode(renderer, mode);
    }
    
    // Get Render Draw Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderDrawBlendMode(IntPtr renderer, out SDL.BlendMode mode);
    public static bool GetRenderDrawBlendMode(IntPtr renderer, out SDL.BlendMode mode)
    {
        return SDL_GetRenderDrawBlendMode(renderer, out mode);
    }
    
    // Set Render Draw Color
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);
    public static bool SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a)
    {
        return SDL_SetRenderDrawColor(renderer, r, g, b, a);
    }
    
    // Get Render Draw Color
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a);
    public static bool GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a)
    {
        return SDL_GetRenderDrawColor(renderer, out r, out g, out b, out a);
    }
    
    // Render Point
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderPoint(IntPtr renderer, float x, float y);
    public static bool RenderPoint(IntPtr renderer, float x, float y)
    {
        return SDL_RenderPoint(renderer, x, y);
    }

    // Render Points
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderPoints(IntPtr renderer, SDL.FPoint[] points, int count);
    public static bool RenderPoints(IntPtr renderer, SDL.FPoint[] points, int count)
    {
        return SDL_RenderPoints(renderer, points, count);
    }
    
    // Render Line
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderLine(IntPtr renderer, float x1, float y1, float x2, float y2);
    public static bool RenderLine(IntPtr renderer, float x1, float y1, float x2, float y2)
    {
        return SDL_RenderLine(renderer, x1, y1, x2, y2);
    }
    
    // Render Lines
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderLines(IntPtr renderer, SDL.FPoint[] points, int count);
    public static bool RenderLines(IntPtr renderer, SDL.FPoint[] points, int count)
    {
        return SDL_RenderLines(renderer, points, count);
    }
    
    // Render Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderRect(IntPtr renderer, SDL.FRect* rect);
    public static bool RenderRect(IntPtr renderer, SDL.FRect? rect)
    {
        SDL.FRect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_RenderRect(renderer, rv);
    }
    
    // Render Rects
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderRects(IntPtr renderer, SDL.FRect[] rects, int count);
    public static bool RenderRects(IntPtr renderer, SDL.FRect[] rects, int count)
    {
        return SDL_RenderRects(renderer, rects, count);
    }
    
    // Render Fill Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderFillRect(IntPtr renderer, SDL.FRect* rect);
    public static bool RenderFillRect(IntPtr renderer, SDL.FRect? rect)
    {
        SDL.FRect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_RenderFillRect(renderer, rv);
    }
    
    // Render Fill Rects
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderFillRects(IntPtr renderer, SDL.FRect[] rects, int count);
    public static bool RenderFillRects(IntPtr renderer, SDL.FRect[] rects, int count)
    {
        return SDL_RenderFillRects(renderer, rects, count);
    }
    
    // Render Geometry
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderGeometry(IntPtr renderer, IntPtr texture, SDL.Vertex[] vertices, int verticesCount, int[] indices, int indicesCount);
    public static bool RenderGeometry(IntPtr renderer, IntPtr texture, SDL.Vertex[] vertices, int verticesCount, int[] indices, int indicesCount)
    {
        return SDL_RenderGeometry(renderer, texture, vertices, verticesCount, indices, indicesCount);
    }
    
    // Render Read Pixels
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_RenderReadPixels(IntPtr renderer, SDL.Rect* rect);
    public static IntPtr RenderReadPixels(IntPtr renderer, SDL.Rect? rect)
    {
        SDL.Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_RenderReadPixels(renderer, rv);
    }
    
    // Get Render Output Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderOutputSize(IntPtr renderer, out int w, out int h);
    public static bool GetRenderOutputSize(IntPtr renderer, out int w, out int h)
    {
        return SDL_GetRenderOutputSize(renderer, out w, out h);
    }
    
    // Get Current Render Output Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetCurrentRenderOutputSize(IntPtr renderer, out int w, out int h);
    public static bool GetCurrentRenderOutputSize(IntPtr renderer, out int w, out int h)
    {
        return SDL_GetCurrentRenderOutputSize(renderer, out w, out h);
    }
    
    // Get Render Safe Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderSafeArea(IntPtr renderer, out SDL.Rect rect);
    public static bool GetRenderSafeArea(IntPtr renderer, out SDL.Rect rect)
    {
        return SDL_GetRenderSafeArea(renderer, out rect);
    }
    
    // Render Clear
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderClear(IntPtr renderer);
    public static bool RenderClear(IntPtr renderer)
    {
        return SDL_RenderClear(renderer);
    }
    
    // Render Present
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderPresent(IntPtr renderer);
    public static bool RenderPresent(IntPtr renderer)
    {
        return SDL_RenderPresent(renderer);
    }
}