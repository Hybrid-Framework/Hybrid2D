using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Create Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_CreateProperties();
    public static uint CreateProperties()
    {
        return SDL_CreateProperties();
    }
    
    // Destroy Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyProperties(uint props);
    public static void DestroyProperties(uint props)
    {
        SDL_DestroyProperties(props);
    }
    
    // Set Pointer Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetPointerProperty(uint property, byte* name, IntPtr value);
    public static bool SetPointerProperty(uint property, string name, IntPtr value)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_SetPointerProperty(property, utf8, value);
        }
    }
    
    // Get Pointer Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetPointerProperty(uint property, byte* name, IntPtr default_value);
    public static IntPtr GetPointerProperty(uint property, string name, IntPtr default_value)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetPointerProperty(property, utf8, default_value);
        }
    }
    
    // Set String Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetStringProperty(uint property, byte* name, byte* value);
    public static bool SetStringProperty(uint property, string name, string value)
    {
        var bytes = StringToUtf8(name);
        var bytesValue = StringToUtf8(value);

        fixed (byte* utf8 = bytes)
        fixed (byte* utf8Value = bytesValue)
        {
            return SDL_SetStringProperty(property, utf8, utf8Value);
        }
    }
    
    // Get String Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetStringProperty(uint property, byte* name, byte* default_value);
    public static string GetStringProperty(uint property, string name, string default_value)
    {
        var bytes = StringToUtf8(name);
        var bytesValue = StringToUtf8(default_value);

        fixed (byte* utf8 = bytes)
        fixed (byte* utf8Value = bytesValue)
        {
            return Utf8ToString(SDL_GetStringProperty(property, utf8, utf8Value));
        }
    }
    
    // Set Number Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetNumberProperty(uint property, byte* name, long value);
    public static bool SetNumberProperty(uint property, string name, long value)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_SetNumberProperty(property, utf8, value);
        }
    }
    
    // Get Number Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern long SDL_GetNumberProperty(uint property, byte* name, long default_value);
    public static long GetNumberProperty(uint property, string name, long default_value)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetNumberProperty(property, utf8, default_value);
        }
    }
    
    // Set Float Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetFloatProperty(uint property, byte* name, float value);
    public static bool SetFloatProperty(uint property, string name, float value)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_SetFloatProperty(property, utf8, value);
        }
    }
    
    // Get Float Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern float SDL_GetFloatProperty(uint property, byte* name, float default_value);
    public static float GetFloatProperty(uint property, string name, float default_value)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetFloatProperty(property, utf8, default_value);
        }
    }
    
    // Set Boolean Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetBooleanProperty(uint property, byte* name, SDL.Bool value);
    public static bool SetBooleanProperty(uint property, string name, bool value)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_SetBooleanProperty(property, utf8, value);
        }
    }
    
    // Get Boolean Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetBooleanProperty(uint property, byte* name, SDL.Bool default_value);
    public static bool GetBooleanProperty(uint property, string name, bool default_value)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetBooleanProperty(property, utf8, default_value);
        }
    }
    
    // Get Property Type
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.PropertyType SDL_GetPropertyType(uint property, byte* name);
    public static SDL.PropertyType GetPropertyType(uint property, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetPropertyType(property, utf8);
        }
    }
    
    // Has Property
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasProperty(uint property, byte* name);
    public static bool HasProperty(uint property, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_HasProperty(property, utf8);
        }
    }
    
    // Lock Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_LockProperties(uint properties);
    public static bool LockProperties(uint properties)
    {
        return SDL_LockProperties(properties);
    }
    
    // Unlock Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_UnlockProperties(uint properties);
    public static void UnlockProperties(uint properties)
    {
        SDL_UnlockProperties(properties);
    }
}