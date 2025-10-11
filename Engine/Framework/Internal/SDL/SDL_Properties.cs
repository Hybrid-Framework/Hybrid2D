using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Get Property Type
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.PropertyType SDL_GetPropertyType(uint properties, byte* name);
    public static SDL.PropertyType GetPropertyType(uint properties, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetPropertyType(properties, utf8);
        }
    }
    
    // Has Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasProperty(uint properties, byte* name);
    public static bool HasProperty(uint properties, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_HasProperty(properties, utf8);
        }
    }
    
    // Set Pointer Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetPointerProperty(uint properties, byte* name, IntPtr value);
    public static void SetPointerProperty(uint properties, string name, IntPtr value)
    {
        if (HasProperty(properties, name))
        {
            var bytes = StringToUtf8(name);

            fixed (byte* utf8 = bytes)
            {
                SDL_SetPointerProperty(properties, utf8, value);
            }
        }
    }
    
    // Get Pointer Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetPointerProperty(uint properties, byte* name, IntPtr default_value);
    public static IntPtr GetPointerProperty(uint properties, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetPointerProperty(properties, utf8, IntPtr.Zero); // returns null pointer on failed
        }
    }
    
    // Set String Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetStringProperty(uint properties, byte* name, byte* value);
    public static void SetStringProperty(uint properties, string name, string value)
    {
        if (HasProperty(properties, name))
        {
            var nameBytes = StringToUtf8(name);
            var valueBytes = StringToUtf8(value);

            fixed (byte* nameUtf8 = nameBytes)
            fixed (byte* valueUtf8 = valueBytes)
            {
                SDL_SetStringProperty(properties, nameUtf8, valueUtf8);
            }
        }
    }
    
    // Get String Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetStringProperty(uint properties, byte* name, byte* default_value);
    public static string GetStringProperty(uint properties, string name)
    {
        var nameBytes = StringToUtf8(name);
        var valueBytes = StringToUtf8(string.Empty); // returns empty on failed

        fixed (byte* nameUtf8 = nameBytes)
        fixed (byte* valueUtf8 = valueBytes)
        {
            return Utf8ToString(SDL_GetStringProperty(properties, nameUtf8, valueUtf8));
        }
    }
    
    // Set Number Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetNumberProperty(uint properties, byte* name, long value);
    public static void SetNumberProperty(uint properties, string name, long value)
    {
        if (HasProperty(properties, name))
        {
            var bytes = StringToUtf8(name);

            fixed (byte* utf8 = bytes)
            {
                SDL_SetNumberProperty(properties, utf8, value);
            }
        }
    }
    
    // Get Number Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long SDL_GetNumberProperty(uint properties, byte* name, long default_value);
    public static long GetNumberProperty(uint properties, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetNumberProperty(properties, utf8, 0); // returns 0 on failed
        }
    }
    
    // Set Float Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetFloatProperty(uint properties, byte* name, float value);
    public static void SetFloatProperty(uint properties, string name, float value)
    {
        if (HasProperty(properties, name))
        {
            var bytes = StringToUtf8(name);

            fixed (byte* utf8 = bytes)
            {
                SDL_SetFloatProperty(properties, utf8, value);
            }
        }
    }
    
    // Get Float Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern float SDL_GetFloatProperty(uint properties, byte* name, float default_value);
    public static float GetFloatProperty(uint properties, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetFloatProperty(properties, utf8, 0); // returns 0 on failed
        }
    }
    
    // Set Bool Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetBooleanProperty(uint properties, byte* name, SDL.Bool value);
    public static void SetBooleanProperty(uint properties, string name, bool value)
    {
        if (HasProperty(properties, name))
        {
            var bytes = StringToUtf8(name);

            fixed (byte* utf8 = bytes)
            {
                SDL_SetBooleanProperty(properties, utf8, value);
            }
        }
    }
    
    // Get Bool Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetBooleanProperty(uint properties, byte* name, SDL.Bool default_value);
    public static bool GetBooleanProperty(uint properties, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetBooleanProperty(properties, utf8, false); // returns false on failed
        }
    }
}