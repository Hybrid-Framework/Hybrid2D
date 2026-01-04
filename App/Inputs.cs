using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        private readonly InputButton button = Input.CreateAction<InputButton>("Jump");
        private readonly InputVector vector = Input.CreateAction<InputVector>("Move");

        public override void OnAwake()
        {
            button.Add(() => Input.GetKeyboardButton(KeyboardButton.Space), () => Input.GetKeyboardButtonDown(KeyboardButton.Space), () => Input.GetKeyboardButtonUp(KeyboardButton.Space));
            button.Add(() => Input.GetMouseButton(MouseButton.Left), () => Input.GetMouseButtonDown(MouseButton.Left), () => Input.GetMouseButtonUp(MouseButton.Left));

            vector.Add(() => new Vector2(Input.GetKeyboardAxis(KeyboardAxis.KeyboardX), Input.GetKeyboardAxis(KeyboardAxis.KeyboardY)));
            vector.Add(() => Input.GetMousePosition());
        }

        public override void OnUpdate()
        {
            if (Input.GetVector(vector.Name).X != 0 || Input.GetVector(vector.Name).Y != 0)
            {
                Debug.Log($"Move: {Input.GetVector(vector.Name).X} {Input.GetVector(vector.Name).Y}");
            }
            
            if (Input.GetButtonDown(button.Name))
            {
                Debug.Log("Jump Down");
            }
            
            if (Input.GetButton(button.Name))
            {
                Debug.Log("Jump Press");
            }
            
            if (Input.GetButtonUp(button.Name))
            {
                Debug.Log("Jump Up");
            }
        }
    }
}