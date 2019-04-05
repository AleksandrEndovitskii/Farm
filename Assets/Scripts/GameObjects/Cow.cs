using System;
using GameObjects.Utils;
using Managers;
using UnityEngine;

namespace GameObjects
{
    public class Cow : IBuyable, IPlaceable, IFeedable, IFuelRequiringProducer
    {
        public Action ProductionIsReady = delegate { };

        public int HaveFuelForSecondsCount { get; private set; }
        public int WillProduceAfterSecondsCount { get; private set; }

        public Cow()
        {
            GameManager.Instance.TimeManager.SecondPassed += TimeManagerOnSecondPassed;
        }

        public void Feed(IFood food)
        {
            if (food is Wheat)
            {
                HaveFuelForSecondsCount += GameManager.Instance.SatietyDurationDictionaryService.GetSatietyForProduction<Cow>();
            }
        }

        private void TimeManagerOnSecondPassed()
        {
            if (HaveFuelForSecondsCount > 0)
            {
                WillProduceAfterSecondsCount--;
                HaveFuelForSecondsCount--;
            }

            if (WillProduceAfterSecondsCount == 0)
            {
                WillProduceAfterSecondsCount =
                    GameManager.Instance.ProductionDurationDictionaryService.GetProductionDurationForProducer<Cow>();

                ProductionIsReady.Invoke();

                Debug.Log(string.Format("ProductionIsReady {0}", this.GetType().Name));
            }
        }
    }
}
