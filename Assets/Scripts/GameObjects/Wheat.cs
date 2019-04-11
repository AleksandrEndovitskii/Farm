using GameObjects.Utils;

namespace GameObjects
{
    // Пшеницей можно покормить курицу или корову;
    public class Wheat : AProducer<Wheat>, IBuyable, IPlaceable, IFood, IProduction, IInventoryItem
    {

    }
}
