namespace GameObjects.Utils
{
    public interface IFuelRequiringProducer<T> : IProducer<T> where T : class, IProduction, new()
    {
        int HaveFuelForSecondsCount { get; }
    }
}
