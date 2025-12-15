using System.Runtime.InteropServices;

namespace Hybrid
{
    internal class IOSBootstrap : Bootstrap
    {
        protected override void Execute(Config config)
        {
            Platform.SetPlatform(new IOSPlatform(), config);
            
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
            
            SDL.Initialize();
            SDL.MainFunction main = Run;
            SDL.RunApp(0, IntPtr.Zero, main, IntPtr.Zero);
        }
        
        protected static int Run(int argc, IntPtr argv)
        {
            while (Engine.Instance.Run())
            {
                // Run application
            }
            
            return 0;
        }
    }
}