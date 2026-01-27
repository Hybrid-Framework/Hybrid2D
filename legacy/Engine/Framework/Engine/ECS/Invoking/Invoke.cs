using System;

namespace Hybrid
{
    // Invoke
    internal sealed class Invoke
    {
        internal Object Owner;
        internal Action Action;
        internal string Name;
        internal float Delay;
        internal float Repeat;
        internal bool Looping;
        internal bool Done;

        
        internal Invoke(Object owner, Action action, string name, float delay, float repeat, bool looping)
        {
            // Debug.Log($"Invoke '{name}' started on '{owner.GetType().Name}'");
            this.Owner = owner;
            this.Action = action;
            this.Name = name;
            this.Delay = delay;
            this.Repeat = repeat;
            this.Looping = looping;
            this.Done = false;
        }

        internal void MoveNext()
        {
            if (!Done)
            {
                if (Time.Timer >= Delay)
                {
                    Action?.Invoke();

                    if (Looping)
                    {
                        Delay = Time.Timer + Repeat;
                    }
                    else
                    {
                        Stop();
                    }
                }
            }
        }

        internal void Stop()
        {
            if(Done) return;
            Done = true;
            
            // Debug.Log($"Invoke '{Name}' stopped on '{Owner.GetType().Name}'");
            Invokes.StopInvoke(Owner, Name);
        }
    }
}