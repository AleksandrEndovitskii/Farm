using GameObjects;
using GameObjects.Production;
using GameObjects.Utils;
using Services.Utils;
using Utils;

namespace Services
{
    public class ProducerProductionDictionaryService : TypeTypeDictionary<IProducer, IProduction>, IInitializable
    {
        public void Initialize()
        {
            SetProducerForProduction<Wheat, Wheat>();
            SetProducerForProduction<Cow, Milk>();
            SetProducerForProduction<Chicken, Egg>();
        }

        public void SetProducerForProduction<T1, T2>() where T1 : IProducer where T2 : IProduction
        {
            base.Set<T1,T2>();
        }

        public T2 GetProductionForProducer<T1, T2>() where T1 : IProducer where T2 : IProduction
        {
            return base.Get<T1, T2>();
        }
    }
}
