using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TextEditingCandidatesEvent
    {
        public SDL.EventType type;
        public uint reserved;
        public ulong timestamp;
        public uint windowID;
        public byte** candidates;
        public int num_candidates;
        public int selected_candidate;
        public SDL.Bool horizontal;
        private byte padding1;
        private byte padding2;
        private byte padding3;
    }
}