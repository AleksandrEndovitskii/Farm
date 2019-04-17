using System;
using GameObjects.Cells;
using UnityEngine;

namespace UserInterface
{
    public class CounterWithImage : Counter
    {
        public Action<Cell> Clicked = delegate { };

        [SerializeField]
        private Cell _cell;

        public override void Initialize()
        {
            // by default this items must be invisible - they can be setted or they can not
            _cell.gameObject.SetActive(false);
            // we don't need to see progress bar on counters
            // TODO: add visualization of inventory capacity for items
            _cell.ShowProgressBarVisibility(false);

            _cell.Clicked += cell =>
            {
                Debug.Log(string.Format("Clicked on CounterWithImage in Cell with TypeOfContent of {0}.", _cell.TypeOfContent.Name));

                Clicked.Invoke(cell);
            };

            base.Initialize();
        }

        public void SetImageByType(Type type)
        {
            _cell.SetTypeOfContent(type);

            _cell.gameObject.SetActive(true); // item was setted - make it visible
        }
    }
}
