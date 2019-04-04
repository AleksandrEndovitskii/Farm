using System;
using System.Collections.Generic;
using System.Linq;
using GameObjects;
using GameObjects.Utils;
using Utils;

namespace Services
{
    public class SatietyDurationService : IInitializable
    {
        private Dictionary<Type, int> _satietyDuration = new Dictionary<Type, int>();

        public void Initialize()
        {
            SetSatietyForProduction<Chicken>(10); // 1 единицы пшеницы хватает на 30 сек курице
            SetSatietyForProduction<Cow>(20); // 1 единицы пшеницы хватает на 20 сек корове;
        }

        public void SetSatietyForProduction<T>(int price) where T : IFeedable
        {
            _satietyDuration.Add(typeof(T), price);
        }

        public int GetSatietyForProduction<T>() where T : IFeedable
        {
            if (_satietyDuration.All(x => x.Key != typeof(T)))
            {
                throw new ArgumentOutOfRangeException(string.Format("No satiety duration was specified for {0}", typeof(T).Name));
            }

            var keyValuePair = _satietyDuration.First(x => x.Key == typeof(T));

            return keyValuePair.Value;
        }
    }
}
