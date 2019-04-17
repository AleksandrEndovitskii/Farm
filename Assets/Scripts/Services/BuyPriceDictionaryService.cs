using System;
using GameObjects.Utils;
using Managers;
using Services.Utils;
using Utils;

namespace Services
{
    public class BuyPriceDictionaryService : TypeValueDictionary, IInitializable
    {
        public void Initialize()
        {
            foreach (var configBuyTypeValue in GameManager.Instance.ConfigurationService.Config.BuyTypeValues)
            {
                SetBuyPriceForType(configBuyTypeValue.Key, configBuyTypeValue.Value);
            }
        }

        public void SetBuyPriceForType<T>(int price) where T : IBuyable
        {
            base.SetValueForType(typeof(T), price);
        }

        public void SetBuyPriceForType(Type type, int price)
        {
            base.SetValueForType(type, price);
        }

        public int GetBuyPriceForType<T>() where T : IBuyable
        {
            return base.GetValueForType(typeof(T));
        }

        public int GetBuyPriceForType(Type type)
        {
            return base.GetValueForType(type);
        }
    }
}
