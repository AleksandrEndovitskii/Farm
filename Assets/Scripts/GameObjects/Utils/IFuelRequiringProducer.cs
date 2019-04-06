namespace GameObjects.Utils
{
    public interface IFuelRequiringProducer : IProducer<IProduction>
    {
        int HaveFuelForSecondsCount { get; }
    }
}
