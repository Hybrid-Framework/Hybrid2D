using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnUpdate()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int b = 0; b < 16; b++)
                {
                    if (Input.GetMouseButton(b, i))
                    {
                        Debug.Log($"Mouse {i} {b} Press");
                    }
            
                    if (Input.GetMouseButtonDown(b, i))
                    {
                        Debug.Log($"Mouse {i} {b} Down");
                    }
            
                    if (Input.GetMouseButtonUp(b, i))
                    {
                        Debug.Log($"Mouse {i} {b} Release");
                    }
                }
            }
            
            for (int i = 0; i < 4; i++)
            {
                if (Input.GetKey(Key.Space, i))
                {
                    Debug.Log($"Keyboard {i} Press");
                }
            
                if (Input.GetKeyDown(Key.Space, i))
                {
                    Debug.Log($"Keyboard {i} Down");
                }
            
                if (Input.GetKeyUp(Key.Space, i))
                {
                    Debug.Log($"Keyboard {i} Release");
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (Input.GetGamepadButton(Button.South, i))
                {
                    Debug.Log($"Gamepad {i}: Press");
                }
                
                if (Input.GetGamepadButtonDown(Button.South, i))
                {
                    Debug.Log($"Gamepad {i}: Down");
                }
                
                if (Input.GetGamepadButtonUp(Button.South, i))
                {
                    Debug.Log($"Gamepad {i}: Release");
                }
                
                if (Input.GetGamepadAxis(Axis.LeftTrigger, i) != 0)
                {
                    Debug.Log($"Gamepad {i}: Y: {Input.GetGamepadAxis(Axis.LeftTrigger, i)}");
                }
                
                if (Input.GetGamepadAxis(Axis.RightTrigger, i) != 0)
                {
                    Debug.Log($"Gamepad {i}: X: {Input.GetGamepadAxis(Axis.RightTrigger, i)}");
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int t = 0; t < 8; t++)
                {
                    var touch = Input.GetTouch(t, i);
                    
                    if (touch != null)
                    {
                        if (touch.GetPhase() != Phase.None)
                        {
                            Debug.Log($"Touch {t} Device: {i} Phase: {Input.GetTouch(t, i).GetPhase()}");
                        }
                    }
                }
            }
        }
    }
}