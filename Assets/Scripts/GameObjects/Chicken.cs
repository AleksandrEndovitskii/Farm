using GameObjects.Utils;
using Managers;

namespace GameObjects
{
    public class Chicken : AFuelRequiringProducer, IBuyable, IFeedable, IPlaceable
    {
        public override void ResetWillProduceAfterSecondsCount()
        {
            WillProduceAfterSecondsCount = GameManager.Instance.ProductionDurationDictionaryService
                .GetProductionDurationForProducer<Chicken>();
        }

        public void Feed(IFood food)
        {
            if (food is Wheat)
            {
                HaveFuelForSecondsCount += GameManager.Instance.SatietyDurationDictionaryService.GetSatietyForProduction<Chicken>();
            }
        }
    }
}
