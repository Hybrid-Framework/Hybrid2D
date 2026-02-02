using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    internal static class Properties
    {
        // Texture
        internal const string Texture_ColorSpace = "SDL.texture.colorspace"; // number
        internal const string Texture_Format = "SDL.texture.format"; // number
        internal const string Texture_Access = "SDL.texture.access"; // number
        internal const string Texture_Width = "SDL.texture.width"; // number
        internal const string Texture_Height = "SDL.texture.height"; // number
        
        // Text Input
        internal const string Text_InputType = "SDL.textinput.type"; // number 
        internal const string Text_InputCapitalization = "SDL.textinput.capitalization"; // number
        internal const string Text_InputAutocorrect = "SDL.textinput.autocorrect"; // boolean
        internal const string Text_InputMultiline = "SDL.textinput.multiline"; // boolean
        internal const string Text_InputAndroidInputType = "SDL.textinput.android.inputtype"; // number
    }
}