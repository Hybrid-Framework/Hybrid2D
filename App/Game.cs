using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
            Time.SetFps(60);
            
            Storage.FileCreate("Test.data");
            Storage.FileWrite("Test.data", new byte[2] { 1, 2});
        }

        public override void OnUpdate()
        {
            if (Input.GetMouseButtonDown(MouseButton.Left))
            {
                Debug.Log("Down");
            }
            
            if (Input.GetMouseButton(MouseButton.Left))
            {
                Debug.Log("Press");
            }
            
            if (Input.GetMouseButtonUp(MouseButton.Left))
            {
                Debug.Log("Up");
            }
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            
            Graphics.DrawFps(10, 10, Color.White);
            
            float[] positions =
            {
                300f, 0f,
                600, 400f,
                0f, 400f
            };
            
            Color[] colors =
            {
                Color.Red,
                Color.Green,
                Color.Blue
            };
            
            int[] indices =
            {
                0, 1, 2
            };
            
            Graphics.DrawGeometry(positions, colors, indices);
            
            Graphics.DrawEnd();
        }
    }
}