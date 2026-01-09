using Hybrid;
using System;

namespace App
{
    public class Game : Hybrid.App
    {
        private Texture texture;
        
        public override void OnInitialize()
        {
            Window.SetSize(new Vector2(800, 800));
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
            
            Color red = new() { R = 1f, G = 0f, B = 0f, A = 1f };
            Color green = new() { R = 0f, G = 1f, B = 0f, A = 1f };
            Color blue = new() { R = 0f, G = 0f, B = 1f, A = 1f };

            float[] positions = new float[]
            {
                400f, 100f,
                100f, 700f,
                700f, 700f
            };

            Color[] colors = new Color[] { red, green, blue };
            int[] indices = new int[] { 0, 1, 2 };
            float[] uvs = null;

            Graphics.DrawGeometry(null, positions, colors, null, indices);
            Graphics.DrawPresent();
        }
    }
}