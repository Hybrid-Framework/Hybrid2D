using System.Runtime.InteropServices;

namespace Hybrid
{
    internal class AndroidBootstrap : Bootstrap
    {
        protected override void Execute(Config config)
        {
            Platform.SetPlatform(new AndroidPlatform(), config);
            
            var assembly = typeof(SDL).Assembly;
            NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
            {
                return library switch
                {
                    "SDL3_image" => IntPtr.Zero,
                    "SDL3_mixer" => IntPtr.Zero,
                    "SDL3_ttf"   => IntPtr.Zero,
                    "SDL3"       => IntPtr.Zero,
                    _            => IntPtr.Zero
                };
            });
            
            SDL.Initialize();
            Run();
        }

        protected static void Run()
        {
            while (Engine.Instance.Run())
            {
                // Run application
            }
        }
    }
}