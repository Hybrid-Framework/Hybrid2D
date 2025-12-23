using System;

namespace Hybrid
{
    public class Tag
    {
        public string Name { get; private set; }

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