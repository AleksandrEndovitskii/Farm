using System;
using GameObjects.Utils;
using Managers;
using UnityEngine;

namespace GameObjects
{
    // Пшеницей можно покормить курицу или корову;
    public class Wheat : IBuyable, IPlaceable, IFood, IProducer
    {
        public Action ProductionIsReady = delegate { };

        public int WillProduceAfterSecondsCount { get; private set; }

        public Wheat()
        {
            GameManager.Instance.TimeManager.SecondPassed += TimeManagerOnSecondPassed;
        }

        private void TimeManagerOnSecondPassed()
        {
            WillProduceAfterSecondsCount--;

            if (WillProduceAfterSecondsCount == 0)
            {
                WillProduceAfterSecondsCount =
                    GameManager.Instance.ProductionDurationDictionaryService.GetProductionDurationForProducer<Wheat>();

                ProductionIsReady.Invoke();

                Debug.Log(string.Format("ProductionIsReady {0}", this.GetType().Name));
            }
        }
    }
}
