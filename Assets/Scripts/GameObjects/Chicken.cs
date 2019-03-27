using GameObjects.Utils;
using UnityEngine;

namespace GameObjects
{
    /*
        • Если еды достаточно, то курица несёт одно яйцо за 10 сек
        • 1 единицы пшеницы хватает на 30 сек курице
     */
    public class Chicken : MonoBehaviour, IBuyable
    {
        public int BuyPrice { get; }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
