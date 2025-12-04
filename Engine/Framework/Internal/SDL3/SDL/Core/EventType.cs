using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public enum EventType
    {
        Shown = 514,
        Hidden = 515,
        Moved = 517,
        Resized = 518,
        Minimized = 521,
        Maximized = 522,
        Restored = 523,
        MouseEnter = 524,
        MouseExit = 525,
        Focused = 526,
        Unfocused = 527,
        SafeArea = 533,
        Orientation = 337,
        FullscreenOn = 535,
        FullscreenOff = 536,
        ResizableOn = (User + 1),
        ResizableOff = (User + 2),
        
        KeyboardButtonUp = 769,
        KeyboardButtonDown = 768,
        KeyboardDeviceAdded = 773,
        KeyboardDeviceRemoved = 774,
        
        TextEditing = 770,
        TextInput = 771,
        TextEditingCandidates = 775,
        
        MouseButtonUp = 1026,
        MouseButtonDown = 1025,
        MouseMotion = 1024,
        MouseWheel = 1027,
        MouseDeviceAdded = 1028,
        MouseDeviceRemoved = 1029,
        
        GamepadButtonUp = 1618,
        GamepadButtonDown = 1617,
        GamepadAxisMotion = 1616,
        GamepadDeviceAdded = 1619,
        GamepadDeviceRemoved = 1620,
        
        TouchFingerDown = 1792,
        TouchFingerUp = 1793,
        TouchFingerMotion = 1794,
        TouchFingerCancel = 1795,
        
        AudioDeviceAdded = 4352,
        AudioDeviceRemoved = 4353,
        
        First = 0,
        Quit = 256,
        User = 32768,
        Last = 65535,
        Clipboard = 2304,
    }
}