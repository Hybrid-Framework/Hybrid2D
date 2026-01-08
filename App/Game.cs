using Hybrid;
using System;

namespace App
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
            Time.SetFps(60);
            
            Debug.Log(Device.GetPlatform());
            Debug.Log(Device.GetDate());
            Debug.Log(Device.GetTime());
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.DrawColor(new Color32(255, 128, 128, 255));
            Graphics.DrawClear();
            
            Graphics.DrawColor(new Color32(255, 255, 255, 255));
            Graphics.DrawFps(10, 10);
            
            Graphics.DrawPresent();
        }
    }
}