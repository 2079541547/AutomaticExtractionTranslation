using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace 自动提取翻译
{
    internal class Replace
    {
        public static void Replace_1(string jsonFilePath, string Keys, string valuesFilePath, string outputFilePath)
        {
            string[] values = File.ReadAllLines(valuesFilePath);
            JObject jsonObject = JObject.Parse(File.ReadAllText(jsonFilePath));
            JObject npcName = (JObject)jsonObject[Keys];
            for (int i = 0; i < npcName.Count; i++)
            {
                string key = npcName.Properties().ElementAt(i).Name;
                int index = i;
                if (index >= 0 && index < values.Length)
                {
                    string newValue = values[index];
                    npcName[key] = newValue;
                }
            }
            File.WriteAllText(outputFilePath, jsonObject.ToString());
        }

        public static void Replace_2(string filePath, string keys, string namesFilePath, string outputFilePath)
        {
            string json = File.ReadAllText(filePath);
            string[] Keys = File.ReadAllLines(namesFilePath);
            JToken data = JToken.Parse(json);
            for (int i = 0; i < data.Count(); i++)
            {
                JObject item = (JObject)data[i];
                item[keys] = Keys[i];
            }
            File.WriteAllText(outputFilePath, data.ToString(Formatting.None));
        }

        public static void Replace_3(string jsonFilePath, string valuesFilePath, string outputFilePath, string stringsKey, string arrayKey, string valueKey)
        {
            string json = File.ReadAllText(jsonFilePath);

            
            JObject jsonObject = JObject.Parse(json);

            string[] lines = File.ReadAllLines(valuesFilePath);

            
            JArray valuesArray = (JArray)jsonObject[stringsKey][arrayKey];

            for (int i = 0; i < lines.Length; i++)
            {
                string value = lines[i];

                valuesArray[i][valueKey] = value;
            }

            File.WriteAllText(outputFilePath, jsonObject.ToString(Formatting.None));
        }

        public static void Replace_4(string jsonFilePath, string keys, string keys2,string inputFilePath, string outputFilePath)
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            string[] newValues = File.ReadAllLines(inputFilePath);

            JObject jsonObject = JObject.Parse(jsonContent);

            foreach (JProperty property in jsonObject.Properties())
            {
                JArray textsArray = (JArray)property.Value[keys];
                if (textsArray != null)
                {
                    for (int i = 0; i < textsArray.Count; i++)
                    {
                        textsArray[i][keys2] = newValues[i];
                    }
                }
            }

            string updatedJsonContent = JsonConvert.SerializeObject(jsonObject, Formatting.None);
            File.WriteAllText(outputFilePath, updatedJsonContent);
        }

        public static void ReplaceJsonText(string jsonFolderPath, string textFolderPath, string outputFolderPath, string textKey)
        {
            string[] jsonFiles = Directory.GetFiles(jsonFolderPath, "*.json");

            foreach (string jsonFile in jsonFiles)
            {

                string textFileName = Path.GetFileNameWithoutExtension(jsonFile) + ".txt";
                string textFilePath = Path.Combine(textFolderPath, textFileName);

                if (!File.Exists(textFilePath))
                {
                    Console.WriteLine($"找不到文本文件：{textFilePath}，跳过处理。");
                    continue;
                }

                string newText = File.ReadAllText(textFilePath);

                string json = File.ReadAllText(jsonFile);

                int startIndex = json.IndexOf($"\"{textKey}\": \"") + $"\"{textKey}\": \"".Length;
                int endIndex = json.IndexOf("\"", startIndex);
                string oldText = json.Substring(startIndex, endIndex - startIndex);

                json = json.Replace($"\"{textKey}\": \"{oldText}\"", $"\"{textKey}\": \"{newText}\"");

                string outputFilePath = Path.Combine(outputFolderPath, Path.GetFileName(jsonFile));

                File.WriteAllText(outputFilePath, json);
            }
        }
    }
}