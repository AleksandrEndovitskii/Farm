using System;
using System.Collections.Generic;
using GameObjects.Items;
using GameObjects.Utils;
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

        private Dictionary<Type, Counter> _countersByTypesInstances = new Dictionary<Type, Counter>();

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
                _countersByTypesInstances.Add(countersType, instance);
            }
        }

        private T InstantiateCounter<T>(T counterPrefab, Transform parent, int defaultValue = 0, string caption = "") where T : CounterWithImage
        {
            var instance = Instantiate(counterPrefab);
            instance.Initialize();
            instance.Clicked += cell =>
            {
                // try to sell inventory items of type of counters on which one click was performed
                if (typeof(ISellable).IsAssignableFrom(cell.TypeOfContent))
                {
                    GameManager.Instance.TradeService.SellAllItemsByType(cell.TypeOfContent);
                }
                else
                {
                    Debug.Log(string.Format(
                        "Clicked on CounterWithImage in Cell with TypeOfContent of {0} which one is not ISellable.",
                        cell.TypeOfContent.Name));
                }
            };
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
