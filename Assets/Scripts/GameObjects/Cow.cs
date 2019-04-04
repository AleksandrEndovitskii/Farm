using GameObjects.Utils;
using Managers;

namespace GameObjects
{
    public class Cow : IBuyable, IPlaceable, IFeedable, IFuelRequiringProducer
    {
        public int HaveFuelForSecondsCount { get; }
        public int WillProduceAfterSecondsCount { get; }

        public Cow()
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
