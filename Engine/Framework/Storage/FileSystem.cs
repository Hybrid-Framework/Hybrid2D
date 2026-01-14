using System.Collections.Generic;
using System.IO;
using System;

namespace Hybrid
{
    // General
    public static partial class FileSystem
    {
        private static string CurrentDirectory = GetBasePath();

        public static string GetCurrentDirectory()
        {
            return CurrentDirectory;
        }

        public static bool SetCurrentDirectory(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                string destination = Path.GetFullPath(Path.Combine(GetCurrentDirectory(), path));

                if (destination.StartsWith(GetBasePath(), StringComparison.OrdinalIgnoreCase))
                {
                    if (Directory.Exists(destination))
                    {
                        CurrentDirectory = destination;
                        return true;
                    }
                }
            }

            return false;
        }
        
        private static string ResolvePath(string path)
        {
            return Path.Combine(GetBasePath(), path);
        }
        
        public static string GetBasePath()
        {
            return SDL.GetBasePath();
        }
    }
    
    // File
    public static partial class FileSystem
    {
        public static bool FileExists(string path)
        {
            path = ResolvePath(path);
            {
                if (string.IsNullOrEmpty(path))
                    throw new Exception($"Invalid path {path}");
            
                return File.Exists(path);
            }
        }

        public static bool FileWrite(string path, byte[] bytes)
        {
            path = ResolvePath(path);
            {
                if (bytes == null)
                    throw new Exception($"Invalid bytes");
                
                if (string.IsNullOrEmpty(path))
                    throw new Exception($"Invalid path {path}");

                if (File.Exists(path))
                    throw new Exception($"File already exists {path}");

                string directory = Path.GetDirectoryName(path);
                {
                    if (!string.IsNullOrEmpty(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                }

                File.WriteAllBytes(path, bytes);
                {
                    return File.Exists(path);
                }
            }
        }

        public static byte[] FileRead(string path)
        {
            path = ResolvePath(path);
            {
                if (string.IsNullOrEmpty(path))
                    throw new Exception($"Invalid path {path}");
                
                if (!File.Exists(path))
                    throw new Exception($"File does not exist {path}");

                return File.ReadAllBytes(path);
            }
        }

        public static bool FileCreate(string path)
        {
            path = ResolvePath(path);
            {
                if (string.IsNullOrEmpty(path))
                    throw new Exception($"Invalid path {path}");
                
                if (File.Exists(path))
                    throw new Exception($"File already exists {path}");

                string directory = Path.GetDirectoryName(path);
                {
                    if (!string.IsNullOrEmpty(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                }

                File.Create(path).Dispose();
                {
                    return File.Exists(path);
                }
            }
        }
        
        public static bool FileDelete(string path)
        {
            path = ResolvePath(path);
            {
                if (string.IsNullOrEmpty(path))
                    throw new Exception($"Invalid path {path}");
                
                if (!File.Exists(path))
                    throw new Exception($"File does not exist {path}");

                File.Delete(path);
                {
                    return !File.Exists(path);
                }
            }
        }
        
        public static bool FileCopy(string source, string destination, bool overwrite = false)
        {
            destination = ResolvePath(destination);
            source = ResolvePath(source);
            {
                if (string.IsNullOrEmpty(source))
                    throw new Exception($"Invalid source path {source}");
            
                if (string.IsNullOrEmpty(destination))
                    throw new Exception($"Invalid destination path {destination}");

                if (!File.Exists(source))
                    throw new Exception($"Source file does not exist {source}");

                if (File.Exists(destination) && !overwrite)
                    throw new Exception($"Destination file already exists {destination}");

                string directory = Path.GetDirectoryName(destination);
                {
                    if (!string.IsNullOrEmpty(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                }

                File.Copy(source, destination, overwrite);
                {
                    return File.Exists(destination);
                }
            }
        }
        
        public static bool FileMove(string source, string destination, bool overwrite = false)
        {
            destination = ResolvePath(destination);
            source = ResolvePath(source);
            {
                if (string.IsNullOrEmpty(source))
                    throw new Exception($"Invalid source path {source}");
            
                if (string.IsNullOrEmpty(destination))
                    throw new Exception($"Invalid destination path {destination}");

                if (!File.Exists(source))
                    throw new Exception($"Source file does not exist {source}");

                if (File.Exists(destination) && !overwrite)
                    throw new Exception($"Destination file already exists {destination}");

                string directory = Path.GetDirectoryName(destination);
                {
                    if (!string.IsNullOrEmpty(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                }

                File.Move(source, destination, overwrite);
                {
                    return File.Exists(destination);
                }
            }
        }
    }
    
    // Folder
    public static partial class FileSystem
    {
        public static bool FolderExists(string path)
        {
            path = ResolvePath(path);
            {
                if (string.IsNullOrEmpty(path))
                    throw new Exception($"Invalid path {path}");
            
                return Directory.Exists(path);
            }
        }
        
        public static bool FolderCreate(string path)
        {
            path = ResolvePath(path);
            {
                if (string.IsNullOrEmpty(path))
                    throw new Exception($"Invalid path {path}");
            
                if (Directory.Exists(path))
                    throw new Exception($"Folder already exists {path}");
                
                Directory.CreateDirectory(path);
                {
                    return Directory.Exists(path);
                }
            }
        }
        
        public static bool FolderDelete(string path)
        {
            path = ResolvePath(path);
            {
                if (string.IsNullOrEmpty(path))
                    throw new Exception($"Invalid path {path}");
                
                if (!Directory.Exists(path))
                    throw new Exception($"Folder does not exist {path}");

                if (Directory.GetFiles(path).Length > 0)
                    throw new Exception($"Can't delete folder that contains files {path}");

                Directory.Delete(path, false);
                {
                    return !Directory.Exists(path);
                }
            }
        }
        
        public static string[] GetFiles(string path)
        {
            path = ResolvePath(path);
            {
                if (string.IsNullOrEmpty(path))
                    throw new Exception($"Invalid path {path}");
                
                if(!Directory.Exists(path))
                    throw new Exception($"Folder does not exist {path}");

                var result = new List<string>();
                {
                    foreach (var folder in Directory.GetDirectories(path))
                    {
                        result.Add(folder);
                    }

                    foreach (var file in Directory.GetFiles(path))
                    {
                        result.Add(file);
                    }

                    return result.ToArray();
                }
            }
        }
    }
}