using System;
using GameObjects.Production;
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
        [SerializeField]
        private Image contentImage;

        [SerializeField]
        private Scrollbar progressBar;

        private IPlaceable _content;

        private static System.Random _random = new System.Random();

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
            var randomValue = _random.Next(0, 1);

            switch (randomValue)
            {
                case 0:
                    BuyAndPlace<Wheat, Wheat>();
                    break;
                case 1:
                    BuyAndPlace<Chicken, Egg>();
                    break;
                case 2:
                    BuyAndPlace<Cow, Milk>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void BuyAndPlace<T1, T2>() where T1 : AProducer<T2>, IBuyable, IPlaceable, new() where T2 : IProduction, new()
        {
            var placeable = GameManager.Instance.TradeService.TryBuy<T1>();
            if (placeable != null)
            {
                SetContent<T1>(placeable);

                var producer = placeable as T1;
                if (producer != null)
                {
                    producer.ProgressChanged += ProgressChanged;
                    producer.ProductionIsReady += ProductionIsReady;
                }
            }
        }

        private void ProductionIsReady<T>(T production) where T : IProduction
        {
            var inventoryItem = production as IInventoryItem;
            if (inventoryItem != null)
            {
                GameManager.Instance.InventoryService.Put(inventoryItem);
            }
        }

        private void ProgressChanged(float value)
        {
            progressBar.size = value;
        }
    }
}
