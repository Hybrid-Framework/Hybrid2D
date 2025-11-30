using System;

namespace Hybrid
{
    public partial class Storage : Module<Storage>
    {
        private Storage() { }

        // Initialize
        internal override void OnInitialize()
        {
            
        }

        // Dispose
        internal override void OnDispose()
        {
            base.OnDispose();
        }
    }
    
    public partial class Storage
    {
        public static string BasePath
        {
            get => SDL.GetBasePath();
        }
        
        public static void ShowFiles()
        {
            foreach (var file in Directory.GetFiles(BasePath))
            {
                Console.WriteLine($"File: {file}");
            }
            
            foreach (var directory in Directory.GetDirectories(BasePath))
            {
                Console.WriteLine($"Directory: {directory}");
                
                foreach (var file in Directory.GetFiles(directory))
                {
                    Console.WriteLine($"File: {file}");
                }
            }
        }
    }
}