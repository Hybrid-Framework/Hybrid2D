using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnUpdate()
        {
            if (Input.GetGamepadAxis(Axis.LeftTrigger) != 0)
            {
                Input.GamepadRumble(ushort.MaxValue, ushort.MaxValue, 1);
            }
            
            if (Input.GetGamepadAxis(Axis.RightTrigger) != 0)
            {
                Input.GamepadRumble(ushort.MaxValue, ushort.MaxValue, 1);
            }

            if (Input.GetGamepadButton(Button.South))
            {
                Input.GamepadRumble(ushort.MaxValue, ushort.MaxValue, 1);
            }
        }
    }
}