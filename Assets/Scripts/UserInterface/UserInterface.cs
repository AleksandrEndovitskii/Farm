using System;
using System.Collections.Generic;
using GameObjects.Items;
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
        private CounterWithImage counterWithImagePrefab;

        private Counter _moneyCounterInstance;
        private CounterWithImage _wheatCounterInstance;
        private CounterWithImage _milkCounterInstance;
        private CounterWithImage _eggCounterInstance;

        private Dictionary<Type, Counter> _countersByTypes = new Dictionary<Type, Counter>();

        public void Initialize()
        {
            var countersTypes = new List<Type>();
            countersTypes.Add(typeof(Money));
            countersTypes.Add(typeof(Wheat));
            countersTypes.Add(typeof(Milk));
            countersTypes.Add(typeof(Egg));

            foreach (var countersType in countersTypes)
            {
                var instance = InstantiateCounter(counterWithImagePrefab, _countersContainer.gameObject.transform, countersType);
                _countersByTypes.Add(countersType, instance);
            }
        }

        private T InstantiateCounter<T>(T counterPrefab, Transform parent, int defaultValue = 0, string caption = "") where T : Counter
        {
            var instance = Instantiate(counterPrefab);
            instance.gameObject.transform.SetParent(parent);
            instance.SetCaption(caption);
            instance.SetValue(defaultValue.ToString());
            return instance;
        }

        private T InstantiateCounter<T>(T counterWithImagePrefab, Transform parent, Type type) where  T : CounterWithImage
        {
            var instance = InstantiateCounter(counterWithImagePrefab, parent, GameManager.Instance.InventoryService.GetCount(type));
            instance.SetImageByType(type);
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
