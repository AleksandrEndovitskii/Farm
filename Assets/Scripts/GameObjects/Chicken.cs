using GameObjects.Utils;

namespace GameObjects
{
    /*
        • Если еды достаточно, то курица несёт одно яйцо за 10 сек
        • 1 единицы пшеницы хватает на 30 сек курице
     */
    public class Chicken : IBuyable, IPlaceable, IFeedable, IFuelRequiringProducer
    {
        public int BuyPrice { get; }

        public int HaveFuelForSecondsCount { get; }
        public int WillProduceAfterSecondsCount { get; }

        public Chicken(int haveFuelForSecondsCount, int willProduceAfterSecondsCount)
        {
            HaveFuelForSecondsCount = haveFuelForSecondsCount;
            WillProduceAfterSecondsCount = willProduceAfterSecondsCount;
        }

        public void Feed(IFood food)
        {

        }
    }
}
