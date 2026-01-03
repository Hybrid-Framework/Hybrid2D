using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnUpdate()
        {
            if (Input.GetKeyboardAxis(KeyboardAxis.KeyboardX) != 0 || Input.GetKeyboardAxis(KeyboardAxis.KeyboardY) != 0)
            {
                Debug.Log($"Keyboard Axis: {Input.GetKeyboardAxis(KeyboardAxis.KeyboardX)} {Input.GetKeyboardAxis(KeyboardAxis.KeyboardY)}");
            }
            
            if (Input.GetMouseButtonDown(MouseButton.Left))
            {
                Debug.Log("Left Mouse");
            }
            
            if (Input.GetMouseButtonDown(MouseButton.Middle))
            {
                Debug.Log("Middle Mouse");
            }
            
            if (Input.GetMouseButtonDown(MouseButton.Right))
            {
                Debug.Log("Right Mouse");
            }
        }
    }
}