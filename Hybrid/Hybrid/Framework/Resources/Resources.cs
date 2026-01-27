using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System;

namespace Hybrid
{
    internal sealed unsafe class Resources : Module
    {
        private static readonly Dictionary<string, (Assembly assembly, string fullpath)> EmbeddedResources = new(StringComparer.OrdinalIgnoreCase);
        

        internal override void OnInitialize()
        {
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

                        EmbeddedResources[path] = (assembly, resource);
                        {
                            // Debug.Log($"Registered Embedded Resource: {path} ({assembly.GetName().Name}) {resource}");
                        }
                    }
                }
            }
        }
        
        internal static SDL.IOStream* CreateStream(string path, out GCHandle handle)
        {
            // Find Resource
            if (!EmbeddedResources.TryGetValue(path.Replace('\\', '.').Replace('/', '.'), out var resource))
            {
                throw new Exception($"Resource '{path}' not found.");
            }

            // Load bytes from resource stream
            using Stream stream = resource.assembly.GetManifestResourceStream(resource.fullpath) ?? throw new Exception($"Failed to open '{resource.fullpath}' resource.");
            using MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);
            byte[] data = ms.ToArray();

            // Create Stream
            handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            return SDL.OpenIO((void*)handle.AddrOfPinnedObject(), (nuint)data.Length);
        }
    }
}
