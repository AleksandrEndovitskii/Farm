using GameObjects;
using GameObjects.Utils;
using Services.Utils;
using Utils;

namespace Services
{
    public class ProductionDurationDictionaryService : TypeValueDictionary, IInitializable
    {
        public void Initialize()
        {
            SetDurationForProduction<Wheat>(10); // Пшеница вырастает за 10 сек, после чего можно собрать урожай(1 единица урожая с одной клетки), затем рост начинается заново;
            SetDurationForProduction<Chicken>(10); // Если еды достаточно, то курица несёт одно яйцо за 10 сек
            SetDurationForProduction<Cow>(20); // Если еды достаточно, то корова даёт молоко раз в 20 сек;
        }

        public void SetDurationForProduction<T>(int value) where T : IProducer
        {
            base.SetValueForType<T>(value);
        }

        public int GetDurationForProduction<T>() where T : IProducer
        {
            return base.GetValueForType<T>();
        }
    }
}
