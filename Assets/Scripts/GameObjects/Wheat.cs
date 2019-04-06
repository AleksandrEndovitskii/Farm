using GameObjects.Utils;
using Managers;

namespace GameObjects
{
    // Пшеницей можно покормить курицу или корову;
    public class Wheat : AProducer<Wheat>, IBuyable, IPlaceable, IFood, IProduction, IInventoryItem
    {
        public override int ProductionDuration
        {
            get
            {
                return GameManager.Instance.ProductionDurationDictionaryService
                    .GetProductionDuration<Wheat>();
            }
        }

        public override void ResetWillProduceAfterSecondsCount()
        {
            WillProduceAfterSecondsCount = GameManager.Instance.ProductionDurationDictionaryService
                .GetProductionDuration<Wheat>();
        }
    }
}
