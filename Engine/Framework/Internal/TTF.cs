using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace SDL3;

public static unsafe partial class TTF
{
    private const string nativeLibName = "SDL3_ttf";
    
    [LibraryImport(nativeLibName)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial SDL.SDLBool TTF_Init();

    // Open a font file at a given point size
    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial IntPtr TTF_OpenFont(string file, float size);

    // Render text to an SDL_Surface using solid rendering
    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial IntPtr TTF_RenderText_Solid(IntPtr font, string text, nuint length, SDL.SDL_Color fg);
}