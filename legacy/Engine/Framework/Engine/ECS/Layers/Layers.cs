using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    public static class Layers
    {
        private static readonly List<Layer> AllLayers = new List<Layer>();
        internal static readonly Layer Default = new("Default");
        internal const int MaxLayers = 32;

        static Layers()
        {
            AllLayers.Add(Default);
            
            for (int i = 1; i < MaxLayers; i++)
            {
                AllLayers.Add(new Layer(string.Empty));
            }
        }
        
        
        public static Layer CreateLayer(string name)
        {
            // Existing Layer
            if (AllLayers.Select(l => l.Name).Concat([ Default.Name ]).Any(n => string.Equals(n, name, StringComparison.OrdinalIgnoreCase)))
            {
                Debug.Warning($"Layer '{name}' already exists");
                {
                    return Default;
                }
            }
            
            // Invalid Layer
            if (string.IsNullOrWhiteSpace(name))
            {
                Debug.Warning("Layer is empty");
                {
                    return Default;
                }
            }
            
            // Create Layer
            var layer = AllLayers.FirstOrDefault(t => string.Equals(t.Name, string.Empty, StringComparison.OrdinalIgnoreCase));
            {
                if (layer == null)
                {
                    Debug.Warning($"Maximum layers '{MaxLayers}' reached");
                    {
                        return Default;
                    }
                }
            
                layer.Name = name;
                return layer;
            }
        }
        
        public static void DeleteLayer(string name)
        {
            // Existing Layer
            if (string.Equals(name, Default.Name, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Warning($"Can't remove required '{name}' layer");
                {
                    return;
                }
            }
            
            // Invalid Layer
            if (string.IsNullOrWhiteSpace(name))
            {
                Debug.Warning("Layer is empty");
                {
                    return;
                }
            }

            // Delete Layer
            var index = GetLayerIndex(name);
            {
                if (index >= 0)
                {
                    foreach (var gameObject in GameObject.FindGameObjectsByLayer(AllLayers[index]))
                    {
                        gameObject.Layer.Remove(AllLayers[index]);
                    }
                
                    AllLayers[index].Name = string.Empty;
                }
            }
        }
        
        public static Layer GetLayer(string name)
        {
            // Get layer By Name
            var layer = AllLayers.FirstOrDefault(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase));
            {
                if (layer == null)
                {
                    Debug.Warning($"Layer '{name}' not found");
                    {
                        return Default;
                    }
                }

                return layer;
            }
        }

        public static Layer GetLayer(int index)
        {
            if (index < 0 || index >= AllLayers.Count)
            {
                Debug.Warning($"Layer '{index}' not found");
                {
                    return Default;
                }
            }

            return AllLayers[index];
        }
        
        public static string GetLayerName(int index)
        {
            // Find Layer Name
            if (index < 0 || index >= AllLayers.Count)
            {
                Debug.Warning($"Layer '{index}' not found");
                {
                    return Default.Name;
                }
            }

            // Return
            return AllLayers[index].Name;
        }
        
        public static int GetLayerIndex(string name)
        {
            // Find Layer Index
            for (int i = 0; i < AllLayers.Count; i++)
            {
                if (string.Equals(AllLayers[i].Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            
            // Fallback
            Debug.Warning($"Layer '{name}' not found");
            {
                return -1;
            }
        }
        
        public static string GetLayerName(Layer layer)
        {
            return GetLayerName(GetLayerIndex(layer));
        }
        
        public static int GetLayerIndex(Layer layer)
        {
            return GetLayerIndex(layer.Name);
        }

        public static Layer[] GetLayers()
        {
            return AllLayers.ToArray();
        }
    }
}