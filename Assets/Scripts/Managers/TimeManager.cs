using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Managers
{
    public class TimeManager : MonoBehaviour, IInitializable
    {
        public event Action<int> SecondPassed = delegate { };

        public int SecondsPassedCount
        {
            get
            {
                return _secondsPassedCount;
            }
        }

        private int _secondsPassedCount;

        public void Initialize()
        {
            StartCoroutine(Stopwatch());
        }

        private IEnumerator Stopwatch()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                _secondsPassedCount++;

                Debug.Log("Second is passed.");

                SecondPassed.Invoke(SecondsPassedCount);
            }
        }
    }
}
