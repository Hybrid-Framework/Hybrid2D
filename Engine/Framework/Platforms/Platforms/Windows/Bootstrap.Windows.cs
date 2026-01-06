using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    internal class WindowsBootstrap : Bootstrap
    {
        protected override void Execute(Game game)
        {
            Platform.SetPlatform(new WindowsPlatform(), game);
            
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
            Platform.Game.StartMainLoop();
            
            while (Platform.Game.IsRunning)
            {
                Platform.Game.MainLoop();
            }
            
            Platform.Game.Quit();
        }
    }
}