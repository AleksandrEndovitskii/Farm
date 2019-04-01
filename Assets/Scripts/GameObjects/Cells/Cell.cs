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

        public void Place(IPlaceable placeable)
        {
            Content = placeable;
        }

        public void OnClick()
        {

        }
    }
}
