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
            
            if (Input.GetMouseScrollDelta().X != 0 || Input.GetMouseScrollDelta().Y != 0)
            {
                Debug.Log($"Scroll: {Input.GetMouseScrollDelta().X}, {Input.GetMouseScrollDelta().Y}");
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