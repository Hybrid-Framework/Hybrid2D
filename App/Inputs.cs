using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Down");
            }
            
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Hold");
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Release");
            }
            
            if (Input.GetGamepadAxis(Axis.LeftStickX) != 0 || Input.GetGamepadAxis(Axis.LeftStickY) != 0)
            {
                Debug.Log($"Scroll: {Input.GetGamepadAxis(Axis.LeftStickX)}, {Input.GetGamepadAxis(Axis.LeftStickY)}");
            }
            
            if (Input.GetGamepadAxis(Axis.RightStickX) != 0 || Input.GetGamepadAxis(Axis.RightStickY) != 0)
            {
                Debug.Log($"Scroll: {Input.GetGamepadAxis(Axis.RightStickX)}, {Input.GetGamepadAxis(Axis.RightStickY)}");
            }
            
            // if (Input.GetMousePositionDelta().X != 0 || Input.GetMousePositionDelta().Y != 0)
            // {
            //     Debug.Log($"Delta: {Input.GetMousePositionDelta().X}, {Input.GetMousePositionDelta().Y}");
            // }
            //
            // if (Input.GetMousePosition().X != 0 || Input.GetMousePosition().Y != 0)
            // {
            //     Debug.Log($"Position: {Input.GetMousePosition().X}, {Input.GetMousePosition().Y}");
            // }
        }
    }
}