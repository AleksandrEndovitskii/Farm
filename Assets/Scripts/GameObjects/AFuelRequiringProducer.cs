using GameObjects.Utils;

namespace GameObjects
{
    public abstract class AFuelRequiringProducer<T> : AProducer<T>, IFuelRequiringProducer<T> where T : class, IProduction, new()
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
    }
}
