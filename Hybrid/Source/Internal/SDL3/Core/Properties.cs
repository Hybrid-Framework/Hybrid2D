using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public static class Properties
    {
        // Texture
        public const string Texture_ColorSpace = "SDL.texture.colorspace"; // number
        public const string Texture_Format = "SDL.texture.format"; // number
        public const string Texture_Access = "SDL.texture.access"; // number
        public const string Texture_Width = "SDL.texture.width"; // number
        public const string Texture_Height = "SDL.texture.height"; // number
        
        // Text Input
        public const string Text_InputType = "SDL.textinput.type"; // number 
        public const string Text_InputCapitalization = "SDL.textinput.capitalization"; // number
        public const string Text_InputAutocorrect = "SDL.textinput.autocorrect"; // boolean
        public const string Text_InputMultiline = "SDL.textinput.multiline"; // boolean
        public const string Text_InputAndroidInputType = "SDL.textinput.android.inputtype"; // number
    }
}