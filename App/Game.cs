using Hybrid;

namespace App
{
    public class Game : GameBehaviour
    {
        public override void Initialize()
        {
            Window.Create(title: "Hybrid", width: 800, height: 600, fullscreen: false, resizable: true, vsync: true);
            Window.TargetFPS = 60;
            Window.VSync = false;
        }

        public override void Update()
        {
            // Update logic
        }

        public override void Draw()
        {
            Graphics.Clear(Color.Salmon);
            
            Graphics.DebugText(10, 10, $"Frames Per Second: {Time.fps:F2}", Color.Black);
            Graphics.DebugText(10, 20, $"Frame Time: {Time.frameTime:F2}", Color.Black);
            Graphics.DebugText(10, 30, $"Delta Time: {Time.deltaTime:F4}", Color.Black);
            Graphics.DebugText(10, 40, $"Unscaled Delta Time: {Time.unscaledDeltaTime:F4}", Color.Black);
            Graphics.DebugText(10, 50, $"Time: {Time.time:F2}", Color.Black);
            Graphics.DebugText(10, 60, $"Unscaled Time: {Time.unscaledTime:F2}", Color.Black);
            Graphics.DebugText(10, 70, $"Time Scale: {Time.timeScale:F2}", Color.White);
            
            Graphics.Present();
        }
    }
}