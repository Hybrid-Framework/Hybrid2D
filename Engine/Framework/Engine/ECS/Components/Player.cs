using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    public class Player : Script
    {
        public IEnumerator Example1()
        {
            yield return new WaitForFixedUpdate();
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds();
            yield return null;
        }
        
        public IEnumerator Example2()
        {
            yield return new WaitForSeconds();
        }
    }
}