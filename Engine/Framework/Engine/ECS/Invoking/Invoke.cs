using System;

namespace Hybrid
{
    // Invoke
    internal sealed class Invoke
    {
        public object Owner;
        public Action Action;
        public string Name;
        public float Delay;
        public float Repeat;
        public bool Looping;
        public bool Done;

        
        internal Invoke(object owner, Action action, string name, float delay, float repeat, bool looping)
        {
            Debug.Log($"Invoke '{name}' started on '{owner.GetType().Name}'");
            this.Owner = owner;
            this.Action = action;
            this.Name = name;
            this.Delay = delay;
            this.Repeat = repeat;
            this.Looping = looping;
            this.Done = false;
        }

        public void MoveNext()
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

        public void Stop()
        {
            if(Done) return;
            Done = true;
            
            Debug.Log($"Invoke '{Name}' stopped on '{Owner.GetType().Name}'");
            Invoking.StopInvoke(Owner, Name);
        }
    }
}