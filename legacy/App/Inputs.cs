using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnAwake()
        {
            Input.TextInputStart(TextInputMode.Default, 128);
        }

        public override void OnUpdate()
        {
            Debug.Log(Input.KeyboardModifier);
        }
    }
}