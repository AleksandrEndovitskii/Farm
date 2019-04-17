using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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
            var json = JsonConvert.SerializeObject(config, Formatting.Indented);

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
                config = JsonConvert.DeserializeObject<Config>(json);
            }
            else
            {
                Save(config, _jsonName);

                Debug.LogWarning(string.Format("No {0} file was provided - empty config was created and loaded.", _jsonName));
            }

            return config;
        }
    }

    [Serializable]
    public class Config
    {
        public Dictionary<Type, int> SellTypeValues;

        public Dictionary<Type, int> BuyTypeValues;
    }
}
