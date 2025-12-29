using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnUpdate()
        {
            if (Input.GetGamepadButton(Button.South)) Debug.Log($"Gamepad ANY: Press");
            if (Input.GetGamepadButtonUp(Button.South)) Debug.Log($"Gamepad ANY: Release");
            
            if (Input.GetGamepadButton(Button.South, InputPlayer.One)) Debug.Log($"Gamepad 1: Press");
            if (Input.GetGamepadButtonUp(Button.South, InputPlayer.One)) Debug.Log($"Gamepad 1: Release");
            
            if (Input.GetGamepadButton(Button.South, InputPlayer.Two)) Debug.Log($"Gamepad 2: Press");
            if (Input.GetGamepadButtonUp(Button.South, InputPlayer.Two)) Debug.Log($"Gamepad 2: Release");
        }
    }
}