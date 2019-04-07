using GameObjects.Utils;

namespace GameObjects.Production
{
    public class Milk : ISellable, IProduction, IInventoryItem
    {
        public int SellPrice { get; }
    }
}
