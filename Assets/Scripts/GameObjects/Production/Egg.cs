using GameObjects.Utils;

namespace GameObjects.Production
{
    public class Egg : ISellable, IProduction
    {
        public int SellPrice { get; }
    }
}
