using UnityEngine;

/*
Минимальная функциональность:
    • Возможность расставлять объекты (сущности) на поле и 
        покупать новые при помощи простого интерфейса;
    • Автоматическое сохранение прогресса и 
        загрузка игры с момента последнего сохранения.
Игра должна включать в себя простейшую графическую реализацию:
    отображение объектов,
    индикаторы прогресса и корма,
    возможность совершить описанные выше действия и понять состояние объектов.
 */

public class GameManager : MonoBehaviour
{
    // static instance of GameManager which allows it to be accessed by any other script 
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject); // sets this to not be destroyed when reloading scene 
        }
        else
        {
            if (Instance != this)
            {
                // this enforces our singleton pattern, meaning there can only ever be one instance of a GameManager 
                Destroy(gameObject);
            }
        }

        Initialize();
    }

    private void Initialize()
    {
        //
    }
}
