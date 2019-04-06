using GameObjects.Production;
using GameObjects.Utils;
using Managers;

namespace GameObjects
{
    public class Chicken : AFuelRequiringProducer<Egg>, IBuyable, IFeedable, IPlaceable
    {
        public override int ProductionDuration
        {
            get
            {
                return GameManager.Instance.ProductionDurationDictionaryService
                    .GetProductionDuration<Egg>();
            }
        }

        public override void ResetWillProduceAfterSecondsCount()
        {
            WillProduceAfterSecondsCount = GameManager.Instance.ProductionDurationDictionaryService
                .GetProductionDuration<Egg>();
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
