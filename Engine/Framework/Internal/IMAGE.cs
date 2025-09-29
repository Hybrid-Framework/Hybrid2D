using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace SDL3;

public static unsafe partial class IMAGE
{
    private const string nativeLibName = "SDL3_image";
    
    [LibraryImport(nativeLibName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr IMG_LoadTexture(IntPtr renderer, string file);
}