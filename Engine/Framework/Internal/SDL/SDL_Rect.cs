using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Has Rect Intersection
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasRectIntersection(SDL.Rect* A, SDL.Rect* B);
    public static bool HasRectIntersection(SDL.Rect A, SDL.Rect B)
    {
        return SDL_HasRectIntersection(&A, &B);
    }
    
    // Get Rect Intersection
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRectIntersection(SDL.Rect* A, SDL.Rect* B, out SDL.Rect result);
    public static SDL.Rect GetRectIntersection(SDL.Rect A, SDL.Rect B)
    {
        SDL_GetRectIntersection(&A, &B, out SDL.Rect result);
        return result;
    }
}