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

            if (Input.MouseScrollDelta.X != 0 || Input.MouseScrollDelta.Y != 0)
            {
                Debug.Log(Input.MouseScrollDelta.X + " " + Input.MouseScrollDelta.Y);
            }
        }
    }
}