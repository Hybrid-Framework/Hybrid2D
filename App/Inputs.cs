using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnAwake()
        {
            Color32 color32 = new Color32() { R = 255, G = 255, B = 255, A = 255 };
            Color color = (Color)color32;
            
            Debug.Log($"Color32 {color32.R} {color32.G} {color32.B} {color32.A}");
            Debug.Log($"Color {color.R} {color.G} {color.B} {color.A}");
        }

        public override void OnUpdate()
        {
            var touch = Input.GetTouch(0);
            
            if (touch != null)
            {
                if (touch.TouchPhase() != Phase.None)
                {
                    Debug.Log($"Touch: {touch.TouchFinger()} Phase: {touch.TouchPhase()} Position: {touch.TouchPosition().X},{touch.TouchPosition().Y} Delta: {touch.TouchPositionDelta().X},{touch.TouchPositionDelta().Y}");
                }
            }
        }
    }
}