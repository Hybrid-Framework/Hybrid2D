using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        public override void OnStart()
        {
            
        }

        public override void OnUpdate()
        {
            Vector2 leftStick = new Vector2(Input.GetAxis(Axis.LeftStickX), Input.GetAxis(Axis.LeftStickY));
            Vector2 rightStick = new Vector2(Input.GetAxis(Axis.RightStickX), Input.GetAxis(Axis.RightStickY));
            float leftTrigger = Input.GetAxis(Axis.LeftTrigger);
            float rightTrigger = Input.GetAxis(Axis.RightTrigger);
            
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