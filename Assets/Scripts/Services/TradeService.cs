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
            //
        }

        public void Sell(ISellable sellable)
        {

        }

        public void Buy(IBuyable buyable)
        {

        }

        public T TryBuy<T>() where T: IBuyable, new()
        {
            var price = GameManager.Instance.PriceService.GetPriceForType<T>();

            if (price > GameManager.Instance.MoneyService.MoneyAmount)
            {
                Debug.Log(string.Format("Not enough money to purchase {0} for {1} money - you have only {2} money.", typeof(T).Name,
                    price, GameManager.Instance.MoneyService.MoneyAmount));

                return default(T);
            }

            GameManager.Instance.MoneyService.MoneyAmount -= price;

            return new T();
        }
    }
}
