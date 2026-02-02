// This is a simple program to show you how to get input from gamepads
// Use the sticks to move the rectangle around or press a button to change color

using Hybrid;

namespace App
{
    public class s7_gamepad : Hybrid.App
    {
        private float speed = 200;
        private bool pressed;
        private Rect rect;

        public override void OnInitialize()
        {
            rect = new Rect(0, 0, 128, 128);
        }

        public override void OnUpdate()
        {
            pressed = Gamepad.GetButton(0, Button.Back) ||
                      Gamepad.GetButton(0, Button.Start) ||
                      Gamepad.GetButton(0, Button.North) ||
                      Gamepad.GetButton(0, Button.East) ||
                      Gamepad.GetButton(0, Button.South) ||
                      Gamepad.GetButton(0, Button.West) ||
                      Gamepad.GetButton(0, Button.LeftStick) ||
                      Gamepad.GetButton(0, Button.RightStick) ||
                      Gamepad.GetButton(0, Button.LeftShoulder) ||
                      Gamepad.GetButton(0, Button.RightShoulder) ||
                      Gamepad.GetButton(0, Button.DpadUp) ||
                      Gamepad.GetButton(0, Button.DpadDown) ||
                      Gamepad.GetButton(0, Button.DpadLeft) ||
                      Gamepad.GetButton(0, Button.DpadRight) ||
                      Gamepad.GetAxis(0, Axis.LeftTrigger) > 0 ||
                      Gamepad.GetAxis(0, Axis.RightTrigger) > 0;
            
            rect.x += Gamepad.GetAxis(0, Axis.LeftStickX) * speed * Time.GetDeltaTime();
            rect.x += Gamepad.GetAxis(0, Axis.RightStickX) * speed * Time.GetDeltaTime();
            rect.y -= Gamepad.GetAxis(0, Axis.LeftStickY) * speed * Time.GetDeltaTime();
            rect.y -= Gamepad.GetAxis(0, Axis.RightStickY) * speed * Time.GetDeltaTime();
            
            rect.x = Maths.Clamp(rect.x, 0, Window.GetWidth() - rect.width);
            rect.y = Maths.Clamp(rect.y, 0, Window.GetHeight() - rect.height);
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(new Color(0, 0, 0));
            Graphics.DrawRectangle(rect, pressed ? new Color(0, 1, 0) : new Color(1, 0, 0));
            Graphics.DrawFps(10, 10, new Color(1, 1, 1));
            Graphics.DrawEnd();
        }
    }
}