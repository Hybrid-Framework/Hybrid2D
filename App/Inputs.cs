using System;
using Hybrid;

namespace App
{
    public class Inputs : MonoBehaviour
    {
        public override void OnAwake()
        {
            Point point = new Point() { X = 1.5f, Y = 2.3f };
            PointInt pointInt = (PointInt)point;
            
            Debug.Log($"Point {point.X} {point.Y}");
            Debug.Log($"PointInt {pointInt.X} {pointInt.Y}");
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