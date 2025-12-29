using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnUpdate()
        {
            var modifiers = Input.GetKeyModifiers();

            if (modifiers != Modifier.None)
            {
                Debug.Log(modifiers);
            }
        }
    }
}