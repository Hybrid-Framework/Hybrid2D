using System;

namespace Hybrid
{
    public abstract class Behaviour : Object
    {
        public GameObject GameObject { get; internal set; }
        public Transform Transform { get; internal set; }
    }
}