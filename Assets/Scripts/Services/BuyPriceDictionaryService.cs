using GameObjects.Items;
using GameObjects.Utils;
using Services.Utils;
using Utils;

namespace Services
{
    public class BuyPriceDictionaryService : TypeValueDictionary, IInitializable
    {
        public void Initialize()
        {
            // test data
            SetBuyPriceForType<Wheat>(10);
            SetBuyPriceForType<Chicken>(20);
            SetBuyPriceForType<Cow>(30);
        }

        public void SetBuyPriceForType<T>(int price) where T : IBuyable
        {
            base.SetValueForType(typeof(T), price);
        }

        public int GetBuyPriceForType<T>() where T : IBuyable
        {
            return base.GetValueForType(typeof(T));
        }
    }
}
