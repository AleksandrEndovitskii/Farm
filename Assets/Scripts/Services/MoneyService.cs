using Utils;

namespace Services
{
    public class MoneyService : IInitializable
    {
        public int MoneyAmount { get; set;}

        public void Initialize()
        {
            MoneyAmount = 100;
        }
    }
}
