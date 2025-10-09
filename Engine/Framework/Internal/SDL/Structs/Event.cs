using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Event
    {
        [FieldOffset(0)]
        public uint type;

        [FieldOffset(0)]
        public SDL.CommonEvent common;

        [FieldOffset(0)]
        public SDL.DisplayEvent display;

        [FieldOffset(0)]
        public SDL.WindowEvent window;

        [FieldOffset(0)]
        public SDL.KeyboardDeviceEvent keyboardDevice;

        [FieldOffset(0)]
        public SDL.KeyboardEvent keyboard;

        [FieldOffset(0)]
        public SDL.TextEditingEvent textEditing;

        [FieldOffset(0)]
        public SDL.TextEditingCandidatesEvent textEditingCandidates;

        [FieldOffset(0)]
        public SDL.TextInputEvent textInput;

        [FieldOffset(0)]
        public SDL.MouseDeviceEvent mouseDevice;

        [FieldOffset(0)]
        public SDL.MouseMotionEvent mouseMotion;

        [FieldOffset(0)]
        public SDL.MouseButtonEvent mouseButton;

        [FieldOffset(0)]
        public SDL.MouseWheelEvent mouseWheel;

        [FieldOffset(0)]
        public SDL.GamepadDeviceEvent gamepadDevice;

        [FieldOffset(0)]
        public SDL.GamepadAxisEvent gamepadAxis;

        [FieldOffset(0)]
        public SDL.GamepadButtonEvent gamepadButton;

        [FieldOffset(0)]
        public SDL.AudioDeviceEvent audioDevice;

        [FieldOffset(0)]
        public SDL.QuitEvent quit;

        [FieldOffset(0)]
        public SDL.UserEvent user;

        [FieldOffset(0)]
        public SDL.TouchEvent touch;

        [FieldOffset(0)]
        public SDL.RenderEvent render;

        [FieldOffset(0)]
        public SDL.ClipboardEvent clipboard;

        [FieldOffset(0)]
        public fixed byte padding[128];
    }
}