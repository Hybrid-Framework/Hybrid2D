using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
            Window.SetFullscreen(true);
            Window.SetResizable(true);
        }

        public override void OnUpdate()
        {
            if (Touch.GetTouch(0))
            {
                Debug.Log($"Touch 0: {Touch.GetTouchPosition(0).x}, {Touch.GetTouchPosition(0).y}");
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