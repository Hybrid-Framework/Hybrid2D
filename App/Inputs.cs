using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        private readonly InputAction action = Input.CreateAction("Action");
        private readonly InputVector stick = Input.CreateVector("Stick");
        private readonly InputAxis axis = Input.CreateAxis("Horizontal");
        
        public override void OnAwake()
        {
            action.Add
            (
                GetKey: () => Input.GetMouseButton(1),
                GetKeyUp: () => Input.GetMouseButtonUp(1),
                GetKeyDown: () => Input.GetMouseButtonDown(1)
            );
            
            action.Remove
            (
                GetKey: () => Input.GetMouseButton(1),
                GetKeyUp: () => Input.GetMouseButtonUp(1),
                GetKeyDown: () => Input.GetMouseButtonDown(1)
            );

            axis.Add
            (
                Value: () => Input.GetGamepadAxis(Axis.LeftStickX)
            );

            stick.Add
            (
                Value: () => new Vector2(Input.GetGamepadAxis(Axis.LeftStickX), Input.GetGamepadAxis(Axis.LeftStickY))
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

            if (Input.GetAxis("Horizontal") != 0)
            {
                // Debug.Log("Axis: " + Input.GetAxis("Horizontal"));
            }
            
            if (Input.GetVector("Stick").X != 0 || Input.GetVector("Stick").Y != 0)
            {
                Debug.Log("Stick: " + Input.GetVector("Stick").X + ", " + Input.GetVector("Stick").Y);
            }
        }
    }
}