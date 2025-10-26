using System;

namespace Hybrid
{
    // Singleton
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _instance;
        public static T Instance
        {
            get => Create();
        }
        
        protected Singleton()
        {
            if (_instance != null)
            {
                throw new Exception($"A singleton '{typeof(T).Name}' already exists create instance using '{typeof(T).Name}.Create();' instead");
            }
        }

        public static T Create()
        {
            if (_instance == null)
            {
                _instance = new T();
            }

            return _instance;
        }

        public void Destroy()
        {
            _instance = null;
        }
    }
}