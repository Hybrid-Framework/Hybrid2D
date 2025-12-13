using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    public class Coroutine : YieldInstruction
    {
        internal YieldInstruction Instruction { get; set; }
        internal IEnumerator Enumerator { get; set; }
        internal object Owner { get; set; }
        internal string Name { get; set; }
        internal bool Done { get; set; }
        

        internal Coroutine(object owner, string name, IEnumerator enumerator)
        {
            Debug.Log($"Coroutine '{name}' started on '{owner.GetType().Name}'");
            this.Enumerator = enumerator;
            this.Owner = owner;
            this.Name = name;
            this.Done = false;
        }
        
        public void MoveNext()
        {
            // Invalid Coroutine
            if (Done || Enumerator == null)
            {
                Done = true;
                return;
            }

            // Process Instruction
            if (Instruction != null)
            {
                Debug.Log($"Process Instruction: {Instruction} for {Name} on {Owner.GetType().Name}");
            }

            // Stop Coroutine
            if (!Enumerator.MoveNext())
            {
                Done = true;
                return;
            }

            // Assign Instruction
            if (Enumerator.Current is YieldInstruction instruction)
            {
                Instruction = instruction;
                Debug.Log($"Assign Instruction: {Instruction} for {Name} on {Owner.GetType().Name}");
            }
            else
            {
                Instruction = null;
                Debug.Log($"Assign Instruction: null for {Name} on {Owner.GetType().Name}");
            }
        }
        
        public void Stop()
        {
            // Stop
            if(Done) return;
            Done = true;
            
            Debug.Log($"Coroutine '{Name}' stopped on '{Owner.GetType().Name}'");
            Coroutines.StopCoroutine(Owner, this);
        }
    }
}