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
                GetKey: () => Input.GetMouseButton(MouseButton.Left),
                GetKeyUp: () => Input.GetMouseButtonUp(MouseButton.Left),
                GetKeyDown: () => Input.GetMouseButtonDown(MouseButton.Left)
            );

            stick.Add
            (
                Value: () => new Vector2(Input.GetMouseAxis(MouseAxis.MouseX), Input.GetMouseAxis(MouseAxis.MouseY))
            );
            
            stick.Add
            (
                Value: () => new Vector2(Input.GetMouseAxis(MouseAxis.ScrollX), Input.GetMouseAxis(MouseAxis.ScrollY))
            );
        }

        public override void OnUpdate()
        {
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