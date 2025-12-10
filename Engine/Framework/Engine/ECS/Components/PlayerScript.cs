using System;

namespace Hybrid
{
    public class PlayerScript : Script
    {
        public override void OnAwake()
        {
            Debug.Log("Player Awake");
        }

        public override void OnStart()
        {
            Debug.Log("Player Start");
        }
    }
}