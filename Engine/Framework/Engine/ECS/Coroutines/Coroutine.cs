using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Coroutine
    public sealed class Coroutine : YieldInstruction
    {
        internal YieldInstruction Instruction { get; set; }
        internal IEnumerator Enumerator { get; set; }
        internal Object Owner { get; set; }
        internal string Name { get; set; }
        internal bool Done { get; set; }
        internal bool Paused { get; set; }
        

        internal Coroutine(Object owner, string name, IEnumerator enumerator)
        {
            Debug.Log($"Coroutine '{name}' started on '{owner.GetType().Name}'");
            this.Enumerator = enumerator;
            this.Owner = owner;
            this.Name = name;
            this.Done = false;
            this.Paused = false;
        }
        
        public void MoveNext()
        {
            if (!Done && Enumerator != null)
            {
                // Pause
                if (Paused)
                {
                    return;
                }
                
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
                    else if (Instruction is WaitForSeconds wait)
                    {
                        if ((wait.Remaining -= Time.DeltaTime) > 0f)
                        {
                            return;
                        }
                    }
                    
                    // Wait For Frames
                    else if (Instruction is WaitForFrames frames)
                    {
                        if ((frames.Remaining -= 1) > 0f)
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

        public void Pause()
        {
            Paused = true;
        }

        public void Resume()
        {
            Paused = false;
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