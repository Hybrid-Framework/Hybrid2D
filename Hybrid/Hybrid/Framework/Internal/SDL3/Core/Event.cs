using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Explicit)]
	internal struct Event
	{
		[FieldOffset(0)]
		internal SDL.EventType type;
		
		[FieldOffset(0)]
		internal SDL.CommonEvent common;
		
		[FieldOffset(0)]
		internal SDL.DisplayEvent display;
		
		[FieldOffset(0)]
		internal SDL.WindowEvent window;
		
		[FieldOffset(0)]
		internal SDL.KeyboardDeviceEvent keyboardDevice;
		
		[FieldOffset(0)]
		internal SDL.KeyboardEvent keyboard;
		
		[FieldOffset(0)]
		internal SDL.TextEditingEvent textEditing;
		
		[FieldOffset(0)]
		internal SDL.TextEditingCandidatesEvent textEditingCandidates;
		
		[FieldOffset(0)]
		internal SDL.TextInputEvent textInput;
		
		[FieldOffset(0)]
		internal SDL.MouseDeviceEvent mouseDevice;
		
		[FieldOffset(0)]
		internal SDL.MouseMotionEvent mouseMotion;
		
		[FieldOffset(0)]
		internal SDL.MouseButtonEvent mouseButton;
		
		[FieldOffset(0)]
		internal SDL.MouseWheelEvent mouseWheel;
		
		[FieldOffset(0)]
		internal JoystickDeviceEvent joystickDevice;
		
		[FieldOffset(0)]
		internal JoystickAxisEvent joystickAxis;
		
		[FieldOffset(0)]
		internal JoystickBallEvent joystickBall;
		
		[FieldOffset(0)]
		internal JoystickHatEvent joystickHat;
		
		[FieldOffset(0)]
		internal JoystickButtonEvent joystickButton;
		
		[FieldOffset(0)]
		internal SDL.GamepadDeviceEvent gamepadDevice;
		
		[FieldOffset(0)]
		internal SDL.GamepadAxisEvent gamepadAxis;
		
		[FieldOffset(0)]
		internal SDL.GamepadButtonEvent gamepadButton;
		
		[FieldOffset(0)]
		internal SDL.AudioDeviceEvent audioDevice;
		
		[FieldOffset(0)]
		internal SDL.QuitEvent quit;
		
		[FieldOffset(0)]
		internal SDL.TouchFingerEvent touchFinger;
		
		[FieldOffset(0)]
		internal SDL.RenderEvent render;
		
		[FieldOffset(0)]
		internal SDL.ClipboardEvent clipboard;
		
		[FieldOffset(0)]
		internal fixed byte padding[128];
	}
}