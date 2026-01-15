using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
            
        }

        public override void OnUpdate()
        {
            if (Touch.GetTouchCount() > 0)
            {
                Debug.Log("Touching!");
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