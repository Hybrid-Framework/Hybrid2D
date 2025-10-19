using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    public class PlatformWeb : Platform
    {
        public PlatformWeb(GameBehaviour gameBehaviour)
        {
            GameBehaviour = gameBehaviour;
        }
        
        internal override void Bootstrap()
        {
            SystemPlatform = SystemPlatform.Web;
            
            Emscripten.SetWindowTitle("Hello Emscripten");
            string title = Emscripten.GetWindowTitle();
            Console.WriteLine("Title: " + title);
        }
    }
}