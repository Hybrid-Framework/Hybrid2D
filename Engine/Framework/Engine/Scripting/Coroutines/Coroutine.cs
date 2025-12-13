using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    public sealed class Coroutine : YieldInstruction
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
            if (!Done && Enumerator != null)
            {
                // Process Instruction
                if (Instruction != null)
                {
                    // Coroutine
                    if (Instruction is Coroutine coroutine)
                    {
                        if (!coroutine.Done)
                        {
                            return;
                        }
                    }
                    
                    // Wait For Seconds
                    if (Instruction is WaitForSeconds wait)
                    {
                        if ((wait.Remaining -= Time.DeltaTime) > 0f)
                        {
                            return;
                        }
                    }
                    
                    Instruction = null;
                }

                // Step Coroutine
                if (!Enumerator.MoveNext())
                {
                    Stop();
                    return;
                }

                // Assign Instruction
                Instruction = Enumerator.Current as YieldInstruction;
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