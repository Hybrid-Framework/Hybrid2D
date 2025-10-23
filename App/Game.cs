using Hybrid;

namespace App
{
    public class Game : GameBehaviour
    {
        private float timer = 0f;
        
        public override void Initialize()
        {
            Window.Create(title: "Hybrid", width: 800, height: 600, fullscreen: false, resizable: true, vsync: true);
            Window.TargetFPS = 60;
            Window.VSync = false;
            
            Tests();
        }

        private void Tests()
        {
            var color = new ColorTest();
            color.Perform();
            
            var vector2 = new Vector2Test();
            vector2.Perform();
            
            var vector3 = new Vector3Test();
            vector3.Perform();
            
            var vector4 = new Vector4Test();
            vector4.Perform();

            var quaternion = new QuaternionTest();
            quaternion.Perform();
        }

        public override void Update()
        {
            timer += Time.unscaledDeltaTime;
        }

        public override void Draw()
        {
            float t = (MathF.Sin(timer) + 1f) / 2f;
            Color color = Color.Lerp(Color.red, Color.blue, t);
            Graphics.Clear(color);
            
            Graphics.DebugText(10, 10, $"Frames Per Second: {Time.fps:F2}", Color.black);
            Graphics.DebugText(10, 20, $"Frame Time: {Time.frameTime:F2}", Color.black);
            Graphics.DebugText(10, 30, $"Delta Time: {Time.deltaTime:F4}", Color.black);
            Graphics.DebugText(10, 40, $"Unscaled Delta Time: {Time.unscaledDeltaTime:F4}", Color.black);
            Graphics.DebugText(10, 50, $"Time: {Time.time:F2}", Color.black);
            Graphics.DebugText(10, 60, $"Unscaled Time: {Time.unscaledTime:F2}", Color.black);
            Graphics.DebugText(10, 70, $"Time Scale: {Time.timeScale:F2}", Color.white);
            
            Graphics.Present();
        }
    }
}