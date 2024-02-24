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
        public static void Extract_1(string inputFilePath, string outputFilePath, string key)
        {
            string json = File.ReadAllText(inputFilePath);
            JObject obj = JObject.Parse(json);
            JObject valuesObj = (JObject)obj[key];
            var values = valuesObj.Properties().Select(p => p.Value.ToString()).ToArray();
            File.WriteAllLines(outputFilePath, values);
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

        public static void Extract_3(string filePath, string outputFilePath, string stringsKey, string arrayKey, string valueKey)
        {
            string json = File.ReadAllText(filePath);
            dynamic data = JsonConvert.DeserializeObject(json);
            var values = data[stringsKey][arrayKey];
            string output = "";

            foreach (var item in values)
            {
                string value = item[valueKey];
                output += value + "\n";
            }
            File.WriteAllText(outputFilePath, output);
        }

        public static void Extract_4(string jsonFilePath, string keys, string keys2, string outputFilePath)
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

            string outputFileName = outputFolderPath;
            string outputFilePath = Path.Combine(outputFolderPath, outputFileName);

            if (!File.Exists(outputFilePath))
            {
                File.WriteAllText(outputFilePath, "");
            }

            foreach (string jsonFile in jsonFiles)
            {
                JObject json = JObject.Parse(File.ReadAllText(jsonFile));

                if (json[keys] == null)
                {
                    continue;
                }

                string mText = json[keys].ToString();
                mText = mText.Replace("\n", @"\n");
                File.AppendAllText(outputFilePath, mText + " -+-+- " + Path.GetFileNameWithoutExtension(jsonFile) + "\n");
            }
        }
    }
}