using System;
using GameObjects;
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
        private Counter _wheatCounterInstance;

        public void Initialize()
        {
            _moneyCounterInstance = Instantiate(counterPrefab);
            _moneyCounterInstance.gameObject.transform.SetParent(countersContainer.gameObject.transform);
            _moneyCounterInstance.captionTextMeshProText.text = "MoneyAmount: ";
            GameManager.Instance.MoneyService.MoneyAmountChanged += MoneyAmountChanged;
            MoneyAmountChanged(GameManager.Instance.MoneyService.MoneyAmount);

            _wheatCounterInstance = Instantiate(counterPrefab);
            _wheatCounterInstance.gameObject.transform.SetParent(countersContainer.gameObject.transform);
            _wheatCounterInstance.captionTextMeshProText.text = "WheatAmount: ";
            GameManager.Instance.InventoryService.InventoryItemAmountChanged += InventoryItemAmountChanged;
            InventoryItemAmountChanged(typeof(Wheat), GameManager.Instance.InventoryService.GetCount<Wheat>());
        }

        private void MoneyAmountChanged(int value)
        {
            _moneyCounterInstance.valueTextMeshProText.text = value.ToString();
        }

        private void InventoryItemAmountChanged(Type type, int amount)
        {
            _wheatCounterInstance.valueTextMeshProText.text = amount.ToString();
        }
    }
}
