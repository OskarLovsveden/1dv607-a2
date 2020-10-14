using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Model.DAL
{
    class Registry
    {
        private readonly byte FILE_MIN_LENGTH = 2;

        public List<T> ReadListFromRegistry<T>(string filePath)
        {
            CreateRegistryIfEmptyOrNotExist(filePath);
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }

        public void WriteListToRegistry<T>(List<T> list, string filePath)
        {
            CreateRegistryIfEmptyOrNotExist(filePath);

            var j = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filePath, j);
        }

        private void CreateRegistryIfEmptyOrNotExist(string filePath)
        {
            if (!File.Exists(filePath) || IsRegistryEmpty(filePath))
            {
                CreateEmptyList(filePath);
            }
        }

        private bool IsRegistryEmpty(string filePath)
        {
            return new FileInfo(filePath).Length < FILE_MIN_LENGTH;
        }

        private void CreateEmptyList(string filePath)
        {
            File.WriteAllText(filePath, "[]");
        }

    }
}