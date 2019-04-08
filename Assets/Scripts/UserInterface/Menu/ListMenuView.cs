using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UserInterface.Menu
{
    public class ListMenuView : MonoBehaviour, IInitializable
    {
        public Action<ListMenuView> BackgroundImageClicked = delegate { };
        public Action<Button> ButtonClicked = delegate { };
        
        [SerializeField]
        private VerticalLayoutGroup _buttonsContainer;

        [SerializeField]
        private RectTransform _content;

        private List<Button> _buttonsInstances;

        private RectTransform _targetObject;

        public void OnBackgroundImageClick()
        {
            BackgroundImageClicked.Invoke(this);
        }

        public void Initialize()
        {
            _buttonsInstances = new List<Button>();
        }

        public void Initialize(RectTransform targetObject)
        {
            _targetObject = targetObject;

            Initialize();
        }

        public T AddButton<T>(T buttonPrefab, Action click) where  T: Button
        {
            var instance = InstantiateButton(buttonPrefab, this._buttonsContainer.gameObject.transform);
            instance.onClick.AddListener(() => { click.Invoke();});
            _buttonsInstances.Add(instance);
            return instance;
        }

        private void Awake()
        {
            StartCoroutine(PositionCorrection());
        }

        private T InstantiateButton<T>(T buttonPrefab, Transform parent) where T : Button
        {
            var instance = Instantiate(buttonPrefab);
            instance.onClick.AddListener(() => { ButtonClicked.Invoke(instance); });
            instance.gameObject.transform.SetParent(parent);
            return instance;
        }

        private IEnumerator PositionCorrection()
        {
            yield return new WaitForEndOfFrame();

            _content.position =
                _targetObject.position;

            _content.position = new Vector3(
                _content.position.x + (_targetObject.GetWidth() / 2),
                _content.position.y - (_content.GetHeight() / 2),
                0);
        }
    }
}
