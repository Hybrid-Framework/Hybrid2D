using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Renderer
    private static IntPtr Renderer;
    public static IntPtr GetRenderer()
    {
        return Renderer;
    }
    
    
    // Create Window & Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_CreateWindowAndRenderer(byte* title, int w, int h, SDL.WindowFlags flags, out IntPtr window, out IntPtr renderer);
    public static void CreateWindowAndRenderer(string title, int w, int h, SDL.WindowFlags flags)
    {
        var bytes = StringToUtf8(title);

        fixed (byte* utf8 = bytes)
        {
            DestroyWindow();
            DestroyRenderer();
            SDL_CreateWindowAndRenderer(utf8, w, h, flags, out Window, out Renderer);
        }
    }
    
    // Create Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateRenderer(IntPtr window, byte* name);
    public static void CreateRenderer()
    {
        DestroyRenderer();
        Renderer = SDL_CreateRenderer(GetWindow(), null);
    }
    
    // Destroy Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyRenderer(IntPtr renderer);
    public static void DestroyRenderer()
    {
        if (Renderer != IntPtr.Zero)
        {
            SDL_DestroyRenderer(GetRenderer());
            Renderer = IntPtr.Zero;
        }
    }
    
    // Set Render Logical Presentation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderLogicalPresentation(IntPtr renderer, int w, int h, SDL.RendererLogicalPresentation mode);
    public static void SetRenderLogicalPresentation(int w, int h, SDL.RendererLogicalPresentation mode)
    {
        SDL_SetRenderLogicalPresentation(GetRenderer(), w, h, mode);
    }
    
    // Get Render Logical Presentation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderLogicalPresentation(IntPtr renderer, out int w, out int h, out SDL.RendererLogicalPresentation mode);
    public static (int w, int h, SDL.RendererLogicalPresentation mode) GetRenderLogicalPresentation()
    {
        SDL_GetRenderLogicalPresentation(GetRenderer(), out int w, out int h, out SDL.RendererLogicalPresentation mode);
        return (w, h, mode);
    }
    
    // Set Render Viewport
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderViewport(IntPtr renderer, SDL.Rect* rect);
    public static void SetRenderViewport(SDL.Rect rect)
    {
        SDL_SetRenderViewport(GetRenderer(), &rect);
    }
    
    // Get Render Viewport
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderViewport(IntPtr renderer, out SDL.Rect rect);
    public static SDL.Rect GetRenderViewport()
    {
        SDL_GetRenderViewport(GetRenderer(), out SDL.Rect rect);
        return rect;
    }
    
    // Set Render Clip Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderClipRect(IntPtr renderer, SDL.Rect* rect);
    public static void SetRenderClipRect(SDL.Rect rect)
    {
        SDL_SetRenderClipRect(GetRenderer(), &rect);
    }
    
    // Get Render Clip Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderClipRect(IntPtr renderer, out SDL.Rect rect);
    public static SDL.Rect GetRenderClipRect()
    {
        SDL_GetRenderClipRect(GetRenderer(), out SDL.Rect rect);
        return rect;
    }
    
    // Set Render Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderScale(IntPtr renderer, float x, float y);
    public static void SetRenderScale(float x, float y)
    {
        SDL_SetRenderScale(GetRenderer(), x, y);
    }
    
    // Get Render Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderScale(IntPtr renderer, out float x, out float y);
    public static (float x, float y) GetRenderScale()
    {
        SDL_GetRenderScale(GetRenderer(), out float x, out float y);
        return (x, y);
    }
    
    // Set Render VSync
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderVSync(IntPtr renderer, int vsync);
    public static void SetRenderVSync(int vsync)
    {
        SDL_SetRenderVSync(GetRenderer(), vsync);
    }
    
    // Get Render Vsync
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderVSync(IntPtr renderer, out int vsync);
    public static int GetRenderVSync()
    {
        SDL_GetRenderVSync(GetRenderer(), out int vsync);
        return vsync;
    }
    
    // Set Render Draw Color
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);
    public static void SetRenderDrawColor(byte r, byte g, byte b, byte a)
    {
        SDL_SetRenderDrawColor(GetRenderer(), r, g, b, a);
    }
    
    // Render Clear
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderClear(IntPtr renderer);
    public static void RenderClear()
    {
        SDL_RenderClear(GetRenderer());
    }
    
    // Render Present
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderPresent(IntPtr renderer);
    public static void RenderPresent()
    {
        SDL_RenderPresent(GetRenderer());
    }
    
    // Render Point
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderPoint(IntPtr renderer, float x, float y);
    public static void RenderPoint(SDL.FPoint point)
    {
        SDL_RenderPoint(GetRenderer(), point.x, point.y);
    }
    
    // Render Points
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderPoints(IntPtr renderer, SDL.FPoint[] points, int count);
    public static void RenderPoints(SDL.FPoint[] points)
    {
        SDL_RenderPoints(GetRenderer(), points, points.Length);
    }
    
    // Render Line
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderLine(IntPtr renderer, float x1, float y1, float x2, float y2);
    public static void RenderLine(SDL.FPoint A, SDL.FPoint B)
    {
        SDL_RenderLine(GetRenderer(), A.x, A.y, B.x, B.y);
    }
    
    // Render Lines
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderLines(IntPtr renderer, SDL.FPoint[] points, int count);
    public static void RenderLines(SDL.FPoint[] points)
    {
        SDL_RenderLines(GetRenderer(), points, points.Length);
    }
    
    // Render Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderRect(IntPtr renderer, SDL.FRect* rect);
    public static void RenderRect(SDL.FRect rect)
    {
        SDL_RenderRect(GetRenderer(), &rect);
    }
    
    // Render Rects
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderRects(IntPtr renderer, SDL.FRect[] rects, int count);
    public static void RenderRects(SDL.FRect[] rects)
    {
        SDL_RenderRects(GetRenderer(), rects, rects.Length);
    }
    
    // Render Fill Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderFillRect(IntPtr renderer, SDL.FRect* rect);
    public static void RenderFillRect(SDL.FRect rect)
    {
        SDL_RenderFillRect(GetRenderer(), &rect);
    }
    
    // Render Fill Rects
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderFillRects(IntPtr renderer, SDL.FRect[] rects, int count);
    public static void RenderFillRects(SDL.FRect[] rects)
    {
        SDL_RenderFillRects(GetRenderer(), rects, rects.Length);
    }
    
    // Render Geometry
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderGeometry(IntPtr renderer, IntPtr texture, SDL_Vertex[] vertices, int verticesCount, int[] indices, int indicesCount);
    public static void RenderGeometry(IntPtr texture, SDL_Vertex[] vertices, int[] indices)
    {
        SDL_RenderGeometry(GetRenderer(), texture, vertices, vertices.Length, indices, indices.Length);
    }
    
    // Get Render Output Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderOutputSize(IntPtr renderer, out int w, out int h);
    public static (int w, int h) GetRenderOutputSize()
    {
        SDL_GetRenderOutputSize(GetRenderer(), out int w, out int h);
        return (w, h);
    }
    
    // Get Render Safe Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderSafeArea(IntPtr renderer, out SDL.Rect rect);
    public static SDL.Rect GetRenderSafeArea()
    {
        SDL_GetRenderSafeArea(GetRenderer(), out SDL.Rect rect);
        return rect;
    }
    
    // Render Clip Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderClipEnabled(IntPtr renderer);
    public static bool RenderClipEnabled()
    {
        return SDL_RenderClipEnabled(GetRenderer());
    }
    
    // Render Debug Text
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderDebugText(IntPtr renderer, float x, float y, byte* str);
    public static void RenderDebugText(float x, float y, string text)
    {
        var bytes = StringToUtf8(text);

        fixed (byte* utf8 = bytes)
        {
            SDL_RenderDebugText(GetRenderer(), x, y, utf8);
        }
    }
}