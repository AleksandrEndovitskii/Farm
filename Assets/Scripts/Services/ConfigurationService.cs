using System;
using System.IO;
using UnityEngine;

namespace Services
{
    /*
        Свойства сущностей должны быть заданы в конфигурационных файлах (json / xml).
     */
    public class ConfigurationService
    {
        public Config Config
        {
            get
            {
                return _config;
            }
        }

        private Config _config;

        private string _jsonName = "Config.json";

        public void Initialize()
        {
            _config = LoadOrCreateNew(_jsonName);
        }

        private void Save(Config config, string jsonName)
        {
            var json = JsonUtility.ToJson(config);

            var filePath = Application.dataPath + "/" + jsonName;

            File.WriteAllText(filePath, json);
        }

        private Config LoadOrCreateNew(string jsonName)
        {
            var config = new Config();

            var filePath = Application.dataPath + "/" + jsonName;

            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                config = JsonUtility.FromJson<Config>(json);
            }

            return config;
        }
    }

    [Serializable]
    public class Config
    {
        public int EggSellPrice;
        public int MilkSellPrice;

        public int WheatBuyPrice;
        public int CowBuyPrice;
        public int ChickenBuyPrice;
    }
}
