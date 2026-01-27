using System.Runtime.InteropServices;
using System.IO;
using System;

namespace Hybrid
{
    internal static class Resolver
    {
        internal static void ResolveLibraries()
        {
            if (OperatingSystem.IsIOS())
            {
                var assembly = typeof(SDL).Assembly;
                var frameworks = Path.Combine(AppContext.BaseDirectory!, "Frameworks");
                NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
                {
                    return library switch
                    {
                        "SDL3_image" => NativeLibrary.Load(Path.Combine(frameworks, "SDL3_image.framework", "SDL3_image"), asm, path),
                        "SDL3_mixer" => NativeLibrary.Load(Path.Combine(frameworks, "SDL3_mixer.framework", "SDL3_mixer"), asm, path),
                        "SDL3_ttf" => NativeLibrary.Load(Path.Combine(frameworks, "SDL3_ttf.framework", "SDL3_ttf"), asm,path),
                        "SDL3" => NativeLibrary.Load(Path.Combine(frameworks, "SDL3.framework", "SDL3"), asm, path),
                        _ => IntPtr.Zero
                    };
                });
            }
        }
    }
}