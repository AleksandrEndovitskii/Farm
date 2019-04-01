using System;
using System.Collections.Generic;
using System.Linq;
using GameObjects.Utils;
using Utils;

namespace Services
{
    public class PriceService : IInitializable
    {
        private Dictionary<Type, int> _buyablePrices = new Dictionary<Type, int>();

        public void Initialize()
        {

        }

        public void SetPriceForType<T>(int price) where T : IBuyable
        {
            _buyablePrices.Add(typeof(T),price);
        }

        public int GetPriceForType<T>() where T : IBuyable
        {
            if (_buyablePrices.All(x => x.Key.GetType() != typeof(T)))
            {
                throw new ArgumentOutOfRangeException(string.Format("No price was specified for {0}", typeof(T).Name));
            }

            var keyValuePair = _buyablePrices.First(x => x.Key.GetType() == typeof(T));

            return keyValuePair.Value;
        }
    }
}
