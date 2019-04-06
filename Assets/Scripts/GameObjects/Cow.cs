using GameObjects.Production;
using GameObjects.Utils;
using Managers;

namespace GameObjects
{
    public class Cow : AFuelRequiringProducer<Milk>, IBuyable, IFeedable, IPlaceable
    {
        public override int ProductionDuration
        {
            get
            {
                return GameManager.Instance.ProductionDurationDictionaryService
                    .GetProductionDuration<Milk>();
            }
        }

        public override void ResetWillProduceAfterSecondsCount()
        {
            WillProduceAfterSecondsCount = GameManager.Instance.ProductionDurationDictionaryService
                .GetProductionDuration<Milk>();
        }

        public void Feed(IFood food)
        {
            if (food is Wheat)
            {
                HaveFuelForSecondsCount += GameManager.Instance.SatietyDurationDictionaryService.GetSatietyForProduction<Cow>();
            }
        }
    }
}
