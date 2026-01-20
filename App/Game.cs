using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
            Window.SetTitle("Hello");
        }

        public override void OnUpdate()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Mouse");
            }

            if (Input.GetKeyboardButtonDown(Key.A))
            {
                Debug.Log("Keyboard");
            }
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}