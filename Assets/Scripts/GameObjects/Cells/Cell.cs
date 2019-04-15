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

        public IPlaceable Content
        {
            get
            {
                return _content;
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
