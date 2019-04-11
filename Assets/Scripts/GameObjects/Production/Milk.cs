using GameObjects.Utils;

namespace GameObjects.Production
{
    public class Milk : ISellable, IProduction, IInventoryItem, IFood
    {
        public int SellPrice { get; }
    }
}
