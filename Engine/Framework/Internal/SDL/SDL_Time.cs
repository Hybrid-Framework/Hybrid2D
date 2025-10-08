using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Get Date Time Local Preferences
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetDateTimeLocalePreferences(out SDL.DateFormat dateFormat, out SDL.TimeFormat timeFormat);
    public static (SDL.DateFormat dateFormat, SDL.TimeFormat timeFormat) GetDateTimeLocalePreferences()
    {
        SDL_GetDateTimeLocalePreferences(out SDL.DateFormat dateFormat, out SDL.TimeFormat timeFormat);
        return (dateFormat, timeFormat);
    }
    
    // Get Days In Month
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetDaysInMonth(int year, int month);
    public static int GetDaysInMonth(int year, int month)
    {
        return SDL_GetDaysInMonth(year, month);
    }
    
    // Get Day Of Year
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetDayOfYear(int year, int month, int day);
    public static int GetDayOfYear(int year, int month, int day)
    {
        return SDL_GetDayOfYear(year, month, day);
    }
    
    // Get Day Of Week
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetDayOfWeek(int year, int month, int day);
    public static int GetDayOfWeek(int year, int month, int day)
    {
        return SDL_GetDayOfWeek(year, month, day);
    }
}