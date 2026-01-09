using System;

namespace Hybrid
{
    public enum FlipMode
    {
        None = 0,
        Horizontal = 1,
        Vertical = 2,
        HorizontalVertical = (Horizontal | Vertical)
    }
}