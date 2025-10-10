using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Keyboard Support
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasKeyboard();
    public static bool KeyboardSupport()
    {
        return SDL_HasKeyboard();
    }
    
    // Get Key Modifier State
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.KeyModifier SDL_GetModState();
    public static SDL.KeyModifier KeyboardGetModifierState()
    {
        return SDL_GetModState();
    }
    
    // Set Key Modifier State
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_SetModState(SDL.KeyModifier modifier);
    public static void KeyboardSetModifierState(SDL.KeyModifier modifier)
    {
        SDL_SetModState(modifier);
    }
    
    // Get Keyboard Name From ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetKeyboardNameForID(int id);
    public static string GetKeyboardNameFromID(int id)
    {
        return Utf8ToString(SDL_GetKeyboardNameForID(id));
    }
    
    // Get Keyboards
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int* SDL_GetKeyboards(out int count);
    public static int[] GetKeyboardDevices()
    {
        int* ptr = SDL_GetKeyboards(out int count);

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
}