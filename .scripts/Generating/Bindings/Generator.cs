using System;

namespace Bindings
{
    public class Generator
    {
        public void Fetch()
        {
            Console.WriteLine("Fetching");
            
            string basePath = Path.GetFullPath(AppContext.BaseDirectory);
            string includePath = Path.Combine(basePath, "Include");

            foreach (var folder in Directory.GetDirectories(includePath))
            {
                Console.WriteLine("Folder: " + folder);
                
                foreach (var file in Directory.GetFiles(folder))
                {
                    Console.WriteLine("File: " + file);
                }
            }
        }
    }
}