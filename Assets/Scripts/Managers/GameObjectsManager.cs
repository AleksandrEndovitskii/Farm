using System.Collections.Generic;
using GameObjects.Cells;
using GameObjects.Field;
using UnityEngine;
using Utils;

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
        private Field FieldPrefab;
        [SerializeField]
        private Cell CellPrefab;

        private Field _fieldInstance;
        private List<Cell> _cellInstances = new List<Cell>();

        /*
            • Поле фермы 8x8 клеток;
        */
        private const int FieldHeight = 8;
        private const int FieldWidth = 8;

        public void Initialize()
        {
            _fieldInstance = Instantiate(FieldPrefab, canvas.transform);

            for (var i = 0; i < FieldHeight; i++)
            {
                for (var j = 0; j < FieldWidth; j++)
                {
                    var cellInstance = Instantiate(CellPrefab, _fieldInstance.transform);
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
                cell.TryToCollect();
            }
            else // content is empty - try to place content
            {
                GameManager.Instance.UserInterfaceManager.ShowMenu(cell);
            }
        }
    }
}
