using System;
using GameObjects.Utils;
using Managers;
using UnityEngine;

namespace GameObjects
{
    public abstract class AProducer : IProducer
    {
        public Action ProductionIsReady = delegate { };

        public int WillProduceAfterSecondsCount { get; protected set; }

        public AProducer()
        {
            ResetWillProduceAfterSecondsCount();

            GameManager.Instance.TimeManager.SecondPassed += TimeManagerOnSecondPassed;
        }

        public abstract void ResetWillProduceAfterSecondsCount();

        public virtual void TryProduceProduct()
        {
            WillProduceAfterSecondsCount--;

            if (WillProduceAfterSecondsCount == 0)
            {
                ResetWillProduceAfterSecondsCount();

                Debug.Log(string.Format("Production {0} is ready.", this.GetType().Name));

                ProductionIsReady.Invoke();
            }
        }

        private void TimeManagerOnSecondPassed()
        {
            TryProduceProduct();
        }
    }
}
