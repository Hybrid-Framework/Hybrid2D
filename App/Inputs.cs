using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        private readonly InputAction action = Input.CreateAction("Jump");
        
        public override void OnAwake()
        {
            action.Add
            (
                GetKey: () => Input.GetGamepadAxis(Axis.LeftStickX) != 0,
                GetKeyUp: () => Input.GetGamepadAxis(Axis.LeftStickX) != 0,
                GetKeyDown: () => Input.GetGamepadAxis(Axis.LeftStickX) != 0
            );
            
            action.Add
            (
                GetKey: () => Input.GetMouseButton(0),
                GetKeyUp: () => Input.GetMouseButtonUp(0),
                GetKeyDown: () => Input.GetMouseButtonDown(0)
            );
        }

        public override void OnUpdate()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Down");
            }
            
            if (Input.GetButton("Jump"))
            {
                Debug.Log("Press");
            }
            
            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("Up");
            }
        }
    }
}