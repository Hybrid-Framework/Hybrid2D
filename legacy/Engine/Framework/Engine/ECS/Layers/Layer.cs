using System;

namespace Hybrid
{
    public class Layer
    {
        internal string Name { get; set; }

        internal Layer(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}