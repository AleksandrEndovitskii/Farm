using UnityEngine;
using Utils;

/*
Игра должна включать в себя простейшую графическую реализацию:
    отображение объектов,
    индикаторы прогресса и корма,
    возможность совершить описанные выше действия и понять состояние объектов.
 */

namespace Managers
{
    public class UserInterfaceManager : MonoBehaviour, IInitializable
    {
        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private UserInterface.UserInterface userInterfacePrefab;

        private UserInterface.UserInterface _userInterfaceInstance;

        public void Initialize()
        {
            _userInterfaceInstance = Instantiate(userInterfacePrefab);
            _userInterfaceInstance.gameObject.transform.SetParent(canvas.gameObject.transform);
            _userInterfaceInstance.gameObject.transform.SetAsFirstSibling();
            _userInterfaceInstance.gameObject.GetComponent<RectTransform>().SetHeight(canvas.gameObject.GetComponent<RectTransform>().GetHeight());
            _userInterfaceInstance.gameObject.GetComponent<RectTransform>().SetWidth(canvas.gameObject.GetComponent<RectTransform>().GetWidth());
            _userInterfaceInstance.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

            _userInterfaceInstance.Initialize();
        }
    }
}
