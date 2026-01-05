using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        private readonly VirtualButton button = Input.CreateVirtualButton("jump");

        public override void OnAwake()
        {
            button.Bind
            (
                () => Input.GetKeyboardButton(KeyboardButton.Space),
                () => Input.GetKeyboardButtonDown(KeyboardButton.Space),
                () => Input.GetKeyboardButtonUp(KeyboardButton.Space)
            );
            
            button.Bind
            (
                () => Input.GetMouseButton(MouseButton.Left),
                () => Input.GetMouseButtonDown(MouseButton.Left),
                () => Input.GetMouseButtonUp(MouseButton.Left)
            );
        }

        public override void OnUpdate()
        {
            if (button.GetButtonDown())
            {
                Debug.Log("Down");
            }
        }
    }
}