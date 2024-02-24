namespace 自动提取翻译
{
    internal class SplitConsolidate
    {
        public static void SplitTextFile(string inputFilePath, string outputDirectory)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                int separatorIndex = line.IndexOf("-+-+-");
                if (separatorIndex != -1)
                {
                    line = line.Substring(0, separatorIndex).Trim();
                }
                else
                {
                    // 如果不存在分隔符，则使用原来的行进行处理
                    line = lines[i];
                }
                string fileName = $"{i + 1}.txt";
                string outputFilePath = Path.Combine(outputDirectory, fileName);
                File.WriteAllText(outputFilePath, line);
                Console.WriteLine(outputFilePath);
            }
            if (lines.Length > 0)
            {
                Console.WriteLine("分割成功");
            }
            else
            {
                Console.WriteLine("分割失败");
            }
        }

        public static void MergeTextFiles(string outputFilePath, string inputDirectory)
        {
            List<Tuple<int, string>> lines = new List<Tuple<int, string>>();
            foreach (string fileName in Directory.GetFiles(inputDirectory))
            {
                int lineNumber = int.Parse(Path.GetFileNameWithoutExtension(fileName));
                string inputFilePath = Path.Combine(inputDirectory, fileName);
                using (StreamReader file = new StreamReader(inputFilePath))
                {
                    string fileLine = file.ReadLine();
                    lines.Add(new Tuple<int, string>(lineNumber, fileLine));
                }
            }
            lines.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            using (StreamWriter file = new StreamWriter(outputFilePath))
            {
                foreach (Tuple<int, string> line in lines)
                {
                    file.WriteLine(line.Item2);
                }
            }
            if (File.Exists(outputFilePath))
            {
                Console.WriteLine("合并成功");
            }
            else
            {
                Console.WriteLine("合并失败");
            }
        }

    }

}
