using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    public class Coroutine : YieldInstruction
    {
        internal IEnumerator Enumerator { get; set; }
        internal object Owner { get; set; }
        internal string Name { get; set; }
        internal bool Done { get; set; }
        

        internal Coroutine(object owner, string name, IEnumerator enumerator)
        {
            this.Enumerator = enumerator;
            this.Owner = owner;
            this.Name = name;
            this.Done = false;
        }
        
        internal void MoveNext()
        {
            
        }
        
        internal void Stop()
        {
            Done = true;
        }
    }
}