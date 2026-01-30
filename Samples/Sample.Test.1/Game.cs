// This is a test project for Sample.Test.1

using Hybrid;

public class Game : App
{
    public override void OnInitialize()
    {
        
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnRender()
    {
        Graphics.DrawBegin(Color.White);
        Graphics.DrawFps(10, 10, Color.Black);
        Graphics.DrawEnd();
    }
}