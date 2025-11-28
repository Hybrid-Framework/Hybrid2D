using System;

namespace Hybrid
{
    public interface IPlatformSystem
    {
        Device GetDevice();
        System GetPlatform();
    }
}