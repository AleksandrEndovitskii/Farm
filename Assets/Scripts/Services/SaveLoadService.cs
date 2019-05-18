using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Utils;

namespace Services
{
    public class SaveLoadService : IInitializable
    {
        private List<MoneyService> _services = new List<MoneyService>();

        private string _jsonName = "Save.json";

        public void Initialize()
        {
            //
        }

        public void Add(MoneyService moneyService)
        {
            _services.Add(moneyService);
        }

        private void Save<T>(T exemplar, string jsonName)
        {
            var json = JsonConvert.SerializeObject(exemplar, Formatting.Indented);

            var filePath = Application.dataPath + "/" + jsonName;

            File.WriteAllText(filePath, json);
        }

        private T LoadOrCreateNew<T>(string jsonName) where T : MoneyService, new()
        {
            var exemplar = new T();

            var filePath = Application.dataPath + "/" + jsonName;

            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                exemplar = JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                Save(exemplar, _jsonName);

                Debug.LogWarning(string.Format("No {0} file was provided - empty exemplar was created and loaded.", _jsonName));
            }

            return exemplar;
        }
    }
}
