using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    public static class Tags
    {
        private static readonly List<Tag> AllTags = new List<Tag>();
        internal static readonly Tag Untagged = new("Untagged");
        internal const int MaxTags = 256;

        static Tags()
        {
            AllTags.Add(Untagged);
            
            for (int i = 1; i < MaxTags; i++)
            {
                AllTags.Add(new Tag(string.Empty));
            }
        }
        
        
        public static Tag CreateTag(string name)
        {
            // Existing Tag
            if (AllTags.Select(l => l.Name).Concat([ Untagged.Name ]).Any(n => string.Equals(n, name, StringComparison.OrdinalIgnoreCase)))
            {
                Debug.Warning($"Tag '{name}' already exists");
                {
                    return Untagged;
                }
            }
            
            // Invalid Tag
            if (string.IsNullOrWhiteSpace(name))
            {
                Debug.Warning("Tag is empty");
                {
                    return Untagged;
                }
            }
            
            // Create Tag
            var tag = AllTags.FirstOrDefault(t => string.Equals(t.Name, string.Empty, StringComparison.OrdinalIgnoreCase));
            {
                if (tag == null)
                {
                    Debug.Warning($"Maximum tags '{MaxTags}' reached");
                    {
                        return Untagged;
                    }
                }
            
                tag.Name = name;
                return tag;
            }
        }
        
        public static void DeleteTag(string name)
        {
            // Existing Tag
            if (string.Equals(name, Untagged.Name, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Warning($"Can't remove required '{name}' tag");
                {
                    return;
                }
            }
            
            // Invalid Tag
            if (string.IsNullOrWhiteSpace(name))
            {
                Debug.Warning("Tag is empty");
                {
                    return;
                }
            }

            // Delete Tag
            var index = GetTagIndex(name);
            {
                if (index >= 0)
                {
                    foreach (var gameObject in GameObject.FindGameObjectsByTag(AllTags[index]))
                    {
                        gameObject.Tag = Untagged;
                    }
                
                    AllTags[index].Name = string.Empty;
                }
            }
        }
        
        public static Tag GetTag(string name)
        {
            // Get Tag By Name
            var tag = AllTags.FirstOrDefault(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase));
            {
                if (tag == null)
                {
                    Debug.Warning($"Tag '{name}' not found");
                    {
                        return Untagged;
                    }
                }

                return tag;
            }
        }

        public static Tag GetTag(int index)
        {
            if (index < 0 || index >= AllTags.Count)
            {
                Debug.Warning($"Tag '{index}' not found");
                {
                    return Untagged;
                }
            }

            return AllTags[index];
        }
        
        public static string GetTagName(int index)
        {
            // Find Tag Name
            if (index < 0 || index >= AllTags.Count)
            {
                Debug.Warning($"Tag '{index}' not found");
                {
                    return Untagged.Name;
                }
            }

            // Return
            return AllTags[index].Name;
        }
        
        public static int GetTagIndex(string name)
        {
            // Find Tag Index
            for (int i = 0; i < AllTags.Count; i++)
            {
                if (string.Equals(AllTags[i].Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            
            // Fallback
            Debug.Warning($"Tag '{name}' not found");
            {
                return -1;
            }
        }
        
        public static string GetTagName(Tag tag)
        {
            return GetTagName(GetTagIndex(tag));
        }
        
        public static int GetTagIndex(Tag tag)
        {
            return GetTagIndex(tag.Name);
        }

        public static Tag[] GetTags()
        {
            return AllTags.ToArray();
        }
    }
}