using System;

namespace Hybrid
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class RequireComponentAttribute : Attribute
    {
        public Type Type { get; }

        public RequireComponentAttribute(Type type)
        {
            Type = type;
        }

        public RequireComponentAttribute()
        {
            
        }
    }
}