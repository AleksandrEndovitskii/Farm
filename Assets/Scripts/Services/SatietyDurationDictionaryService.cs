using System;
using GameObjects;
using GameObjects.Utils;
using Services.Utils;
using Utils;

namespace Services
{
    public class SatietyDurationDictionaryService : TypeTypeValueDictionary, IInitializable
    {
        public void Initialize()
        {
            SetSatietyForProduction<Chicken, Wheat>(10); // 1 единицы пшеницы хватает на 30 сек курице
            SetSatietyForProduction<Cow, Wheat>(20); // 1 единицы пшеницы хватает на 20 сек корове;
        }

        public void SetSatietyForProduction<T1, T2>(int value) where T1 : IFeedable where T2 : IFood
        {
            base.SetValueForType<T1, T2>(value);
        }

        public int GetSatietyForProduction(Type type1, Type type2)
        {
            return base.GetValueForType(type1, type2);
        }
    }
}
