using GameObjects.Utils;
using Services.Utils;
using Utils;

namespace Services
{
    public class SellPriceDictionaryService : TypeValueDictionary, IInitializable
    {
        public void Initialize()
        {

        }

        public void SetSellPriceForType<T>(int price) where T : ISellable
        {
            base.SetValueForType<T>(price);
        }

        public int GetSellPriceForType<T>() where T : ISellable
        {
            return base.GetValueForType<T>();
        }
    }
}
