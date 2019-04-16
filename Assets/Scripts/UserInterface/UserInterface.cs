using System;
using GameObjects;
using GameObjects.Production;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UserInterface
{
    public class UserInterface : MonoBehaviour, IInitializable
    {
        [SerializeField]
        private VerticalLayoutGroup _countersContainer;

        [SerializeField]
        private Counter counterPrefab;

        private Counter _moneyCounterInstance;
        private Counter _wheatCounterInstance;
        private Counter _milkCounterInstance;
        private Counter _eggCounterInstance;

        public void Initialize()
        {
            _moneyCounterInstance = InstantiateCounter(counterPrefab, _countersContainer.gameObject.transform,
                "MoneyAmount: ", GameManager.Instance.MoneyService.MoneyAmount);
            GameManager.Instance.MoneyService.MoneyAmountChanged += (i) =>
            {
                _moneyCounterInstance.SetValue(i.ToString());
            };

            _wheatCounterInstance = InstantiateCounter(counterPrefab, _countersContainer.gameObject.transform,
                "WheatAmount: ", GameManager.Instance.InventoryService.GetCount<Wheat>());
            GameManager.Instance.InventoryService.InventoryItemAmountChanged += (type, i) =>
            {
                if (type == typeof(Wheat))
                {
                    _wheatCounterInstance.SetValue(i.ToString());
                }
            };
            _milkCounterInstance = InstantiateCounter(counterPrefab, _countersContainer.gameObject.transform,
                "MilkAmount: ", GameManager.Instance.InventoryService.GetCount<Milk>());
            GameManager.Instance.InventoryService.InventoryItemAmountChanged += (type, i) =>
            {
                if (type == typeof(Milk))
                {
                    _milkCounterInstance.SetValue(i.ToString());
                }
            };
            _eggCounterInstance = InstantiateCounter(counterPrefab, _countersContainer.gameObject.transform,
                "EggAmount: ", GameManager.Instance.InventoryService.GetCount<Egg>());
            GameManager.Instance.InventoryService.InventoryItemAmountChanged += (type, i) =>
            {
                if (type == typeof(Egg))
                {
                    _eggCounterInstance.SetValue(i.ToString());
                }
            };
        }

        private Counter InstantiateCounter(Counter counterPrefab, Transform parent, string caption, int defaultValue)
        {
            var instance = Instantiate(counterPrefab);
            instance.gameObject.transform.SetParent(parent);
            instance.SetCaption(caption);
            instance.SetValue(defaultValue.ToString());
            return instance;
        }

        private Counter InstantiateCounter(Counter counterPrefab, Transform parent, string caption, int defaultValue, Action<int> action)
        {
            var instance = InstantiateCounter(counterPrefab, parent, caption, defaultValue);
            action += (i) =>
            {
                instance.SetValue(i.ToString());
            };
            return instance;
        }

        private Counter InstantiateCounter(Counter counterPrefab, Transform parent, string caption, int defaultValue, Type type, Action<Type,int> action)
        {
            var instance = InstantiateCounter(counterPrefab, parent, caption, defaultValue);
            action += (t,i) =>
            {
                if (t == type)
                {
                    instance.SetValue(i.ToString()); 
                }
            };

            return instance;
        }
    }
}
