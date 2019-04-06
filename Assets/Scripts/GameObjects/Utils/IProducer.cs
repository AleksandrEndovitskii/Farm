namespace GameObjects.Utils
{
    public interface IProducer<T> where T : IProduction
    {
        int WillProduceAfterSecondsCount { get; }
    }
}
