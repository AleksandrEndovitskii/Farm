using GameObjects.Utils;

namespace GameObjects.Production
{
    public class Milk : ISellable, IProduction
    {
        public int SellPrice { get; }
    }
}
