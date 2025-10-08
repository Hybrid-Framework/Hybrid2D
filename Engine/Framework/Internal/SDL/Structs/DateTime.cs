using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DateTime
    {
        public int Year;
        public int Month;
        public int Day;
        public int Hour;
        public int Minute;
        public int Second;
        public int NanoSecond;
        public int DayOfWeek;
        public int UtcOffset;
    }
}