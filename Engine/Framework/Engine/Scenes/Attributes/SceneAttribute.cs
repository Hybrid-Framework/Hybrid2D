using System;

namespace Hybrid
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SceneAttribute : Attribute
    {
        internal string Name { get; private set; }
        internal int Index { get; private set; }
        
        public SceneAttribute(string name, int index)
        {
            this.Index = index;
            this.Name = name;
        }
    }
}