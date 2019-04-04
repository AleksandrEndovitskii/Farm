using System;
using System.Collections.Generic;
using System.Linq;
using GameObjects.Utils;
using Utils;

namespace Services
{
    public class ProductionDurationService : IInitializable
    {
        private Dictionary<Type, int> _productionDuration = new Dictionary<Type, int>();

        public void Initialize()
        {

        }

        public void SetDurationForProduction<T>(int price) where T : IProducer
        {
            _productionDuration.Add(typeof(T), price);
        }

        public int GetDurationForProduction<T>() where T : IProducer
        {
            if (_productionDuration.All(x => x.Key != typeof(T)))
            {
                throw new ArgumentOutOfRangeException(string.Format("No production duration was specified for {0}", typeof(T).Name));
            }

            var keyValuePair = _productionDuration.First(x => x.Key == typeof(T));

            return keyValuePair.Value;
        }
    }
}
