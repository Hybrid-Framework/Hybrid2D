// This is a test project for Sample.Test.2

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
        Graphics.DrawBegin(Color.Black);
        Graphics.DrawFps(10, 10, Color.White);
        Graphics.DrawEnd();
    }
}