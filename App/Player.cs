using System.Collections.Generic;
using System.Collections;
using Hybrid;

namespace App
{
    public class Player : MonoBehaviour
    {
        public IEnumerator Example1()
        {
            yield return StartCoroutine(Example2);
        }
        
        public IEnumerator Example2()
        {
            yield return new WaitForFrames(60);
        }
    }
}