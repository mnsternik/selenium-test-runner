using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WinFormsTestRunner.Utilities
{
    internal class JSONFileHandler
    {
        public static T Deserialize<T>(string filePath)
        {
            string content = GetFileContent(filePath);
            if (string.IsNullOrEmpty(content))
            {
                throw new Exception($"Brak pliku lub zawartości w pliku: {filePath}");
            }
            T deserializedObject = JsonConvert.DeserializeObject<T>(content) ?? throw new Exception("Wystąpił błąd podczas deserializacji pliku JSON.");
            return deserializedObject;
        }
        
        public static void Serialize<T>(T obj, string filePath)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), $"Wystąpił błąd podczas zapisywania pliku JSON - serializowany obiekt jest pusty");
            }
            try
            {
                string jsonContent = JsonConvert.SerializeObject(obj, Formatting.Indented);
                File.WriteAllText(filePath, jsonContent);
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił błąd podczas zapisywania do pliku JSON", ex); 
            }
        }

        private static string GetFileContent(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Nie znaleziono pliku we wskazanej lokalizacji: {filePath}.");
            }
            return File.ReadAllText(filePath);
        }
    }
}
