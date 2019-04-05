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
        }
    }
}
