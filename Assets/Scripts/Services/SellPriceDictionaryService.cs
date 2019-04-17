using GameObjects.Utils;
using Services.Utils;
using Utils;

namespace Services
{
    public class SellPriceDictionaryService : TypeValueDictionary, IInitializable
    {
        public void Initialize()
        {
            //
        }

        public void SetSellPriceForType<T>(int price) where T : ISellable
        {
            base.SetValueForType(typeof(T), price);
        }

        public int GetSellPriceForType(ISellable sellable)
        {
            return base.GetValueForType(sellable.GetType());
        }
    }
}
