using GameObjects.Utils;

namespace GameObjects
{
    /*
        • Если еды достаточно, то корова даёт молоко раз в 20 сек;
        • 1 единицы пшеницы хватает на 20 сек корове;
     */
    public class Cow : IBuyable, IPlaceable, IFeedable, IFuelRequiringProducer
    {
        public int BuyPrice { get; }

        public int HaveFuelForSecondsCount { get; }
        public int WillProduceAfterSecondsCount { get; }

        public Cow(int haveFuelForSecondsCount, int willProduceAfterSecondsCount)
        {
            HaveFuelForSecondsCount = haveFuelForSecondsCount;
            WillProduceAfterSecondsCount = willProduceAfterSecondsCount;
        }

        public void Feed(IFood food)
        {

        }
    }
}
