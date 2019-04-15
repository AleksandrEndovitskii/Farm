namespace GameObjects.Utils
{
    public interface IProducer
    {
        int WillProduceAfterSecondsCount { get; }
        IProduction Production { get; }

        IProduction TryCollectProduction();
    }
}
