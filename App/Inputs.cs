using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        private readonly VirtualButton button = Input.CreateVirtualButton("jump");
        private readonly VirtualStick move = Input.CreateVirtualStick("move");

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
            
            move.Bind(() => new Vector2(Input.GetKeyboardAxis(KeyboardAxis.KeyboardX), Input.GetKeyboardAxis(KeyboardAxis.KeyboardY)));
        }

        public override void OnUpdate()
        {
            if (move.Value().X != 0 || move.Value().Y != 0)
            {
                Debug.Log($"Move: {move.Value().X} {move.Value().Y}");
            }
            
            if (button.GetButtonDown())
            {
                Debug.Log("Down");
            }
        }
    }
}