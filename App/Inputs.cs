using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        private readonly InputAction action = Input.CreateAction("Action");
        
        public override void OnAwake()
        {
            action.Add
            (
                GetKey: () => Input.GetMouseButton(1),
                GetKeyUp: () => Input.GetMouseButtonUp(1),
                GetKeyDown: () => Input.GetMouseButtonDown(1)
            );
            
            action.Add
            (
                GetKey: () => Input.GetMouseButton(0),
                GetKeyUp: () => Input.GetMouseButtonUp(0),
                GetKeyDown: () => Input.GetMouseButtonDown(0)
            );
            
            action.Add
            (
                Value: () => Input.GetGamepadAxis(Axis.LeftTrigger)
            );
            
            action.Add
            (
                Value: () => Input.GetGamepadAxis(Axis.RightTrigger)
            );
        }

        public override void OnUpdate()
        {
            if (Input.GetButtonDown("Action"))
            {
                Debug.Log("Action Down");
            }
            
            if (Input.GetButton("Action"))
            {
                Debug.Log("Action Press");
            }
            
            if (Input.GetButtonUp("Action"))
            {
                Debug.Log("Action Up");
            }

            if (Input.GetAxis("Action") != 0)
            {
                Debug.Log("Action Axis: " + Input.GetAxis("Action"));
            }
        }
    }
}