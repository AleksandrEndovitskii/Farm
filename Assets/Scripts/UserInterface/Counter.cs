using TMPro;
using UnityEngine;
using Utils;

namespace UserInterface
{
    public class Counter : MonoBehaviour, IInitializable
    {
        [SerializeField]
        public TextMeshProUGUI captionTextMeshProText;
        [SerializeField]
        public TextMeshProUGUI valueTextMeshProText;

        public void Initialize()
        {

        }
    }
}
