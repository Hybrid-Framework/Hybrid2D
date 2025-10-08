using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum PowerState
    {
        Error = -1,
        Unknown = 0,
        OnBattery = 1,
        NoBattery = 2,
        Charging = 3,
        Charged = 4,
    }
}