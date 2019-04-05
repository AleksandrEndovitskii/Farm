using GameObjects;
using GameObjects.Utils;
using Services.Utils;
using Utils;

namespace Services
{
    public class SatietyDurationDictionaryService : TypeValueDictionary, IInitializable
    {
        public void Initialize()
        {
            SetSatietyForProduction<Chicken>(10); // 1 единицы пшеницы хватает на 30 сек курице
            SetSatietyForProduction<Cow>(20); // 1 единицы пшеницы хватает на 20 сек корове;
        }

        public void SetSatietyForProduction<T>(int value) where T : IFeedable
        {
            base.SetValueForType<T>(value);
        }

        public int GetSatietyForProduction<T>() where T : IFeedable
        {
            return base.GetValueForType<T>();
        }
    }
}
