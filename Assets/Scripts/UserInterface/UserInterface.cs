using Managers;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UserInterface
{
    public class UserInterface : MonoBehaviour, IInitializable
    {
        [SerializeField]
        private VerticalLayoutGroup countersContainer;

        [SerializeField]
        private Counter counterPrefab;

        private Counter _moneyCounterInstance;

        public void Initialize()
        {
            _moneyCounterInstance = Instantiate(counterPrefab);
            _moneyCounterInstance.gameObject.transform.SetParent(countersContainer.gameObject.transform);
            _moneyCounterInstance.captionTextMeshProText.text = "MoneyAmount: ";
            GameManager.Instance.MoneyService.MoneyAmountChanged += MoneyAmountChanged;
            MoneyAmountChanged(GameManager.Instance.MoneyService.MoneyAmount);
        }

        private void MoneyAmountChanged(int value)
        {
            _moneyCounterInstance.valueTextMeshProText.text = value.ToString();
        }
    }
}
