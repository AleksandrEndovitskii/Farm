using System;
using GameObjects.Utils;
using Managers;
using Services.Utils;
using Utils;

namespace Services
{
    public class SellPriceDictionaryService : TypeValueDictionary, IInitializable
    {
        public void Initialize()
        {
            foreach (var configBuyTypeValue in GameManager.Instance.ConfigurationService.Config.SellTypeValues)
            {
                SetSellPriceForType(configBuyTypeValue.Key, configBuyTypeValue.Value);
            }
        }

        public void SetSellPriceForType<T>(int price) where T : ISellable
        {
            base.SetValueForType(typeof(T), price);
        }

        public void SetSellPriceForType(Type type, int price)
        {
            base.SetValueForType(type, price);
        }

        public int GetSellPrice(ISellable sellable)
        {
            return base.GetValueForType(sellable.GetType());
        }

        public int GetSellPrice(Type type)
        {
            return base.GetValueForType(type);
        }
    }
}
