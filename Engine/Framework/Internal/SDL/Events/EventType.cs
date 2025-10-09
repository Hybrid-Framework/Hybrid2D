using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public enum EventType
    {
        Quit = 256,
        
        Terminating = 257,
        LowMemory = 258,
        LocaleChanged = 263,
        WillEnterBackground = 259,
        DidEnterBackground = 260,
        WillEnterForeground = 261,
        DidEnterForeground = 262,
        SystemThemeChanged = 264,

        Orientation = 337,
        DisplayAdded = 338,
        DisplayRemoved = 339,
        DisplayMoved = 340,
        DisplayDesktopModeChanged = 341,
        DisplayCurrentModeChanged = 342,
        DisplayContentScaleChanged = 343,

        WindowShown = 514,
        WindowHidden = 515,
        WindowExposed = 516,
        WindowMoved = 517,
        WindowResized = 518,
        WindowPixelSizeChanged = 519,
        WindowMetalViewResized = 520,
        WindowMinimized = 521,
        WindowMaximized = 522,
        WindowRestored = 523,
        WindowMouseEnter = 524,
        WindowMouseLeave = 525,
        WindowFocusGained = 526,
        WindowFocusLost = 527,
        WindowCloseRequested = 528,
        WindowHitTest = 529,
        WindowICCProfChanged = 530,
        WindowDisplayChanged = 531,
        WindowDisplayScaleChanged = 532,
        WindowSafeAreaChanged = 533,
        WindowOccluded = 534,
        WindowEnterFullscreen = 535,
        WindowLeaveFullscreen = 536,
        WindowDestroyed = 537,
        WindowHdrStateChanged = 538,
        WindowFirst = 514,
        WindowLast = 538,

        KeyboardButtonDown = 768,
        KeyboardButtonUp = 769,
        KeyboardDeviceAdded = 773,
        KeyboardDeviceRemoved = 774,

        MouseMotion = 1024,
        MouseWheel = 1027,
        MouseButtonDown = 1025,
        MouseButtonUp = 1026,
        MouseDeviceAdded = 1028,
        MouseDeviceRemoved = 1029,

        GamepadAxis = 1616,
        GamepadButtonDown = 1617,
        GamepadButtonUp = 1618,
        GamepadDeviceAdded = 1619,
        GamepadDeviceRemoved = 1620,

        TouchDown = 1792,
        TouchUp = 1793,
        TouchMotion = 1794,
        TouchEnded = 1795,
        
        AudioDeviceAdded = 4352,
        AudioDeviceRemoved = 4353,
        AudioDeviceFormatChanged = 4354,
        
        TextEditingCandidates = 775,
        TextEditing = 770,
        TextInput = 771,

        First = 0,
        User = 32768,
        Last = 65535,
        Clipboard = 2304,
        Padding = 2147483647
    }
}