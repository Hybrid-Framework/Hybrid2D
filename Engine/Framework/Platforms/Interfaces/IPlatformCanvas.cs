using System;

namespace Hybrid
{
    public interface IPlatformCanvas
    {
        Orientation GetNaturalOrientation();
        Orientation GetOrientation();
    }
}