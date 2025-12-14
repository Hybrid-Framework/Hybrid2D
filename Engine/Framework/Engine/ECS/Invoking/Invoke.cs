using System;

namespace Hybrid
{
    internal sealed class Invoke
    {
        public object Owner;
        public Action Action;
        public string Name;
        public float Delay;
        public float Repeat;
        public bool Done;

        
        internal Invoke(object owner, Action action, string name, float delay, float repeat)
        {
            Debug.Log($"Invoke '{name}' started on '{owner.GetType().Name}'");
            this.Owner = owner;
            this.Action = action;
            this.Name = name;
            this.Delay = delay;
            this.Repeat = repeat;
            this.Done = false;
        }

        public void MoveNext()
        {
            if (!Done)
            {
                if (Time.Timer >= Delay)
                {
                    Action?.Invoke();

                    if (Repeat > 0)
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
            Invoking.CancelInvoke(Owner, Name);
        }
    }
}