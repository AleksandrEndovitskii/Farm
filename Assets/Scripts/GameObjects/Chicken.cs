using GameObjects.Utils;
using Managers;

namespace GameObjects
{
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
