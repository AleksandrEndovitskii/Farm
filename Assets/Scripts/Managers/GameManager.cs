using Services;
using UnityEngine;
using Utils;

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

        public GameObjectsManager GameObjectsManager
        {
            get { return this.gameObject.GetComponent<GameObjectsManager>(); }
        }

        public ImageManager ImageManager
        {
            get { return this.gameObject.GetComponent<ImageManager>(); }
        }

        public TimeManager TimeManager
        {
            get { return this.gameObject.GetComponent<TimeManager>(); }
        }

        public ConfigurationService ConfigurationService;

        public BuyPriceDictionaryService BuyPriceDictionaryService;

        public SellPriceDictionaryService SellPriceDictionaryService;

        public TradeService TradeService;

        public MoneyService MoneyService;

        public ProductionDurationDictionaryService ProductionDurationDictionaryService;

        public SatietyDurationDictionaryService SatietyDurationDictionaryService;

        public InventoryService InventoryService;

        public ProducerProductionDictionaryService ProducerProductionDictionaryService;

        public SaveLoadService SaveLoadService;

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
            GameObjectsManager.Initialize();
            ImageManager.Initialize();
            TimeManager.Initialize();

            SaveLoadService = new SaveLoadService();
            SaveLoadService.Initialize();

            ConfigurationService = new ConfigurationService();
            ConfigurationService.Initialize();
            BuyPriceDictionaryService = new BuyPriceDictionaryService();
            BuyPriceDictionaryService.Initialize();
            SellPriceDictionaryService = new SellPriceDictionaryService();
            SellPriceDictionaryService.Initialize();
            // before trade need to know a price
            TradeService = new TradeService();
            TradeService.Initialize();
            MoneyService = new MoneyService();
            MoneyService.Initialize();
            ProducerProductionDictionaryService = new ProducerProductionDictionaryService();
            ProducerProductionDictionaryService.Initialize();
            //
            ProductionDurationDictionaryService = new ProductionDurationDictionaryService();
            ProductionDurationDictionaryService.Initialize();
            SatietyDurationDictionaryService = new SatietyDurationDictionaryService();
            SatietyDurationDictionaryService.Initialize();
            // before visualize money amount need to know a money amount
            InventoryService = new InventoryService();
            InventoryService.Initialize();
            // before visualize inventory items amount need to know a inventory items amount
            UserInterfaceManager.Initialize();
        }
    }
}
