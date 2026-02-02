using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TextEditingCandidatesEvent
    {
        internal SDL.EventType type;
        internal uint reserved;
        internal ulong timestamp;
        internal uint windowID;
        internal byte** candidates;
        internal int num_candidates;
        internal int selected_candidate;
        internal SDL.Bool horizontal;
        private byte padding1;
        private byte padding2;
        private byte padding3;
    }
}