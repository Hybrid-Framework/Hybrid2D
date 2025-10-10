using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Get Date Time Format
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetDateTimeLocalePreferences(out SDL.DateFormat dateFormat, out SDL.TimeFormat timeFormat);
    public static (SDL.DateFormat dateFormat, SDL.TimeFormat timeFormat) GetDateTimeFormat()
    {
        SDL_GetDateTimeLocalePreferences(out SDL.DateFormat dateFormat, out SDL.TimeFormat timeFormat);
        return (dateFormat, timeFormat);
    }
}