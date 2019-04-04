using GameObjects.Utils;
using Services.Utils;
using Utils;

namespace Services
{
    public class BuyPriceDictionaryService : TypeValueDictionary, IInitializable
    {
        public void Initialize()
        {

        }

        public void SetBuyPriceForType<T>(int price) where T : IBuyable
        {
            base.SetValueForType<T>(price);
        }

        public int GetBuyPriceForType<T>() where T : IBuyable
        {
            return base.GetValueForType<T>();
        }
    }
}
