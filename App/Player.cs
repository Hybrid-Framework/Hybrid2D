using System.Collections.Generic;
using System.Collections;
using Hybrid;

namespace App
{
    public class Player : Script
    {
        public IEnumerator Example1()
        {
            yield return new WaitForFixedUpdate();
            yield return StartCoroutine(Example2);
            yield return new WaitForEndOfFrame();
        }
        
        public IEnumerator Example2()
        {
            yield return new WaitForSeconds(1);
        }
    }
}