using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Touch Support
    public static bool TouchSupport()
    {
        foreach (var id in GetTouchDevices())
        {
            var fingers = GetTouchFingers((ulong)id);
            if (fingers.Length > 0) return true;
        }
        
        return false;
    }
    
    // Get Touch Device Name From ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetTouchDeviceName(int id);
    public static string GetTouchDeviceNameFromID(int id)
    {
        return PtrToString(SDL_GetTouchDeviceName(id));
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
    private static extern SDL.Finger** SDL_GetTouchFingers(ulong touchID, out int count);
    public static SDL.Finger[] GetTouchFingers(ulong touchID)
    {
        SDL.Finger** fingers = SDL_GetTouchFingers(touchID, out int count);

        if (fingers == null || count == 0)
        {
            return Array.Empty<SDL.Finger>();
        }

        SDL.Finger[] managed = new SDL.Finger[count];

        for (int i = 0; i < count; i++)
        {
            SDL.Finger* fingerPtr = fingers[i];
            managed[i] = *fingerPtr;
        }

        SDL.Free((IntPtr)fingers);
        return managed;
    }
}