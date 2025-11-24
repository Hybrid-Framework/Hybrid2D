using System.Runtime.InteropServices;

namespace Hybrid
{
    internal class AndroidBootstrap : Bootstrap
    {
        protected override Platform Platform { get; set; } = new AndroidPlatform();
        

        internal override void Execute()
        {
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

        internal static void Run()
        {
            Engine.StartMainLoop();
            
            while (Engine.IsRunning)
            {
                Engine.MainLoop();
            }
            
            Engine.Quit();
        }
    }
}