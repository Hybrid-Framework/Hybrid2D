using System.IO;
using System;

namespace Hybrid
{
    public sealed partial class Storage : Module<Storage>
    {
        private Storage() { }

        // Initialize
        internal override void OnInitialize()
        {
            
        }

        // Dispose
        internal override void OnDispose()
        {
            
        }
    }
    
    public partial class Storage
    {
        public static string BasePath
        {
            get => SDL.GetBasePath();
        }
        
        public static void ShowResources()
        {
            foreach (var file in Directory.GetFiles(BasePath))
            {
                Debug.Log($"File: {file}");
            }
            
            foreach (var directory in Directory.GetDirectories(BasePath))
            {
                Debug.Log($"Directory: {directory}");
                
                foreach (var file in Directory.GetFiles(directory))
                {
                    Debug.Log($"File: {file}");
                }
            }
        }
    }
}