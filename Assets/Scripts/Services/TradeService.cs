using System;
using GameObjects.Utils;
using Managers;
using UnityEngine;
using Utils;

namespace Services
{
    public class TradeService : IInitializable
    {
        public void Initialize()
        {

        }

        public void Sell(ref ISellable sellable)
        {
            var price = GameManager.Instance.SellPriceDictionaryService.GetSellPrice(sellable);

            GameManager.Instance.InventoryService.RemoveItemByType(sellable.GetType());

            GameManager.Instance.MoneyService.MoneyAmount += price;

            sellable = null;
        }

        public void SellAllItemsByType(Type type)
        {
            var price = GameManager.Instance.SellPriceDictionaryService.GetSellPrice(type);
            var count = GameManager.Instance.InventoryService.GetCount(type);

            GameManager.Instance.InventoryService.RemoveAllItemsByType(type);

            Debug.Log(string.Format("All items of type {0} was sold.", type));

            GameManager.Instance.MoneyService.MoneyAmount += price * count;
        }

        public T TryBuy<T>() where T: IBuyable, new()
        {
            var price = GameManager.Instance.BuyPriceDictionaryService.GetBuyPriceForType<T>();

            if (price > GameManager.Instance.MoneyService.MoneyAmount)
            {
                Debug.Log(string.Format("Not enough money to purchase {0} for {1} money - you have only {2} money.", typeof(T).Name,
                    price, GameManager.Instance.MoneyService.MoneyAmount));

                return default;
            }

            GameManager.Instance.MoneyService.MoneyAmount -= price;

            return new T();
        }
    }
}
