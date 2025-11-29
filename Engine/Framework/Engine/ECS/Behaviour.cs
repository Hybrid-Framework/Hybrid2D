using System;

namespace Hybrid
{
    // Behaviour
    public class Behaviour : Object
    {
        public Transform Transform { get; internal set; }
        public GameObject GameObject { get; internal set; }
    }
}