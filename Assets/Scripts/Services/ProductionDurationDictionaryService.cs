using GameObjects;
using GameObjects.Production;
using GameObjects.Utils;
using Services.Utils;
using Utils;

namespace Services
{
    public class ProductionDurationDictionaryService : TypeValueDictionary, IInitializable
    {
        public void Initialize()
        {
            SetProductionDuration<Wheat>(10); // Пшеница вырастает за 10 сек, после чего можно собрать урожай(1 единица урожая с одной клетки), затем рост начинается заново;
            SetProductionDuration<Egg>(10); // Если еды достаточно, то курица несёт одно яйцо за 10 сек
            SetProductionDuration<Milk>(20); // Если еды достаточно, то корова даёт молоко раз в 20 сек;
        }

        public void SetProductionDuration<T>(int value) where T : IProduction
        {
            base.SetValueForType<T>(value);
        }

        public int GetProductionDuration<T>() where T : IProduction
        {
            return base.GetValueForType<T>();
        }
    }
}
