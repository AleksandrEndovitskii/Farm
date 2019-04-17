using System;
using System.Collections.Generic;
using System.Linq;
using GameObjects.Items;
using GameObjects.Utils;
using Managers;
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
            GameManager.Instance.MoneyService.MoneyAmountChanged += MoneyAmountChanged;
        }

        private void MoneyAmountChanged(int value)
        {
            // money is kinda inventory item
            InventoryItemAmountChanged.Invoke(typeof(Money), value);
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

                return null;
            }

            Debug.Log(string.Format("Inventory item({0}) was popped from inventory.", (inventoryItem.GetType().Name)));

            InventoryItemAmountChanged.Invoke(inventoryItem.GetType(), _inventoryItems.Count(x => x.GetType() == inventoryItem.GetType()));

            return inventoryItem;
        }

        public int GetCount<T>() where T : IInventoryItem
        {
            var result = _inventoryItems.Count(x => x.GetType() == typeof(T));

            return result;
        }

        public int GetCount(Type type)
        {
            var result = 0;

            if (type == typeof(Money))
            {
                result = GameManager.Instance.MoneyService.MoneyAmount;
            }
            else
            {
                result = _inventoryItems.Count(x => x.GetType() == type);
            }

            return result;
        }
    }
}
