using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Internal
    public partial class LayerMask
    {
        private uint mask { get; set; }

        internal LayerMask()
        {
            ResetToDefault();
        }
    }
    
    // Layer Mask
    public partial class LayerMask
    {
        public void ResetToDefault()
        {
            mask = 1u << Layers.GetLayerIndex(Layers.Default);
        }

        public void Set(Layer layer)
        {
            // Nothing
            if (layer == Layers.Nothing)
            {
                ResetToDefault();
            }
            
            // Everything
            else if (layer == Layers.Everything)
            {
                ResetToDefault();
                
                foreach (var lyr in Layers.GetLayers())
                {
                    mask |= 1u << Layers.GetLayerIndex(lyr);
                }
            }
            
            // Layer
            else
            {
                int index = Layers.GetLayerIndex(layer);
                
                if (index >= 0)
                {
                    mask |= 1u << index;
                }
            }
        }

        public void Remove(Layer layer)
        {
            var index = Layers.GetLayerIndex(layer);
            
            if (index >= 0)
            {
                mask &= ~(1u << index);
            }

            if (mask == 0)
            {
                ResetToDefault();
            }
        }

        public bool Contains(Layer layer)
        {
            var index = Layers.GetLayerIndex(layer);

            if (index >= 0)
            {
                return (mask & (1u << index)) != 0;
            }

            return false;
        }

        public override string ToString()
        {
            var layers = Layers.GetLayers();
            var result = new List<string>();

            for (int i = 0; i < layers.Length; i++)
            {
                if ((mask & (1u << i)) != 0)
                {
                    result.Add(layers[i].Name);
                }
            }

            return string.Join(", ", result).TrimEnd(' ', ',');
        }
    }
}