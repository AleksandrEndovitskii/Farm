using GameObjects.Utils;
using Managers;

namespace GameObjects
{
    public class Cow : AFuelRequiringProducer, IBuyable, IFeedable, IPlaceable
    {
        public override void ResetWillProduceAfterSecondsCount()
        {
            WillProduceAfterSecondsCount = GameManager.Instance.ProductionDurationDictionaryService
                .GetProductionDurationForProducer<Cow>();
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
