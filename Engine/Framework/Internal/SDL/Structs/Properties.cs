using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    public static class Properties
    {
        // Texture
        public const string PropertyTextureColorSpace           = "SDL.texture.colorspace";
        public const string PropertyTextureFormat               = "SDL.texture.format";
        public const string PropertyTextureAccess               = "SDL.texture.access";
        public const string PropertyTextureWidth                = "SDL.texture.width";
        public const string PropertyTextureHeight               = "SDL.texture.height";
        
        // Text Input
        public const string PropertyTextInputType               = "SDL.textinput.type";
        public const string PropertyTextInputCapitalization     = "SDL.textinput.capitalization";
        public const string PropertyTextInputAutocorrect        = "SDL.textinput.autocorrect";
        public const string PropertyTextInputMultiline          = "SDL.textinput.multiline";
        public const string PropertyTextInputAndroidInputType   = "SDL.textinput.android.inputtype";
    }
}