using GameObjects.Utils;
using Managers;

namespace GameObjects
{
    // Пшеницей можно покормить курицу или корову;
    public class Wheat : IBuyable, IPlaceable, IFood, IProducer
    {
        public int WillProduceAfterSecondsCount { get; }

        public Wheat()
        {
            GameManager.Instance.TimeManager.SecondPassed += TimeManagerOnSecondPassed;
        }

        private void TimeManagerOnSecondPassed()
        {
            
        }
    }
}
