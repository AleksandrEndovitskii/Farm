using TMPro;
using UnityEngine;
using Utils;

namespace UserInterface
{
    public class Counter : MonoBehaviour, IInitializable
    {
        [SerializeField]
        private TextMeshProUGUI _captionTextMeshProText;
        [SerializeField]
        private TextMeshProUGUI _valueTextMeshProText;

        public void Initialize()
        {

        }

        public void SetCaption(string caption)
        {
            _captionTextMeshProText.text = caption;
        }

        public void SetValue(string value)
        {
            _valueTextMeshProText.text = value;
        }
    }
}
