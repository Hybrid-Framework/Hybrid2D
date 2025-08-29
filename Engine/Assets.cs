using System;

namespace Engine
{
    public static class Assets
    {
        public static string GetPath()
        {
            #if WEB
            return "/Assets";
            #else
            return "Assets";
            #endif
        }
    }
}