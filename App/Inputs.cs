using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnUpdate()
        {
            var touch = Input.GetTouch(0);
            
            if (touch != null)
            {
                if (touch.TouchPhase() == Phase.Began)
                {
                    TouchScreenKeyboard.Open();
                }
            }
        }
    }
}