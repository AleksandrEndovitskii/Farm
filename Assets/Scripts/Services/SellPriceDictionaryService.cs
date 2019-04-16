using GameObjects.Utils;
using Services.Utils;

namespace Services
{
    public class SellPriceDictionaryService : TypeValueDictionary
    {
        public void SetSellPriceForType<T>(int price) where T : ISellable
        {
            base.SetValueForType(typeof(T), price);
        }

        public int GetSellPriceForType<T>() where T : ISellable
        {
            return base.GetValueForType(typeof(T));
        }
    }
}
