using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EcommerceCore.Interfaces;
using Newtonsoft.Json;

namespace EcommerceCore.Helpers
{
    public class ReadWriteToJson : IReadWriteToJson
    {
        private readonly string baseDir = Directory.GetCurrentDirectory();

        public async Task<bool> WriteJson<T>(T model, string jsonFile)
        {

            try
            {
                string json = JsonConvert.SerializeObject(model) + Environment.NewLine;
                await File.AppendAllTextAsync(FilePath(baseDir, jsonFile), json);
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<T>> ReadJson<T>(string jsonFile)
        {
            var readText = await File.ReadAllTextAsync(FilePath(baseDir, jsonFile));

            var objects = new List<T>();

            var serializer = new JsonSerializer();

            using (var stringReader = new StringReader(readText))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                jsonReader.SupportMultipleContent = true;

                while (jsonReader.Read())
                {
                    T json = serializer.Deserialize<T>(jsonReader);

                    objects.Add(json);
                }
            }

            return objects;
        }


        public async Task<bool> UpdateJson<T>(List<T> model, string jsonFile)
        {
            string json = string.Empty;

            foreach (var item in model)
            {
                json += JsonConvert.SerializeObject(item) + Environment.NewLine;
            }


            try
            {
                await File.WriteAllTextAsync(FilePath(baseDir, jsonFile), json);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string FilePath(string folderName, string fileName)
        {
            folderName += @"/db/";
            if (Directory.Exists(folderName))
            {
                return Path.Combine(folderName, fileName);
            }
            return "";
        }

    }
}
