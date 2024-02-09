using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

public class Translator
{
    public void Translate(string txt, Action<string> callback, string mod = "自动检测", bool skipTags = false)
    {
        var types = new Dictionary<string, string>
        {
            {"自动检测", "AUTO"},
            {"中译英", "ZH_CN2EN"},
            {"中译日", "ZH_CN2JA"},
            {"中译韩", "ZH_CN2KR"},
            {"中译法", "ZH_CN2FR"},
            {"中译俄", "ZH_CN2RU"},
            {"中译西", "ZH_CN2SP"},
            {"英译中", "EN2ZH_CN"},
            {"日译中", "JA2ZH_CN"},
            {"韩译中", "KR2ZH_CN"},
            {"法译中", "FR2ZH_CN"},
            {"俄译中", "RU2ZH_CN"},
            {"西译中", "SP2ZH_CN"}
        };

        if (!types.ContainsKey(mod))
        {
            mod = "自动检测";
        }

        var url = "https://m.youdao.com/translate";
        var data = $"inputtext={Uri.EscapeDataString(txt)}&type={types[mod]}";
        var bytes = Encoding.UTF8.GetBytes(data);

        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = bytes.Length;

        using (var stream = request.GetRequestStream())
        {
            stream.Write(bytes, 0, bytes.Length);
        }

        using (var response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    var result = content.Split("translateResult")[1].Split("</div>")[0].Split("<li>")[1].Split("</li>")[0];

                    if (skipTags)
                    {
                        result = result.Replace("&lt;", "<").Replace("&gt;", ">").Replace("& lt;", "<").Replace("& gt;", ">");
                    }

                    callback(result);
                }
            }
        }
    }

    public void TranslateFile(string filePath, string outputPath, string mod = "英译中", bool skipTags = false)
    {
        var lines = File.ReadAllLines(filePath, Encoding.UTF8);
        var totalLines = lines.Length;
        var count = 0;

        using (var outputFile = new StreamWriter(outputPath, false, Encoding.UTF8))
        {
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();

                if (!string.IsNullOrEmpty(trimmedLine))
                {
                    Translate(trimmedLine, result =>
                    {
                        outputFile.WriteLine(result);
                        outputFile.Flush();
                    }, mod, skipTags);

                    count++;

                    if (count % 10 == 0)
                    {
                        Console.WriteLine($"已翻译 {count}/{totalLines} 行");
                    }
                }
            }
        }
    }


    public void TranslateFolder(string folderPath, string outputFolder, string mod = "英译中", bool skipTags = false, int parallelism = 4)
    {
        var files = Directory.GetFiles(folderPath);

        Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = parallelism }, file =>
        {
            var fileName = Path.GetFileName(file);
            var outputPath = Path.Combine(outputFolder, fileName);

            TranslateFile(file, outputPath, mod, skipTags);
        });

        Console.WriteLine("翻译结束");
    }


}