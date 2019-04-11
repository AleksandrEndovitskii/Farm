using GameObjects.Utils;
using Managers;

namespace GameObjects
{
    public abstract class AFuelRequiringProducer<T1, T2> : AProducer<T1>, IFuelRequiringProducer<T2>, IFeedable<T2> where T1 : class, IProduction, new() where T2 : IFood
    {
        public int HaveFuelForSecondsCount { get; protected set; }

        public override void TryProduceProduct()
        {
            if (HaveFuelForSecondsCount > 0)
            {
                base.TryProduceProduct();

                HaveFuelForSecondsCount--;
            }
        }

        public void Feed(T2 food)
        {
            HaveFuelForSecondsCount += GameManager.Instance.SatietyDurationDictionaryService.GetSatietyForProduction<T1, T2>();
        }
    }
}
