using GameObjects.Production;
using GameObjects.Utils;

namespace GameObjects
{
    public class Cow : AFuelRequiringProducer<Milk, Wheat>, IBuyable, IPlaceable
    {

    }
}
