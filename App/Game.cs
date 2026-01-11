using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
            Time.SetFps(60);
            Window.SetSize(new Point(500,500));

            var audio = Audio.CreateAudio("Sounds/Sound.mp3");
            Audio.SetMasterVolume(1);
            Audio.SetVolume(audio, 1f);
            Audio.Play(audio);
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
            
            // 3 vertices
            float[] positions =
            {
                250f, 500f, // top
                500, 0f, // bottom right
                0f, 0f  // bottom left
            };

// One color per vertex (SDL_FColor / your Color)
            Color[] colors =
            {
                Color.Red,
                Color.Green,
                Color.Blue
            };

// UVs are required by SDL_RenderGeometryRaw even if texture == null
            float[] uvs =
            {
                0f, 0f,
                1f, 0f,
                0f, 1f
            };

// One triangle
            int[] indices =
            {
                0, 1, 2
            };

            
            Graphics.DrawGeometry(null, positions, colors, uvs, indices);
            
            Graphics.DrawEnd();
        }
    }
}