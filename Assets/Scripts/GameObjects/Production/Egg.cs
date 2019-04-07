using GameObjects.Utils;

namespace GameObjects.Production
{
    public class Egg : ISellable, IProduction, IInventoryItem
    {
        public int SellPrice { get; }
    }
}
