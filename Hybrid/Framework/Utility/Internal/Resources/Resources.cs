using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System;

namespace Hybrid
{
    internal sealed class Resources : Module
    {
        private static Dictionary<string, (Assembly assembly, string fullpath)> EmbeddedResources;

        internal override void OnInitialize()
        {
            EmbeddedResources = new Dictionary<string, (Assembly assembly, string fullName)>(StringComparer.OrdinalIgnoreCase);

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                string name = assembly.GetName().Name;

                if (name != null)
                {
                    foreach (var resource in assembly.GetManifestResourceNames())
                    {
                        string path = resource;

                        if (path.StartsWith(name + "."))
                        {
                            path = path.Substring(name.Length + 1);
                        }

                        Debug.Log($"Registered Embedded Resource{path} ({assembly.GetName().Name}) {resource}");
                        EmbeddedResources[path] = (assembly, resource);
                    }
                }
            }
        }
        
        internal static byte[] Load(string path)
        {
            path = path.Replace('\\', '.');
            path = path.Replace('/', '.');

            if (EmbeddedResources.TryGetValue(path, out var resource))
            {
                Debug.Log("Found Resource!");
                using Stream stream = resource.assembly.GetManifestResourceStream(resource.fullpath) ?? throw new Exception($"Cannot open embedded resource '{resource.fullpath}'.");
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }

            throw new Exception($"Embedded resource '{path}' not found in any loaded assembly.");
        }
    }
}
