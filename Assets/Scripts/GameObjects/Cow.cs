using GameObjects.Utils;
using Managers;

namespace GameObjects
{
    /*
        • Если еды достаточно, то корова даёт молоко раз в 20 сек;
        • 1 единицы пшеницы хватает на 20 сек корове;
     */
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
