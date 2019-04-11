namespace GameObjects.Utils
{
    public interface IFuelRequiringProducer<T> where T : IFood
    {
        int HaveFuelForSecondsCount { get; }

        void Feed(T food);
    }
}
