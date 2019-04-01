using GameObjects.Utils;

namespace GameObjects
{
    /*
        • Пшеница вырастает за 10 сек, после чего можно собрать урожай (1 единица урожая с одной клетки), затем рост начинается заново;
        • Пшеницей можно покормить курицу или корову;
     */
    public class Wheat : IBuyable
    {
        public int BuyPrice { get; }
    }
}
