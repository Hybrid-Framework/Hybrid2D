using static Engine.Internal.SDL2.SDL;
using StbImageSharp;

namespace Engine
{
    public unsafe class Imager
    {
        public static IntPtr LoadTexture(IntPtr renderer, string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Image file not found: {path}");
            }

            IntPtr texture;
            ImageResult image;
            using (var stream = File.OpenRead(path))
            {
                image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
            }
            
            fixed (byte* pixels = image.Data)
            {
                IntPtr surface = SDL_CreateRGBSurfaceFrom
                (
                    (IntPtr)pixels,
                    image.Width,
                    image.Height,
                    32,
                    image.Width * 4,                // pitch = width * bytes per pixel
                    0x000000FF,                     // R mask
                    0x0000FF00,                     // G mask
                    0x00FF0000,                     // B mask
                    unchecked((uint)0xFF000000)     // A mask
                );

                texture = SDL_CreateTextureFromSurface(renderer, surface);
                SDL_FreeSurface(surface);
            }

            return texture;
        }
    }
}