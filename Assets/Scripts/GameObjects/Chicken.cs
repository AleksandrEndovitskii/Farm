using GameObjects.Utils;

namespace GameObjects
{
    /*
        • Если еды достаточно, то курица несёт одно яйцо за 10 сек
        • 1 единицы пшеницы хватает на 30 сек курице
     */
    public class Chicken : IBuyable, IPlaceable
    {
        public int BuyPrice { get; }
    }
}
