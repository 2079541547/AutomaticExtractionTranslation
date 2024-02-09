using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自动提取翻译
{
    internal class Extract
    {
        public static void Extract_1(string jsonFilePath, string Keys, string outputFilePath)
        {
            string json = File.ReadAllText(jsonFilePath);
            JObject jsonObject = JObject.Parse(json);
            JObject npcNames = (JObject)jsonObject[Keys];
            using (StreamWriter file = new StreamWriter(outputFilePath))
            {
                foreach (var npcName in npcNames)
                {
                    file.WriteLine(npcName.Value);
                }
            }
        }

        public static void Extract_2(string filePath, string customKeyName, string outputFilePath)
        {
            string json = File.ReadAllText(filePath);
            dynamic data = JsonConvert.DeserializeObject(json);
            using (StreamWriter file = new StreamWriter(outputFilePath))
            {
                foreach (var item in data)
                {
                    string value = item[customKeyName];
                    file.WriteLine(value);
                }
            }
        }

        public static string[] Extract_3(string json, string keys, string keys2, string keys3, string filePath)
        {
            JObject jsonObject = JObject.Parse(json);
            JArray array = (JArray)jsonObject[keys][keys2];
            var values = array.Select(item => item[keys3].ToString()).ToArray();
            File.WriteAllLines(filePath, values);
            return values;
        }
        public static void Extract_4(string jsonFilePath, string keys, string keys2,string outputFilePath)
        {
            string jsonContent = File.ReadAllText(jsonFilePath);

            JObject jsonObject = JObject.Parse(jsonContent);
            List<string> textValues = new List<string>();

            foreach (JProperty property in jsonObject.Properties())
            {
                JArray textsArray = (JArray)property.Value[keys];
                if (textsArray != null)
                {
                    foreach (JToken textToken in textsArray)
                    {
                        string textValue = textToken[keys2].ToString();
                        textValues.Add(textValue);
                    }
                }
            }

            File.WriteAllLines(outputFilePath, textValues);
        }

        public static void ExtractMTextFromJsonFiles(string folderPath, string keys, string outputFolderPath)
        {
            string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

            foreach (string jsonFile in jsonFiles)
            {
                JObject json = JObject.Parse(File.ReadAllText(jsonFile));

                if (json[keys] == null)
                {
                    continue;
                }

                string mText = json[keys].ToString();

                string outputFileName = Path.GetFileNameWithoutExtension(jsonFile);
                string outputFilePath = Path.Combine(outputFolderPath, outputFileName + ".txt");

                File.WriteAllText(outputFilePath, mText);
            }
        }

    }
}
