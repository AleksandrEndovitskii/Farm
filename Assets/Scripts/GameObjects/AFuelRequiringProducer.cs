using GameObjects.Utils;

namespace GameObjects
{
    public abstract class AFuelRequiringProducer : AProducer, IFuelRequiringProducer
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
