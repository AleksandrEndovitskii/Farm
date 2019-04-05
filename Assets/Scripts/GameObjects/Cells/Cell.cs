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
        [SerializeField]
        private Image contentImage;

        [SerializeField]
        private Scrollbar progressBar;

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
                    contentImage.sprite = null;
                }
                else
                {
                    contentImage.sprite = GameManager.Instance.ImageManager.GetImage(_content.GetType().Name);

                    var producer = _content as AProducer;
                    if (producer != null)
                    {
                        producer.ProgressChanged += ProgressChanged;
                    }
                }

                progressBar.gameObject.SetActive(_content != null);
            }
        }

        private static System.Random _random = new System.Random();

        public void Initialize()
        {
            Content = null;
            ProgressChanged(0);
        }

        public void Place(IPlaceable placeable)
        {
            Content = placeable;
        }

        public void OnClick()
        {
            var randomValue = _random.Next(0, 1);

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

        private void ProgressChanged(float value)
        {
            progressBar.size = value;
        }
    }
}
