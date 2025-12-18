using System.Collections;
using Hybrid;

namespace App
{
    public class Player : MonoBehaviour
    {
        public override void OnAwake()
        {
            StartCoroutine(testCoroutine());
        }

        IEnumerator testCoroutine()
        {
            yield return new WaitForSeconds(3);
        }
    }
}