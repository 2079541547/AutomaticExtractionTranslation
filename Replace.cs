using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace 自动提取翻译
{
    internal class Replace
    {
        public static void ReplaceStringValues(string jsonFilePath, string valuesFilePath, string outputFilePath, bool format)
        {

            string json = File.ReadAllText(jsonFilePath);
            JObject jObject = JObject.Parse(json);

            string valuesFile = File.ReadAllText(valuesFilePath);
            string[] values = valuesFile.Split('\n');

            foreach (JProperty property in jObject.Descendants().OfType<JProperty>())
            {
                if (property.Value.Type == JTokenType.String)
                {
                    property.Value = values[0].Trim();
                    values = values[1..];
                }
            }

            string modifiedJson = jObject.ToString(format ? Formatting.Indented : Formatting.None);

            File.WriteAllText(outputFilePath, modifiedJson);

            Console.WriteLine(modifiedJson);
        }



        public static void ReplaceStringValues_1(string jsonFilePath, string valuesFilePath, string outputFilePath, string keyName, bool format)
        {
            string json = File.ReadAllText(jsonFilePath);
            JObject jObject = JObject.Parse(json);

            string valuesFile = File.ReadAllText(valuesFilePath);
            string[] values = valuesFile.Split('\n');

            foreach (JProperty property in jObject.Descendants().OfType<JProperty>())
            {
                if (property.Name == keyName && property.Value.Type == JTokenType.String)
                {
                    property.Value = values[0].Trim();
                    values = values[1..];
                }
            }

            Formatting formatting = format ? Formatting.Indented : Formatting.None;
            string modifiedJson = jObject.ToString(formatting);

            File.WriteAllText(outputFilePath, modifiedJson);

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
