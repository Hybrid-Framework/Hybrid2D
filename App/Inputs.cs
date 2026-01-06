using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnAwake()
        {
            Input.StartTextInput(TextInputMode.Alpha, 128);
        }

        public override void OnUpdate()
        {
            
        }
    }
}