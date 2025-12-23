using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    public static class Tags
    {
        private static readonly List<Tag> AllTags = new List<Tag>();
        public static readonly Tag Untagged = new Tag("Untagged");
        public const int MaxTags = 256;

        static Tags()
        {
            AllTags.Add(Untagged);
        }
        

        public static Tag CreateTag(string name)
        {
            // Invalid Tag
            if (string.IsNullOrEmpty(name))
            {
                Debug.Warning("Tag is empty");
                {
                    return Untagged;
                }
            }

            // Maximum Tag
            if (AllTags.Count >= MaxTags)
            {
                Debug.Warning($"Maximum tags '{MaxTags}' reached");
                {
                    return Untagged;
                }
            }

            // Existing Tag
            if (AllTags.Any(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                Debug.Warning($"Tag '{name}' already exists");
                {
                    return Untagged;
                }
            }

            // Create
            var tag = new Tag(name);
            AllTags.Add(tag);
            return tag;
        }

        public static void DeleteTag(string name)
        {
            // Required Tag
            if (string.Equals(name, Untagged.Name, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Warning($"Can't remove required '{Untagged.Name}' tag");
                {
                    return;
                }
            }

            Tag tag = GetTag(name);
            
            // If Valid Tag
            if (tag != null && tag != Untagged)
            {
                // For Each GameObject Using Tag
                foreach (var gameObject in GameObject.FindGameObjectsByTag(tag))
                {
                    // Set Untagged
                    gameObject.Tag = Untagged;
                }
                
                // Remove
                AllTags.Remove(tag);
            }
        }

        public static Tag GetTag(string name)
        {
            Tag tag = AllTags.FirstOrDefault(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase));

            if (tag == null)
            {
                Debug.Warning($"Tag '{name}' not found");
                {
                    return Untagged;
                }
            }

            return tag;
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

        public static Tag[] GetTags()
        {
            return AllTags.ToArray();
        }
    }
}