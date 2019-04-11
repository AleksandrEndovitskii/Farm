using GameObjects.Production;
using GameObjects.Utils;

namespace GameObjects
{
    public class Chicken : AFuelRequiringProducer<Egg, Wheat>, IBuyable, IPlaceable
    {

    }
}
