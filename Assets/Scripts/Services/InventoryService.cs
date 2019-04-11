using System;
using System.Collections.Generic;
using System.Linq;
using GameObjects.Utils;
using UnityEngine;
using Utils;

namespace Services
{
    public class InventoryService : IInitializable
    {
        public Action<Type, int> InventoryItemAmountChanged = delegate {  };

        private List<IInventoryItem> _inventoryItems = new List<IInventoryItem>();

        public void Initialize()
        {

        }

        public void Put(IInventoryItem inventoryItem)
        {
            if (inventoryItem == null)
            {
                Debug.LogWarning("Trying to add to inventory null.");

                return;
            }

            _inventoryItems.Add(inventoryItem);

            Debug.Log(string.Format("Inventory item({0}) was putted in to inventory.", (inventoryItem.GetType().Name)));

            InventoryItemAmountChanged.Invoke(inventoryItem.GetType(), _inventoryItems.Count(x=>x.GetType() == inventoryItem.GetType()));
        }

        public IInventoryItem TryPop<T>() where T : IInventoryItem
        {
            var inventoryItem = _inventoryItems.FirstOrDefault(x=>x.GetType() == typeof(T));

            if (inventoryItem == null)
            {
                Debug.LogWarning(string.Format("Inventory do not contain items of specified type - {0}.", typeof(T).Name));
            }

            Debug.Log(string.Format("Inventory item({0}) was popped from inventory.", (inventoryItem.GetType().Name)));

            return inventoryItem;
        }

        public int GetCount<T>() where T : IInventoryItem
        {
            var result = _inventoryItems.Count(x => x.GetType() == typeof(T));

            return result;
        }
    }
}
