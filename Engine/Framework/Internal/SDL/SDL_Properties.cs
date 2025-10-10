using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Set Pointer Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetPointerProperty(uint props, byte* name, IntPtr value);
    public static void SetPointerProperty(uint props, string name, IntPtr value)
    {
        if (HasProperty(props, name))
        {
            var bytes = StringToUtf8(name);

            fixed (byte* utf8 = bytes)
            {
                SDL_SetPointerProperty(props, utf8, value);
            }
        }
    }
    
    // Get Pointer Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetPointerProperty(uint props, byte* name, IntPtr default_value);
    public static IntPtr GetPointerProperty(uint props, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetPointerProperty(props, utf8, IntPtr.Zero); // returns IntPtr.Zero on failed
        }
    }
    
    // Set String Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetStringProperty(uint props, byte* name, byte* value);
    public static void SetStringProperty(uint props, string name, string value)
    {
        if (HasProperty(props, name))
        {
            var nameBytes = StringToUtf8(name);
            var valueBytes = StringToUtf8(value);

            fixed (byte* nameUtf8 = nameBytes)
            fixed (byte* valueUtf8 = valueBytes)
            {
                SDL_SetStringProperty(props, nameUtf8, valueUtf8);
            }
        }
    }
    
    // Get String Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetStringProperty(uint props, byte* name, byte* default_value);
    public static string GetStringProperty(uint props, string name)
    {
        var nameBytes = StringToUtf8(name);
        var valueBytes = StringToUtf8(string.Empty); // returns string.Empty on failed

        fixed (byte* nameUtf8 = nameBytes)
        fixed (byte* valueUtf8 = valueBytes)
        {
            return Utf8ToString(SDL_GetStringProperty(props, nameUtf8, valueUtf8));
        }
    }
    
    // Set Number Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetNumberProperty(uint props, byte* name, long value);
    public static void SetNumberProperty(uint props, string name, long value)
    {
        if (HasProperty(props, name))
        {
            var bytes = StringToUtf8(name);

            fixed (byte* utf8 = bytes)
            {
                SDL_SetNumberProperty(props, utf8, value);
            }
        }
    }
    
    // Get Number Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long SDL_GetNumberProperty(uint props, byte* name, long default_value);
    public static long GetNumberProperty(uint props, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetNumberProperty(props, utf8, -1); // returns -1 on failed
        }
    }
    
    // Set Float Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetFloatProperty(uint props, byte* name, float value);
    public static void SetFloatProperty(uint props, string name, float value)
    {
        if (HasProperty(props, name))
        {
            var bytes = StringToUtf8(name);

            fixed (byte* utf8 = bytes)
            {
                SDL_SetFloatProperty(props, utf8, value);
            }
        }
    }
    
    // Get Float Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern float SDL_GetFloatProperty(uint props, byte* name, float default_value);
    public static float GetFloatProperty(uint props, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetFloatProperty(props, utf8, -1); // returns -1 on failed
        }
    }
    
    // Set Bool Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetBooleanProperty(uint props, byte* name, SDL.Bool value);
    public static void SetBooleanProperty(uint props, string name, bool value)
    {
        if (HasProperty(props, name))
        {
            var bytes = StringToUtf8(name);

            fixed (byte* utf8 = bytes)
            {
                SDL_SetBooleanProperty(props, utf8, value);
            }
        }
    }
    
    // Get Bool Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetBooleanProperty(uint props, byte* name, SDL.Bool default_value);
    public static bool GetBooleanProperty(uint props, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetBooleanProperty(props, utf8, false); // returns false on failed
        }
    }
    
    // Get Property Type
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.PropertyType SDL_GetPropertyType(uint props, byte* name);
    public static SDL.PropertyType GetPropertyType(uint props, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetPropertyType(props, utf8);
        }
    }
    
    // Clear Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ClearProperty(uint props, byte* name);
    public static void ClearProperty(uint props, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            SDL_ClearProperty(props, utf8);
        }
    }
    
    // Has Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasProperty(uint props, byte* name);
    public static bool HasProperty(uint props, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_HasProperty(props, utf8);
        }
    }
}