using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnUpdate()
        {
            var modifiers = Input.GetKeyModifier(Modifier.CapLock);

            if (modifiers)
            {
                Debug.Log("Pressed");
            }
        }
    }
}