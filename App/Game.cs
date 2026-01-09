using Hybrid;
using System;

namespace App
{
    public class Game : Hybrid.App
    {
        private Texture texture;
        
        public override void OnInitialize()
        {
            Time.SetFps(60);
            
            Debug.Log(Device.GetPlatform());
            Debug.Log(Device.GetDate());
            Debug.Log(Device.GetTime());

            texture = Texture.Create("Images/Image.png");
            Texture.SetPixel(texture, 0, 0, new Color32(255, 0, 0, 255));
            Texture.SetPixel(texture, 1, 0, new Color32(0, 255, 0, 255));
            Texture.SetPixel(texture, 2, 0, new Color32(0, 0, 255, 255));
            Texture.Apply(texture);
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
            
            Graphics.DrawTexture(texture, new Rect(8, 0, 8, 8), new Rect(0,0,256,256));
            
            Graphics.DrawPresent();
        }
    }
}