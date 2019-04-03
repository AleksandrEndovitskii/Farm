namespace GameObjects.Utils
{
    public interface IFuelRequiringProducer : IProducer
    {
        int HaveFuelForSecondsCount { get; }
    }
}
