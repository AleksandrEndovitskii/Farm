using System;
using GameObjects.Utils;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace GameObjects.Cells
{
    /*
        • На клетке может располагаться одна из следующих сущностей:
          пшеница,
          курица,
          корова;
          либо клетка может быть пустой;
     */
    public class Cell : MonoBehaviour, IInitializable
    {
        public Action<Cell> Clicked = delegate { };

        [SerializeField]
        private Image contentImage;

        [SerializeField]
        private Scrollbar progressBar;

        public bool IsEmpty
        {
            get
            {
                return _content == null;
            }
        }

        private IPlaceable _content;

        public void Initialize()
        {
            SetContent<IPlaceable>(null);
            ProgressChanged(0);
        }

        public void SetContent<T>(T value) where T : IPlaceable
        {
            _content = value;

            if (_content == null)
            {
                contentImage.sprite = null;
            }
            else
            {
                contentImage.sprite = GameManager.Instance.ImageManager.GetImage(_content.GetType().Name);
            }

            progressBar.gameObject.SetActive(_content != null);
        }

        public void OnClick()
        {
            Clicked.Invoke(this);
        }

        public void TryToCollect()
        {
            var progressive = _content as IProgressive;
            if (progressive == null || // this item dont have any progress
                !progressive.IsReady) // this item progress do not completed
            {
                return;
            }

            var producer = _content as AProducer<Wheat>; // demo implementation
            if (producer == null || // this item is not a producer
                producer.Production == null) // this producer do not have any production
            {
                return;
            }

            var production = producer.CollectProduction();
            var inventoryItem = production as IInventoryItem;
            if (inventoryItem == null) // this production can not be putted to inventory
            {
                return;
            }

            GameManager.Instance.InventoryService.Put(inventoryItem);
        }

        public void BuyAndPlace<T1>() where T1 : IPlaceable, IBuyable, IProgressive, new()
        {
            var value = GameManager.Instance.TradeService.TryBuy<T1>();
            if (value == null)
            {
                return;
            }

            SetContent(value);

            value.ProgressChanged += ProgressChanged;
        }

        private void ProgressChanged(float value)
        {
            progressBar.size = value;
        }
    }
}
