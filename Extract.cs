using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace 自动提取翻译
{
    internal class Extract
    {
        public static void ExtractStringValues(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string json = File.ReadAllText(inputFilePath);
                JObject obj = JObject.Parse(json);
                ExtractStringValues(obj, writer);
            }
        }

        static void ExtractStringValues(JToken token, StreamWriter writer)
        {
            if (token.Type == JTokenType.Object)
            {
                foreach (JProperty property in token.Children<JProperty>())
                {
                    ExtractStringValues(property.Value, writer);
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (JToken value in token.Children())
                {
                    ExtractStringValues(value, writer);
                }
            }
            else if (token.Type == JTokenType.String)
            {
                writer.WriteLine(token.Value<string>());
            }
        }








        public static void ExtractStringValues_1(string inputFilePath, string outputFilePath, string keyName)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string json = File.ReadAllText(inputFilePath);
                JObject obj = JObject.Parse(json);
                ExtractStringValues_1(obj, writer, keyName);
            }
        }

        static void ExtractStringValues_1(JToken token, StreamWriter writer, string keyName)
        {
            if (token.Type == JTokenType.Object)
            {
                foreach (JProperty property in token.Children<JProperty>())
                {
                    if (property.Name == keyName)
                    {
                        writer.WriteLine(property.Value.Value<string>());
                    }
                    else
                    {
                        ExtractStringValues_1(property.Value, writer, keyName);
                    }
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (JToken value in token.Children())
                {
                    ExtractStringValues_1(value, writer, keyName);
                }
            }
        }


    }






}
