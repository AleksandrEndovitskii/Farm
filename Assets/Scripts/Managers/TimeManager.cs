using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Managers
{
    public class TimeManager : MonoBehaviour, IInitializable
    {
        public event Action SecondPassed = delegate { };

        public void Initialize()
        {
            StartCoroutine(Stopwatch());
        }

        private IEnumerator Stopwatch()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                Debug.Log("Second is passed.");

                SecondPassed.Invoke();
            }
        }
    }
}
