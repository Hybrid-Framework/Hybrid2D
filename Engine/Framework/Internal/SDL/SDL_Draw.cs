using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Set Render Draw Color
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderDrawColor(SDL.Renderer* renderer, byte r, byte g, byte b, byte a);
    public static bool SetRenderDrawColor(SDL.Renderer* renderer, byte r, byte g, byte b, byte a)
    {
        return SDL_SetRenderDrawColor(renderer, r, g, b, a);
    }
    
    // Get Render Draw Color
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderDrawColor(SDL.Renderer* renderer, out byte r, out byte g, out byte b, out byte a);
    public static bool GetRenderDrawColor(SDL.Renderer* renderer, out byte r, out byte g, out byte b, out byte a)
    {
        return SDL_GetRenderDrawColor(renderer, out r, out g, out b, out a);
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
    
    // Render Read Pixels
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* SDL_RenderReadPixels(SDL.Renderer* renderer, ref SDL.Rect rect);
    public static SDL.Surface* RenderReadPixels(SDL.Renderer* renderer, ref SDL.Rect rect)
    {
        return SDL_RenderReadPixels(renderer, ref rect);
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
    private static extern SDL.Bool SDL_RenderPoints(SDL.Renderer* renderer, SDL.FPoint[] points, int count);
    public static bool RenderPoints(SDL.Renderer* renderer, SDL.FPoint[] points, int count)
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
    private static extern SDL.Bool SDL_RenderLines(SDL.Renderer* renderer, SDL.FPoint[] points, int count);
    public static bool RenderLines(SDL.Renderer* renderer, SDL.FPoint[] points, int count)
    {
        return SDL_RenderLines(renderer, points, count);
    }
    
    // Render Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderRect(SDL.Renderer* renderer, ref SDL.FRect rect);
    public static bool RenderRect(SDL.Renderer* renderer, ref SDL.FRect rect)
    {
        return SDL_RenderRect(renderer, ref rect);
    }
    
    // Render Rects
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderRects(SDL.Renderer* renderer, SDL.FRect[] rects, int count);
    public static bool RenderRects(SDL.Renderer* renderer, SDL.FRect[] rects, int count)
    {
        return SDL_RenderRects(renderer, rects, count);
    }
    
    // Render Fill Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderFillRect(SDL.Renderer* renderer, ref SDL.FRect rect);
    public static bool RenderFillRect(SDL.Renderer* renderer, ref SDL.FRect rect)
    {
        return SDL_RenderFillRect(renderer, ref rect);
    }
    
    // Render Fill Rects
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderFillRects(SDL.Renderer* renderer, SDL.FRect[] rects, int count);
    public static bool RenderFillRects(SDL.Renderer* renderer, SDL.FRect[] rects, int count)
    {
        return SDL_RenderFillRects(renderer, rects, count);
    }
    
    // Render Geometry
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderGeometry(SDL.Renderer* renderer, SDL.Texture* texture, SDL.Vertex[] vertices, int verticesCount, int[] indices, int indicesCount);
    public static bool RenderGeometry(SDL.Renderer* renderer, SDL.Texture* texture, SDL.Vertex[] vertices, int verticesCount, int[] indices, int indicesCount)
    {
        return SDL_RenderGeometry(renderer, texture, vertices, verticesCount, indices, indicesCount);
    }
}