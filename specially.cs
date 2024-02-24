using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自动提取翻译
{
    internal class specially
    {
        public static void ReplaceAndSaveAsJson(string filePath, string replacement, string outputFolder)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    int index = lines[i].IndexOf("-+-+-");
                    if (index >= 0)
                    {
                        string fileName = lines[i].Substring(index + 5) + ".txt";
                        string content = lines[i].Substring(0, index);

                        string outputPath = Path.Combine(outputFolder, fileName);
                        File.WriteAllText(outputPath, content);

                        lines[i] = replacement + lines[i].Substring(index + 6);
                    }
                }

                File.WriteAllLines(filePath, lines);
                Console.WriteLine("替换并保存为JSON文件完成！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("替换并保存为JSON文件过程中发生错误：" + ex.Message);
            }
        }

    }
}
