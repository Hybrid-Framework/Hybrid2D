using System.Runtime.InteropServices;

namespace SDL
{
    public static partial class SDL
    {
        [DllImport("SDL", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int SDL_Init([NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int SDL_InitSubSystem([NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SDL_QuitSubSystem([NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Uint32")]
        public static extern uint SDL_WasInit([NativeTypeName("Uint32")] uint flags);

        [DllImport("SDL", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SDL_Quit();
    }
}
