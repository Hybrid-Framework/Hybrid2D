using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(Key.A))
            {
                Debug.Log("Down");
            }
            
            if (Input.GetKey(Key.A))
            {
                Debug.Log("Hold");
            }
            
            if (Input.GetKeyUp(Key.A))
            {
                Debug.Log("Released");
            }
        }
    }
}