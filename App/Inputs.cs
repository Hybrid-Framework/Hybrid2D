using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnUpdate()
        {
            if (Input.GetKey(Key.Space))
            {
                Debug.Log("Space Press");
            }
            
            if (Input.GetKeyDown(Key.Space))
            {
                Debug.Log("Space Down");
            }
            
            if (Input.GetKeyUp(Key.Space))
            {
                Debug.Log("Space Release");
            }

            for (int i = 0; i < 3; i++)
            {
                if (Input.GetMouseButton(i))
                {
                    Debug.Log($"Mouse {i}: Press");
                }
                
                if (Input.GetMouseButtonDown(i))
                {
                    Debug.Log($"Mouse {i}: Down");
                }
                
                if (Input.GetMouseButtonUp(i))
                {
                    Debug.Log($"Mouse {i}: Release");
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (Input.GetButton(Button.South, i))
                {
                    Debug.Log($"Gamepad {i}: Press");
                }
                
                if (Input.GetButtonDown(Button.South, i))
                {
                    Debug.Log($"Gamepad {i}: Down");
                }
                
                if (Input.GetButtonUp(Button.South, i))
                {
                    Debug.Log($"Gamepad {i}: Release");
                }
                
                if (Input.GetAxis(Axis.LeftTrigger, i) != 0)
                {
                    Debug.Log($"Gamepad {i}: Y: {Input.GetAxis(Axis.LeftTrigger, i)}");
                }
                
                if (Input.GetAxis(Axis.RightTrigger, i) != 0)
                {
                    Debug.Log($"Gamepad {i}: X: {Input.GetAxis(Axis.RightTrigger, i)}");
                }
            }
        }
    }
}