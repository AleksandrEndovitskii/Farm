namespace GameObjects.Utils
{
    public interface IFeedable<T> where T : IFood
    {
        void Feed(T food);
    }
}
