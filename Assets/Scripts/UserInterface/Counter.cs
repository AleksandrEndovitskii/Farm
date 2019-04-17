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

        public virtual void Initialize()
        {
            // by default this items must be invisible - they can be setted or they can not
            _captionTextMeshProText.gameObject.SetActive(false);
            _valueTextMeshProText.gameObject.SetActive(false);
        }

        public void SetCaption(string caption)
        {
            _captionTextMeshProText.text = caption;

            _captionTextMeshProText.gameObject.SetActive(true); // item was setted - make it visible
        }

        public void SetValue(string value)
        {
            _valueTextMeshProText.text = value;

            _valueTextMeshProText.gameObject.SetActive(true); // item was setted - make it visible
        }
    }
}
