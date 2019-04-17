using System.Collections.Generic;
using GameObjects.Cells;
using GameObjects.Field;
using GameObjects.Items;
using GameObjects.Utils;
using UnityEngine;
using Utils;
using Debug = UnityEngine.Debug;

/*
Минимальная функциональность:
    • Возможность расставлять объекты (сущности) на поле и 
        покупать новые при помощи простого интерфейса;
 */

namespace Managers
{
    public class GameObjectsManager : MonoBehaviour, IInitializable
    {
        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private Field _fieldPrefab;
        [SerializeField]
        private Cell _cellPrefab;

        private Field _fieldInstance;
        private List<Cell> _cellInstances = new List<Cell>();

        /*
            • Поле фермы 8x8 клеток;
        */
        private const int FieldHeight = 8;
        private const int FieldWidth = 8;

        public void Initialize()
        {
            _fieldInstance = Instantiate(_fieldPrefab, canvas.transform);

            for (var i = 0; i < FieldHeight; i++)
            {
                for (var j = 0; j < FieldWidth; j++)
                {
                    var cellInstance = Instantiate(_cellPrefab, _fieldInstance.transform);
                    cellInstance.Initialize();
                    cellInstance.Clicked += Clicked;
                    _cellInstances.Add(cellInstance);
                } 
            }
        }

        private void Clicked(Cell cell)
        {
            if (!cell.IsEmpty) // content is not empty
            {
                var producer = cell.Content as IProducer;
                if (producer != null) // its a producer
                {
                    var production = producer.TryCollectProduction();
                    if (production != null) // production was collected from producer
                    {
                        var inventoryItem = production as IInventoryItem;
                        if (inventoryItem != null) // production its an inventory item
                        {
                            Debug.Log(string.Format("Putting in inventory production of type {0}.", production.GetType().Name));

                            GameManager.Instance.InventoryService.Put(inventoryItem);

                            return;
                        }
                        else
                        {
                            Debug.LogWarning(string.Format("Production of type {0} can not be putted to inventory.", production.GetType().Name));

                            return;
                        }
                    }
                }

                var feedable = cell.Content as IFeedable;
                var food = GameManager.Instance.InventoryService.TryPop<Wheat>() as IFood;
                if (feedable != null &&
                    food != null)
                {
                    feedable.Feed(food);
                }
            }
            else // content is empty - try to place content
            {
                Debug.Log("Clicked on Cell with empty content");

                GameManager.Instance.UserInterfaceManager.ShowMenu(cell);
            }
        }
    }
}
