using System;
using GameObjects.Utils;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GameObjects.Cells
{
    /*
        • На клетке может располагаться одна из следующих сущностей:
          пшеница,
          курица,
          корова;
          либо клетка может быть пустой;
     */
    public class Cell : MonoBehaviour
    {
        [SerializeField]
        private Image ContentImage;

        private IPlaceable _content;
        private IPlaceable Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;

                if (_content == null)
                {
                    ContentImage.sprite = null;
                }
                else
                {
                    ContentImage.sprite = GameManager.Instance.ImageManager.GetImage(_content.GetType().Name);
                }
            }
        }

        private static System.Random _random = new System.Random();

        public void Place(IPlaceable placeable)
        {
            Content = placeable;
        }

        public void OnClick()
        {
            var randomValue = _random.Next(0, 3);

            IPlaceable placeable = null;

            switch (randomValue)
            {
                case 0:
                    placeable = GameManager.Instance.TradeService.TryBuy<Wheat>();
                    break;
                case 1:
                    placeable = GameManager.Instance.TradeService.TryBuy<Chicken>();
                    break;
                case 2:
                    placeable = GameManager.Instance.TradeService.TryBuy<Cow>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            if (placeable != null)
            {
                Place(placeable);
            }
        }
    }
}
