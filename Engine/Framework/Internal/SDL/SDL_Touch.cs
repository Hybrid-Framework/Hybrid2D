using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Touch Support
    public static bool TouchSupport()
    {
        foreach (var id in GetTouchDevices())
        {
            var touches = GetTouches((ulong)id);

            if (touches.Length > 0)
            {
                return true;
            }
        }
        
        return false;
    }
    
    // Get Touch Devices
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int* SDL_GetTouchDevices(out int count);
    public static int[] GetTouchDevices()
    {
        int* ptr = SDL_GetTouchDevices(out int count);

        if (ptr == null || count == 0)
        {
            return Array.Empty<int>();
        }

        int[] ids = new int[count];
        
        for (int i = 0; i < count; i++)
        {
            ids[i] = ptr[i];
        }

        SDL.Free((IntPtr)ptr);
        return ids;
    }
    
    // Get Touches
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Touch** SDL_GetTouchFingers(ulong touchID, out int count);
    public static SDL.Touch[] GetTouches(ulong touchID)
    {
        SDL.Touch** fingers = SDL_GetTouchFingers(touchID, out int count);

        if (fingers == null || count == 0)
        {
            return Array.Empty<SDL.Touch>();
        }

        SDL.Touch[] managed = new SDL.Touch[count];

        for (int i = 0; i < count; i++)
        {
            SDL.Touch* fingerPtr = fingers[i];
            managed[i] = *fingerPtr;
        }

        SDL.Free((IntPtr)fingers);
        return managed;
    }
}