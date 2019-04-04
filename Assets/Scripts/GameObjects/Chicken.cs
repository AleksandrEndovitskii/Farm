using GameObjects.Utils;
using Managers;

namespace GameObjects
{
    /*
        • 1 единицы пшеницы хватает на 30 сек курице
     */
    public class Chicken : IBuyable, IPlaceable, IFeedable, IFuelRequiringProducer
    {
        public int HaveFuelForSecondsCount { get; }
        public int WillProduceAfterSecondsCount { get; }

        public Chicken()
        {
            GameManager.Instance.TimeManager.SecondPassed += TimeManagerOnSecondPassed;
        }

        public void Feed(IFood food)
        {
            if (food is Wheat)
            {

            }
        }

        private void TimeManagerOnSecondPassed()
        {

        }
    }
}
