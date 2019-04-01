using GameObjects.Field;
using UnityEngine;
using Utils;

/*
Минимальная функциональность:
    • Возможность расставлять объекты (сущности) на поле и 
        покупать новые при помощи простого интерфейса;
 */

namespace Managers
{
    public class GameObjectsManager : MonoBehaviour, IInitializable
    {
        [SerializeField]
        private Canvas Canvas;

        [SerializeField]
        private Field FieldPrefab;

        private Field _fieldInstance;

        public void Initialize()
        {
            _fieldInstance = Instantiate(FieldPrefab, Canvas.transform);

        }
    }
}
