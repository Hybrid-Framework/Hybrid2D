using System;

namespace Hybrid
{
    internal interface IPlatformSystem
    {
        UnderlyingDevice GetUnderlyingDevice();
        UnderlyingPlatform GetUnderlyingPlatform();
    }
}