using System.Collections.Generic;
using System.Collections;
using Hybrid;

namespace App
{
    public class Player : MonoBehaviour
    {
        public IEnumerator Example1(float seconds)
        {
            yield return StartCoroutine(Example2(seconds));
        }
        
        public IEnumerator Example2(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }
    }
}