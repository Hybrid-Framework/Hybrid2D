using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnAwake()
        {
            Input.StartTextInput(KeyboardInputType.AlphaNumeric, 16);
        }

        public override void OnUpdate()
        {
            
        }
    }
}