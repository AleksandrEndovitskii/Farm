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
        
        public Type TypeOfContent
        {
            get
            {
                return _typeOfContent;
            }
        }

        private IPlaceable _content;

        private Type _typeOfContent;

        public void Initialize()
        {
            SetContent<IPlaceable>(null);
            SetProgressBarValue(0);
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
                SetTypeOfContent(_content.GetType());
            }

            progressBar.gameObject.SetActive(_content != null);
        }

        public void OnClick()
        {
            Clicked.Invoke(this);
        }

        public void SetProgressBarValue(float value)
        {
            progressBar.size = value;
        }

        public void SetTypeOfContent(Type type)
        {
            _typeOfContent = type;

            contentImage.sprite = GameManager.Instance.ImageManager.GetImage(TypeOfContent.Name);
        }

        public void ShowProgressBarVisibility(bool visible)
        {
            progressBar.gameObject.SetActive(visible);
        }
    }
}
