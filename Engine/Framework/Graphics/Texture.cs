using System.Collections.Generic;
using System.IO;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Texture : Module
    {
        internal static List<Texture2D> AllTexture2D { get; private set; } = new List<Texture2D>();
        
        internal override void Destroy()
        {
            foreach(var texture2D in AllTexture2D) texture2D.Destroy();
        }
    }

    // Texture Management
    public unsafe partial class Texture
    {
        public static Texture2D CreateTexture2D(string path)
        {
            var texture2D = new Texture2D(path);
            AllTexture2D.Add(texture2D);
            return texture2D;
        }

        public static void DestroyTexture2D(Texture2D texture)
        {
            AllTexture2D.Remove(texture);
            texture.Destroy();
        }
    }
    
    // Texture API
    public partial class Texture
    {
        public static void SetTexture2DPixel(Texture2D texture2D, int x, int y, Color color)
        {
            texture2D.SetPixel(x, y, color);
        }

        public static Color GetTexture2DPixel(Texture2D texture2D, int x, int y)
        {
            return texture2D.GetPixel(x, y);
        }

        public static void SetTexture2DPixels(Texture2D texture2D, Color[] colors)
        {
            texture2D.SetPixels(colors);
        }

        public static Color[] GetTexture2DPixels(Texture2D texture2D)
        {
            return texture2D.GetPixels();
        }
        
        public static int GetTexture2DWidth(Texture2D texture2D)
        {
            return texture2D.GetWidth();
        }
        
        public static int GetTexture2DHeight(Texture2D texture2D)
        {
            return texture2D.GetHeight();
        }
        
        public static void Texture2DApply(Texture2D texture2D)
        {
            texture2D.Apply();
        }
    }
}