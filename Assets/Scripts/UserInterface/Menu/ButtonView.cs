using System;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Menu
{
    [RequireComponent(typeof(Button))]
    public class ButtonView : MonoBehaviour
    {
        public Action<ButtonView> Clicked = delegate { };

        [SerializeField]
        private Image _contentImage;

        public void SetContentImage(Sprite sprite)
        {
            _contentImage.sprite = sprite;
        }

        public void OnClick()
        {
            Clicked.Invoke(this);
        }
    }
}
