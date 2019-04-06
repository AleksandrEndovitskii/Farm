using GameObjects.Utils;

namespace GameObjects
{
    public abstract class AFuelRequiringProducer<T> : AProducer<T>, IFuelRequiringProducer where T : IProduction
    {
        public int HaveFuelForSecondsCount { get; protected set; }

        public override void TryProduceProduct()
        {
            if (HaveFuelForSecondsCount > 0)
            {
                HaveFuelForSecondsCount--;

                base.TryProduceProduct();
            }
        }
    }
}
