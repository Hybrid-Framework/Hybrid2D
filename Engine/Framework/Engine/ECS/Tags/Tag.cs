using System;

namespace Hybrid
{
    public class Tag
    {
        internal string Name { get; set; }

        internal Tag(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}