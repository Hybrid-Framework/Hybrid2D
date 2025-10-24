using Hybrid;

namespace App
{
    public class Game : GameBehaviour
    {
        Color text = new (255, 255, 255, 255);
        Color background = new (100, 149, 237, 255);
        
        public override void Initialize()
        {
            Window.Create(title: "Hybrid", width: 800, height: 600, fullscreen: false, resizable: true, vsync: true);
            Window.TargetFPS = 60;
            Window.VSync = false;
        }

        public override void Update()
        {
            // Update logic here
        }

        public override void Draw()
        {
            Graphics.Clear(background);
            
            Graphics.DebugText(10, 10, $"Frames Per Second: {Time.fps:F2}", text);
            Graphics.DebugText(10, 20, $"Frame Time: {Time.frameTime:F2}", text);
            Graphics.DebugText(10, 30, $"Delta Time: {Time.deltaTime:F4}", text);
            Graphics.DebugText(10, 40, $"Unscaled Delta Time: {Time.unscaledDeltaTime:F4}", text);
            Graphics.DebugText(10, 50, $"Time: {Time.time:F2}", text);
            Graphics.DebugText(10, 60, $"Unscaled Time: {Time.unscaledTime:F2}", text);
            Graphics.DebugText(10, 70, $"Time Scale: {Time.timeScale:F2}", text);
            
            Graphics.Present();
        }
    }
}