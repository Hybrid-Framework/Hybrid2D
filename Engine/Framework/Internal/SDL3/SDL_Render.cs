using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Create Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Renderer* SDL_CreateRenderer(SDL.Window* window, byte* name);
    public static SDL.Renderer* CreateRenderer(SDL.Window* window, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_CreateRenderer(window, utf8);
        }
    }
    
    // Destroy Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyRenderer(SDL.Renderer* renderer);
    public static void DestroyRenderer(SDL.Renderer* renderer)
    {
        SDL_DestroyRenderer(renderer);
    }
    
    // Set Render Target
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderTarget(SDL.Renderer* renderer, SDL.Texture* texture);
    public static bool SetRenderTarget(SDL.Renderer* renderer, SDL.Texture* texture)
    {
        return SDL_SetRenderTarget(renderer, texture);
    }
    
    // Get Render Target
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Texture* SDL_GetRenderTarget(SDL.Renderer* renderer);
    public static SDL.Texture* GetRenderTarget(SDL.Renderer* renderer)
    {
        return SDL_GetRenderTarget(renderer);
    }
    
    // Set Render Logical Presentation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderLogicalPresentation(SDL.Renderer* renderer, int w, int h, SDL.Presentation presentation);
    public static bool SetRenderLogicalPresentation(SDL.Renderer* renderer, int w, int h, SDL.Presentation presentation)
    {
        return SDL_SetRenderLogicalPresentation(renderer, w, h, presentation);
    }
    
    // Get Render Logical Presentation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderLogicalPresentation(SDL.Renderer* renderer, out int w, out int h, out SDL.Presentation presentation);
    public static bool GetRenderLogicalPresentation(SDL.Renderer* renderer, out int w, out int h, out SDL.Presentation presentation)
    {
        return SDL_GetRenderLogicalPresentation(renderer, out w, out h, out presentation);
    }
    
    // Get Render Logical Presentation Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderLogicalPresentationRect(SDL.Renderer* renderer, out Rect rect);
    public static bool GetRenderLogicalPresentationRect(SDL.Renderer* renderer, out Rect rect)
    {
        return SDL_GetRenderLogicalPresentationRect(renderer, out rect);
    }
    
    // Set Render Viewport
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderViewport(SDL.Renderer* renderer, RectInt* rect);
    public static bool SetRenderViewport(SDL.Renderer* renderer, RectInt? rect)
    {
        RectInt r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_SetRenderViewport(renderer, rv);
    }
    
    // Get Render Viewport
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderViewport(SDL.Renderer* renderer, out RectInt rect);
    public static bool GetRenderViewport(SDL.Renderer* renderer, out RectInt rect)
    {
        return SDL_GetRenderViewport(renderer, out rect);
    }
    
    // Render Viewport Set
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderViewportSet(SDL.Renderer* renderer);
    public static bool RenderViewportSet(SDL.Renderer* renderer)
    {
        return SDL_RenderViewportSet(renderer);
    }
    
    // Set Render Clip Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderClipRect(SDL.Renderer* renderer, RectInt* rect);
    public static bool SetRenderClipRect(SDL.Renderer* renderer, RectInt? rect)
    {
        RectInt r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_SetRenderClipRect(renderer, rv);
    }
    
    // Get Render Clip Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderClipRect(SDL.Renderer* renderer, out RectInt rect);
    public static bool GetRenderClipRect(SDL.Renderer* renderer, out RectInt rect)
    {
        return SDL_GetRenderClipRect(renderer, out rect);
    }
    
    // Render Clip Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderClipEnabled(SDL.Renderer* renderer);
    public static bool RenderClipEnabled(SDL.Renderer* renderer)
    {
        return SDL_RenderClipEnabled(renderer);
    }
    
    // Set Render Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderScale(SDL.Renderer* renderer, float x, float y);
    public static bool SetRenderScale(SDL.Renderer* renderer, float x, float y)
    {
        return SDL_SetRenderScale(renderer, x, y);
    }
    
    // Get Render Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderScale(SDL.Renderer* renderer, out float x, out float y);
    public static bool GetRenderScale(SDL.Renderer* renderer, out float x, out float y)
    {
        return SDL_GetRenderScale(renderer, out x, out y);
    }
    
    // Set Render VSync
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderVSync(SDL.Renderer* renderer, int vsync);
    public static bool SetRenderVSync(SDL.Renderer* renderer, int vsync)
    {
        return SDL_SetRenderVSync(renderer, vsync);
    }
    
    // Get Render VSync
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderVSync(SDL.Renderer* renderer, out int vsync);
    public static bool GetRenderVSync(SDL.Renderer* renderer, out int vsync)
    {
        return SDL_GetRenderVSync(renderer, out vsync);
    }
    
    // Set Render Color Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderColorScale(SDL.Renderer* renderer, float scale);
    public static bool SetRenderColorScale(SDL.Renderer* renderer, float scale)
    {
        return SDL_SetRenderColorScale(renderer, scale);
    }
    
    // Get Render Color Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderColorScale(SDL.Renderer* renderer, out float scale);
    public static bool GetRenderColorScale(SDL.Renderer* renderer, out float scale)
    {
        return SDL_GetRenderColorScale(renderer, out scale);
    }
    
    // Set Render Draw Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderDrawBlendMode(SDL.Renderer* renderer, SDL.BlendMode mode);
    public static bool SetRenderDrawBlendMode(SDL.Renderer* renderer, SDL.BlendMode mode)
    {
        return SDL_SetRenderDrawBlendMode(renderer, mode);
    }
    
    // Get Render Draw Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderDrawBlendMode(SDL.Renderer* renderer, out SDL.BlendMode mode);
    public static bool GetRenderDrawBlendMode(SDL.Renderer* renderer, out SDL.BlendMode mode)
    {
        return SDL_GetRenderDrawBlendMode(renderer, out mode);
    }
    
    // Set Render Draw Color
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    
    // Set Render Draw Color (r,g,b,a)
    private static extern SDL.Bool SDL_SetRenderDrawColor(SDL.Renderer* renderer, byte r, byte g, byte b, byte a);
    public static bool SetRenderDrawColor(SDL.Renderer* renderer, byte r, byte g, byte b, byte a)
    {
        return SDL_SetRenderDrawColor(renderer, r, g, b, a);
    }
    
    // Set Render Draw Color (Color32)
    public static bool SetRenderDrawColor(SDL.Renderer* renderer, Color32 color)
    {
        return SDL_SetRenderDrawColor(renderer, color.r, color.g, color.b, color.a);
    }
    
    // Get Render Draw Color
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderDrawColor(SDL.Renderer* renderer, out byte r, out byte g, out byte b, out byte a);
    public static bool GetRenderDrawColor(SDL.Renderer* renderer, out byte r, out byte g, out byte b, out byte a)
    {
        return SDL_GetRenderDrawColor(renderer, out r, out g, out b, out a);
    }
    
    // Render Point
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderPoint(SDL.Renderer* renderer, float x, float y);
    public static bool RenderPoint(SDL.Renderer* renderer, float x, float y)
    {
        return SDL_RenderPoint(renderer, x, y);
    }

    // Render Points
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderPoints(SDL.Renderer* renderer, Point[] points, int count);
    public static bool RenderPoints(SDL.Renderer* renderer, Point[] points, int count)
    {
        return SDL_RenderPoints(renderer, points, count);
    }
    
    // Render Line
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderLine(SDL.Renderer* renderer, float x1, float y1, float x2, float y2);
    public static bool RenderLine(SDL.Renderer* renderer, float x1, float y1, float x2, float y2)
    {
        return SDL_RenderLine(renderer, x1, y1, x2, y2);
    }
    
    // Render Lines
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderLines(SDL.Renderer* renderer, Point[] points, int count);
    public static bool RenderLines(SDL.Renderer* renderer, Point[] points, int count)
    {
        return SDL_RenderLines(renderer, points, count);
    }
    
    // Render Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderRect(SDL.Renderer* renderer, Rect* rect);
    public static bool RenderRect(SDL.Renderer* renderer, Rect? rect)
    {
        Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_RenderRect(renderer, rv);
    }
    
    // Render Rects
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderRects(SDL.Renderer* renderer, Rect[] rects, int count);
    public static bool RenderRects(SDL.Renderer* renderer, Rect[] rects, int count)
    {
        return SDL_RenderRects(renderer, rects, count);
    }
    
    // Render Fill Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderFillRect(SDL.Renderer* renderer, Rect* rect);
    public static bool RenderFillRect(SDL.Renderer* renderer, Rect? rect)
    {
        Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_RenderFillRect(renderer, rv);
    }
    
    // Render Fill Rects
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderFillRects(SDL.Renderer* renderer, Rect[] rects, int count);
    public static bool RenderFillRects(SDL.Renderer* renderer, Rect[] rects, int count)
    {
        return SDL_RenderFillRects(renderer, rects, count);
    }
    
    // Render Read Pixels
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* SDL_RenderReadPixels(SDL.Renderer* renderer, RectInt* rect);
    public static SDL.Surface* RenderReadPixels(SDL.Renderer* renderer, RectInt? rect)
    {
        RectInt r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_RenderReadPixels(renderer, rv);
    }
    
    // Get Render Output Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderOutputSize(SDL.Renderer* renderer, out int w, out int h);
    public static bool GetRenderOutputSize(SDL.Renderer* renderer, out int w, out int h)
    {
        return SDL_GetRenderOutputSize(renderer, out w, out h);
    }
    
    // Get Current Render Output Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetCurrentRenderOutputSize(SDL.Renderer* renderer, out int w, out int h);
    public static bool GetCurrentRenderOutputSize(SDL.Renderer* renderer, out int w, out int h)
    {
        return SDL_GetCurrentRenderOutputSize(renderer, out w, out h);
    }
    
    // Get Render Safe Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderSafeArea(SDL.Renderer* renderer, out RectInt rect);
    public static bool GetRenderSafeArea(SDL.Renderer* renderer, out RectInt rect)
    {
        return SDL_GetRenderSafeArea(renderer, out rect);
    }
    
    // Render Clear
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderClear(SDL.Renderer* renderer);
    public static bool RenderClear(SDL.Renderer* renderer)
    {
        return SDL_RenderClear(renderer);
    }
    
    // Render Present
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderPresent(SDL.Renderer* renderer);
    public static bool RenderPresent(SDL.Renderer* renderer)
    {
        return SDL_RenderPresent(renderer);
    }
    
    // Get Renderer Name
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetRendererName(SDL.Renderer* renderer);
    public static string GetRendererName(SDL.Renderer* renderer)
    {
        return Utf8ToString(SDL_GetRendererName(renderer));
    }
    
    // Render Debug Text
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderDebugText(SDL.Renderer* renderer, float x, float y, byte* text);
    public static bool RenderDebugText(SDL.Renderer* renderer, float x, float y, string text)
    {
        var bytes = StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            return SDL_RenderDebugText(renderer, x, y, utf8);
        }
    }
    
    // Render Geometry Raw
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderGeometryRaw(SDL.Renderer* renderer, SDL.Texture* texture, float* xy, int xy_stride, Hybrid.Color* color, int color_stride, float* uv, int uv_stride, int num_vertices, void* indices, int num_indices, int size_indices);
    
    // Render Geometry float[]
    public static bool RenderGeometryRaw(SDL.Renderer* renderer, SDL.Texture* texture, float[] positions, Hybrid.Color[] colors, float[] uvs, int[] indices)
    {
        int numVertices = positions.Length / 2;
        int xyStride = sizeof(float) * 2;
        int colorStride = sizeof(Color);
        int uvStride = sizeof(float) * 2;
        int sizeIndices = sizeof(int);

        fixed (float* xyPtr = positions)
        fixed (Hybrid.Color* colorPtr = colors)
        fixed (float* uvPtr = uvs)
        fixed (int* indicesPtr = indices)
        {
            return SDL_RenderGeometryRaw
            (
                renderer, texture, xyPtr, xyStride, colorPtr, colorStride, uvPtr, uvStride, numVertices, indicesPtr, indices.Length, sizeIndices
            );
        }
    }
    
    // Render Geometry Point[]
    public static bool RenderGeometryRaw(SDL.Renderer* renderer, SDL.Texture* texture, Hybrid.Point[] positions, Hybrid.Color[] colors, Hybrid.Point[] uvs, int[] indices)
    {
        int numVertices = positions.Length;
        int xyStride = sizeof(Point);
        int colorStride = sizeof(Hybrid.Color);
        int uvStride = sizeof(Point);
        int sizeIndices = sizeof(int);

        fixed (Hybrid.Point* posPtr = positions)
        fixed (Hybrid.Color* colorPtr = colors)
        fixed (Hybrid.Point* uvPtr = uvs)
        fixed (int* indicesPtr = indices)
        {
            return SDL_RenderGeometryRaw
            (
                renderer, texture, (float*)posPtr, xyStride, colorPtr, colorStride, (float*)uvPtr, uvStride, numVertices, indicesPtr, indices.Length, sizeIndices
            );
        }
    }
}