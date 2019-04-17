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

            _wheatCounterInstance = InstantiateCounter(counterPrefab, _countersContainer.gameObject.transform, "WheatAmount: ",
                typeof(Wheat));
            _milkCounterInstance = InstantiateCounter(counterPrefab, _countersContainer.gameObject.transform, "MilkAmount: ",
                typeof(Milk));
            _eggCounterInstance = InstantiateCounter(counterPrefab, _countersContainer.gameObject.transform, "EggAmount: ",
                typeof(Egg));
        }

        private Counter InstantiateCounter(Counter counterPrefab, Transform parent, string caption, int defaultValue)
        {
            var instance = Instantiate(counterPrefab);
            instance.gameObject.transform.SetParent(parent);
            instance.SetCaption(caption);
            instance.SetValue(defaultValue.ToString());
            return instance;
        }

        private Counter InstantiateCounter(Counter counterPrefab, Transform parent, string caption, Type type)
        {
            var instance = InstantiateCounter(counterPrefab, parent, caption, GameManager.Instance.InventoryService.GetCount(type));
            GameManager.Instance.InventoryService.InventoryItemAmountChanged += (t, i) =>
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
