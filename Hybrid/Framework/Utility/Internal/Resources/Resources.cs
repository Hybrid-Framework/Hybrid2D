using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System;

namespace Hybrid
{
    internal sealed class Resources : Module
    {
        internal static Dictionary<string, Assembly> path = new Dictionary<string, Assembly>();
        
        internal override void OnInitialize()
        {
            
        }
        
        internal static byte[] Load(string resourcePath)
        {
            var path = resourcePath.Replace("/", ".");
            Debug.Log(path);
            
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var resource in assembly.GetManifestResourceNames())
                {
                    Debug.Log($"Checking: {path} against {resource}");
                }
            }

            return null;
        }
    }
}
