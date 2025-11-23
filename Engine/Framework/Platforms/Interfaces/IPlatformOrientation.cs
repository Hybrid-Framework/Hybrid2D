using System;

namespace Hybrid
{
    public interface IPlatformOrientation
    {
        Orientation GetNaturalOrientation();
        Orientation GetOrientation();
    }
}