using Services;
using UnityEngine;
using Utils;

/*
Минимальная функциональность:
    • Возможность расставлять объекты (сущности) на поле и 
        покупать новые при помощи простого интерфейса;
 */

namespace Managers
{
    public class GameManager : MonoBehaviour, IInitializable
    {
        // static instance of GameManager which allows it to be accessed by any other script 
        public static GameManager Instance;

        public UserInterfaceManager UserInterfaceManager
        {
            get { return this.gameObject.GetComponent<UserInterfaceManager>(); }
        }

        public ConfigurationService ConfigurationService;

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

        public void Initialize()
        {
            UserInterfaceManager.Initialize();

            ConfigurationService = new ConfigurationService();
            ConfigurationService.Initialize();
        }
    }
}
