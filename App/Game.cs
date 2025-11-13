using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        public override void OnInitialize()
        {
            
        }

        public override void OnUpdate()
        {
            Vector2 leftStick = new Vector2(Input.Gamepad.GetAxis(Axis.LeftStickX), Input.Gamepad.GetAxis(Axis.LeftStickY));
            Vector2 rightStick = new Vector2(Input.Gamepad.GetAxis(Axis.RightStickX), Input.Gamepad.GetAxis(Axis.RightStickY));
            float leftTrigger = Input.Gamepad.GetAxis(Axis.LeftTrigger);
            float rightTrigger = Input.Gamepad.GetAxis(Axis.RightTrigger);
            
            if (leftStick != Vector2.Zero)
            {
                Console.WriteLine($"LS: {leftStick}");
            }
            
            if (rightStick != Vector2.Zero)
            {
                Console.WriteLine($"RS: {rightStick}");
            }

            if (leftTrigger > 0)
            {
                Console.WriteLine($"LT: {leftTrigger}");
            }
            
            if (rightTrigger > 0)
            {
                Console.WriteLine($"RT: {rightTrigger}");
            }
        }

        public override void OnRender()
        {
            Graphics.ClearColor(Color.CornFlowerBlue);
            Graphics.DrawStats(Color.White);
            Graphics.Present();
        }
    }
}