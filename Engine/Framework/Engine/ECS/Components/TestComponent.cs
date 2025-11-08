using System;

namespace Hybrid
{
    public class TestComponent : Component
    {
        public int Health = 0;
        
        private int score = 0;
        public int Score
        {
            get => score;
            set => score = value;
        }

        protected int xp = 0;
        public int XP
        {
            get => xp;
            set => xp = value;
        }
    }
}