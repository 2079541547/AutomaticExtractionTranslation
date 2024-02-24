using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class Translator
{
    public void Translate(string txt, Action<string> callback, string mod = "自动检测", bool skipTags = false)
    {
        var url = "http://api.fanyi.baidu.com/api/trans/vip/translate";
        var appid = "20231029001863039";
        var key = "KKZnIqv6MExqMKjNS1FR";
        var salt = DateTime.Now.Millisecond.ToString();
        var sign = MD5Encrypt(appid + txt + salt + key);

        var data = $"q={Uri.EscapeDataString(txt)}&from=auto&to=en&appid={appid}&salt={salt}&sign={sign}";
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
                    var translation = JsonDocument.Parse(content);
                    var translatedText = translation.RootElement.GetProperty("trans_result")[0].GetProperty("dst").GetString();

                    if (skipTags)
                    {
                        translatedText = translatedText.Replace("&lt;", "<").Replace("&gt;", ">").Replace("& lt;", "<").Replace("& gt;", ">");
                    }

                    callback(translatedText);
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

    private string MD5Encrypt(string input)
    {
        using (var md5 = MD5.Create())
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
