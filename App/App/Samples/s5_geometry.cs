// This is a simple program to show you how to render custom geometry
// This will allow you to render custom objects, create batching, tilemaps and more.

using Hybrid;

namespace App
{
    public class s5_geometry : Hybrid.App
    {
        private float[] positions;
        private Color[] colors;
        private int[] indices;
        private int padding = 50;
        
        public override void OnInitialize()
        {
            int width = Window.GetWidth();
            int height = Window.GetHeight();

            positions =
            [
                width / 2f, padding,
                padding, height - padding,
                width - padding, height - padding
            ];

            colors = 
            [
                new Color(1, 0, 0), new Color(0, 1, 0), new Color(0, 0, 1)
            ];
            
            indices = [ 0, 1, 2 ];
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(new Color(0, 0, 0));
            Graphics.DrawGeometry(positions, colors, indices);
            Graphics.DrawFps(10, 10, new Color(1, 1, 1));
            Graphics.DrawEnd();
        }
    }
}