using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using 自动提取翻译;

class Program
{
    static String Logs = """
                ..............                                     
            											   by@System.out.println("⁧;("
                    ..,;:ccc,.                             -----------
                  ......''';lxO.                           date: 2024.01.28.22:51:30
        .....''''..........,:ld;                           Programming language: Python 3.1.1.7
                   .';;;:::;,,.x,                          Runtime environment: Python
              ..'''.            0Xxoc:,.  ...              Elapsed time: 0 days, 3 hours, 54 mins      
          ....                ,ONkc;,;cokOdc',.            Type: Auxiliary tools
         .                   OMo           ':ddo.          Compiler: All support for original Python 3.1.1
                            dMc               :OO;         Email: 2079541547@qq.com
                            0M.                 .:o.       
                            ;Wd                            
                             ;XO,
                               ,d0Odlc;,..
                                   ..',;:cdOOd::,.
                                            .:d;.':;.
                                               'd,  .'
                                                 ;l   ..
                                                  .o
                                                    c
                                                    .'
                                                     .



                         ___          ______           Frobtech, Inc.
                        /__/\     ___/_____/\
                        \  \ \   /         /\\
                         \  \ \_/__       /  \         "If you've got the job,
                         _\  \ \  /\_____/___ \         we've got the frob."
                        // \__\/ /  \       /\ \
                _______//_______/    \     / _\/______
               /      / \       \    /    / /        /\
            __/      /   \       \  /    / /        / _\__
           / /      /     \_______\/    / /        / /   /\
          /_/______/___________________/ /________/ /___/  \
          \ \      \    ___________    \ \        \ \   \  /
           \_\      \  /          /\    \ \        \ \___\/
              \      \/          /  \    \ \        \  /
               \_____/          /    \    \ \________\/
                    /__________/      \    \  /
                    \   _____  \      /_____\/
                     \ /    /\  \    / \  \ \
                      /____/  \  \  /   \  \ \
                      \    \  /___\/     \  \ \
                       \____\/            \__\/





                         .::::..
              ::::rrr7QQJi::i:iirijQBBBQB.
              BBQBBBQBP. ......:::..1BBBB
              .BuPBBBX  .........r.  vBQL  :Y.
               rd:iQQ  ..........7L   MB    rr
                7biLX .::.:....:.:q.  ri    .
                 JX1: .r:.r....i.r::...:.  gi5
                 ..vr .7: 7:. :ii:  v.:iv :BQg
                 : r:  7r:i7i::ri:DBr..2S
              i.:r:. .i:XBBK...  :BP ::jr   .7.
              r  i....ir r7.         r.J:   u.
             :..X: .. .v:           .:.Ji
            i. ..i .. .u:.     .   77: si   1Q
           ::.. .r .. :P7.r7r..:iLQQJ: rv   ..
          7  iK::r  . ii7r LJLrL1r7DPi iJ     r
            .  ::.:   .  ri 5DZDBg7JR7.:r:   i.
           .Pi r..r7:     i.:XBRJBY:uU.ii:.  .
           QB rJ.:rvDE: .. ri uv . iir.7j r7.
          iBg ::.7251QZ. . :.      irr:Iu: r.
           QB  .:5.71Si..........  .sr7ivi:U
           7BJ .7: i2. ........:..  sJ7Lvr7s
            jBBdD. :. ........:r... YB  Bi
               :7j1.                 :  :
        少女祈禱中...
        
        """;

    static String Json = """
         第1种json类型样本:
{
	"NPCName": {
		"GiantWormHead": "Giant Worm",
		"SeekerTail": "World Feeder",
		"Clinger": "Clinger",
		"AnglerFish": "Angler Fish",
		"GreenJellyfish": "Green Jellyfish",
		"Werewolf": "Werewolf",
		"BoundGoblin": "Bound Goblin",
		"BoundWizard": "Bound Wizard"
    }
}


第2种json类型样本:
[
{"name": "Fury Sliver", "mana_cost": "{5}{R}", "type_line": "Creature \u2014 Sliver", "oracle_text": "All Sliver creatures have double strike.", "color_identity": ["R"]},
{"name": "Kor Outfitter", "mana_cost": "{W}{W}", "type_line": "Creature \u2014 Kor Soldier", "oracle_text": "When Kor Outfitter enters the battlefield, you may attach target Equipment you control to target creature you control.", "color_identity": ["W"]},
{"name": "Spirit", "mana_cost": "", "type_line": "Token Creature \u2014 Spirit", "oracle_text": "Flying", "color_identity": ["W"]},
]





第3种json类型样本:

{
  "m_GameObject": {
    "m_FileID": 0,
    "m_PathID": 0
  },
  "m_Enabled": 0,
  "m_Script": {
    "m_FileID": 0,
    "m_PathID": -6209307414972341411
  },
  "m_Name": "Locx_EN",
  "_code": "EN",
  "_strings": {
    "Array": [
      {
        "Key": "loc_ui_id_thankyouforyoursupport",
        "Value": "Thank you for your support"
      },
      {
        "Key": "loc_ui_id_language",
        "Value": "Language"
      },
      {
        "Key": "loc_ui_id_play",
        "Value": "Play"
      }
    ]
  }
}

第4种json格式：
{
"idle":
{
    "texts":[
        {"voice":"kni0345","text":"我要玩原神"},
        {"voice":"kni0346","text":"我要玩原神"},
        {"voice":"kni0347","text":"我要玩原神"},
        {"voice":"kni0360","text":"我要玩原神"},
        {"voice":"kni0361","text":"我要玩原神"}
    ]
},
"pistonSlow":
{
    "texts":[
        {"voice":"kni0348","text":"我要玩原神"},
        {"voice":"kni0349","text":"我要玩原神"},
        {"voice":"kni0350","text":"我要玩原神"},
        {"voice":"kni0363","text":"我要玩原神"}
    ]
},
"pistonFast":
{
    "texts":[
        {"voice":"kni0351","text":"我要玩原神"},
        {"voice":"kni0352","text":"我要玩原神"},
        {"voice":"kni0353","text":"我要玩原神"}
        ]
}
}
""";










    



    



    static async Task Main(string[] args)
    {
        bool isSubPage1 = false;
        bool isSubPage2 = false;
        bool isSubPage3 = false;

        Console.WriteLine(Logs);



        while (true)
        {
            if (isSubPage1)
            {
                Console.WriteLine("支持的json格式：\n");
                Console.WriteLine(Json);
                Console.WriteLine("1. 返回主页面");
            }
            else if (isSubPage2)
            {
                Console.WriteLine("提取字符串\n");
                Console.WriteLine("1. 提取所有键的值");
                Console.WriteLine("2. 提取一种键的值");
                Console.WriteLine("3. 多文件指定键");
                Console.WriteLine("0. 返回主页面");
            }
            else if (isSubPage3)
            {
                Console.WriteLine("替换字符串\n");
                Console.WriteLine("1. 替换所有键的值");
                Console.WriteLine("2. 替换一种键的值");
                Console.WriteLine("3. 多文件指定键");
                Console.WriteLine("0. 返回主页面");
            }
            else
            {
                Console.WriteLine("主页面");
                Console.WriteLine("1. 支持的json格式");
                Console.WriteLine("2. 提取字符串");
                Console.WriteLine("3. 替换字符串");
                Console.WriteLine("4. 分割字符串为文件");
                Console.WriteLine("5. 合并分割文件");
                Console.WriteLine("6. 重新分配多文件");
                Console.WriteLine("7. 自动翻译（文件）");
                Console.WriteLine("8. 自动翻译（文件夹）");
                Console.WriteLine("0. 退出");
            }

            Console.WriteLine("请输入一个值：");
            int input = Convert.ToInt32(Console.ReadLine());

            if (isSubPage1)
            {
                if (input == 1)
                {
                    isSubPage1 = false;
                }
                else
                {
                    Console.WriteLine("无效值");
                }
            }
            else if (isSubPage2)
            {
                if (input == 1)
                {
                    Console.WriteLine("请输入json路径：");
                    string jsonFilePath = Console.ReadLine();
                    Console.WriteLine("请输入输出路径：");
                    string outputFilePath = Console.ReadLine();

                    outputFilePath = outputFilePath.Replace("\\", "/");
                    jsonFilePath = jsonFilePath.Replace("\\", "/");

                    Extract.ExtractStringValues(jsonFilePath, outputFilePath);
                    Console.WriteLine("\n\n提取成功");
                }
                else if (input == 2)
                {
                    Console.WriteLine("请输入json路径：");
                    string jsonFilePath = Console.ReadLine();
                    Console.WriteLine("请输入指定键：");
                    string Keys = Console.ReadLine();
                    Console.WriteLine("请输入输出路径：");
                    string outputFilePath = Console.ReadLine();
                    
                    outputFilePath = outputFilePath.Replace("\\", "/");
                    jsonFilePath = jsonFilePath.Replace("\\", "/");

                    Extract.ExtractStringValues_1(jsonFilePath, Keys, outputFilePath);
                    Console.WriteLine("\n\n提取成功");
                }
                else if (input == 3)
                {
                    Console.WriteLine("请输入文件夹路径：");
                    string jsonFilePath = Console.ReadLine();
                    Console.WriteLine("请输入指定键：");
                    string Keys = Console.ReadLine();
                    Console.WriteLine("请输入输出文件夹路径：");
                    string outputFilePath = Console.ReadLine();

                    outputFilePath = outputFilePath.Replace("\\", "/");
                    jsonFilePath = jsonFilePath.Replace("\\", "/");

                    Console.WriteLine("\n\n提取成功");

                }
                else if (input == 0)
                {
                    isSubPage2 = false;
                }
                else 
                {
                    Console.WriteLine("无效值");
                }
            }
            else if (isSubPage3)
            {
                if (input == 1)
                {
                    Console.WriteLine("请输入json路径：");
                    string jsonFilePath = Console.ReadLine();
                    Console.WriteLine("请输入文本路径：");
                    string valuesFilePath = Console.ReadLine();
                    Console.WriteLine("请输入输出路径：");
                    string outputFilePath = Console.ReadLine();
                    Console.WriteLine("是否格式化（false/true）：");
                    bool gsh = Convert.ToBoolean(Console.ReadLine());

                    jsonFilePath = jsonFilePath.Replace("\\", "/");
                    valuesFilePath = valuesFilePath.Replace("\\", "/");
                    outputFilePath = outputFilePath.Replace("\\", "/");

                    Replace.ReplaceStringValues(jsonFilePath, valuesFilePath, outputFilePath, gsh);

                    Console.WriteLine("\n\n替换成功");


                    Console.WriteLine("\n\n替换成功");
                }
                else if (input == 2)
                {
                    Console.WriteLine("请输入json路径：");
                    string jsonFilePath = Console.ReadLine();
                    Console.WriteLine("请输入指定键：");
                    string keys = Console.ReadLine();
                    Console.WriteLine("请输入文本路径：");
                    string valuesFilePath = Console.ReadLine();
                    Console.WriteLine("请输入输出路径：");
                    string outputFilePath = Console.ReadLine();
                    Console.WriteLine("是否格式化（false/true）：");
                    bool gsh = Convert.ToBoolean(Console.ReadLine());

                    jsonFilePath = jsonFilePath.Replace("\\", "/");
                    valuesFilePath = valuesFilePath.Replace("\\", "/");
                    outputFilePath = outputFilePath.Replace("\\", "/");

                    Replace.ReplaceStringValues_1(jsonFilePath, valuesFilePath, outputFilePath, keys, gsh);
                    
                    Console.WriteLine("\n\n替换成功");
                }
                else if (input == 3)
                {
                    Console.WriteLine("请输入json文件夹路径：");
                    string jsonFilePath = Console.ReadLine();
                    Console.WriteLine("请输入指定键：");
                    string keys = Console.ReadLine();
                    Console.WriteLine("请输入文本文件夹路径：");
                    string valuesFilePath = Console.ReadLine();
                    Console.WriteLine("请输入输出文件夹路径：");
                    string outputFilePath = Console.ReadLine();

                    jsonFilePath = jsonFilePath.Replace("\\", "/");
                    valuesFilePath = valuesFilePath.Replace("\\", "/");
                    outputFilePath = outputFilePath.Replace("\\", "/");

                    Replace.ReplaceJsonText(jsonFilePath, valuesFilePath, outputFilePath, keys);
                    Console.WriteLine("\n\n替换成功");

                }
                else if (input == 0)
                {
                    isSubPage3 = false;
                }
                else
                {
                    Console.WriteLine("无效值");
                }
            }
            else
            {
                if (input == 1)
                {
                    isSubPage1 = true;
                }
                else if (input == 2)
                {
                    isSubPage2 = true;
                }
                else if (input == 3)
                {
                    isSubPage3 = true;
                }
                else if (input == 4)
                {
                    Console.WriteLine("请输入文本路径：");
                    string inputFilePath = Console.ReadLine();
                    Console.WriteLine("请输入输出文件夹路径：");
                    string outputDirectory = Console.ReadLine();

                    inputFilePath = inputFilePath.Replace("\\", "/");
                    outputDirectory = outputDirectory.Replace("\\", "/");

                    SplitConsolidate.SplitTextFile(inputFilePath, outputDirectory);
                }
                else if (input == 5)
                {
                    Console.WriteLine("请输入文件夹路径：");
                    string inputDirectory = Console.ReadLine();
                    Console.WriteLine("请输入输出文件路径：");
                    string outputFilePath = Console.ReadLine();

                    inputDirectory = inputDirectory.Replace("\\", "/");
                    outputFilePath = outputFilePath.Replace("\\", "/");

                    SplitConsolidate.MergeTextFiles(outputFilePath, inputDirectory);
                }
                else if (input == 6) 
                {
                    Console.WriteLine("请输入提取多文件的字符串文件路径: ");
                    string inputfile = Console.ReadLine();
                    Console.WriteLine("请输入被分割的字符串文件的文件夹路径: ");
                    string inputDirectory = Console.ReadLine();
                    Console.WriteLine("请输入分配输出的文件夹路径: ");
                    string outputDirectory = Console.ReadLine();

                    inputfile = inputfile.Replace("\\", "/");
                    outputDirectory = outputDirectory.Replace("\\", "/");
                    inputDirectory = inputDirectory.Replace("\\", "/");

                    specially.ReplaceAndSaveAsJson(inputfile, inputDirectory, outputDirectory);
                }
                else if (input == 7)
                {
                    Console.WriteLine("请输入文本路径：");
                    string inputFile = Console.ReadLine();
                    Console.WriteLine("是否跳过<>中的字符串（false/true）：");
                    bool skip_tags = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("请输入输出文件夹路径：");
                    string outputFilePath = Console.ReadLine();
                    inputFile = inputFile.Replace("\\", "/");
                    outputFilePath = outputFilePath.Replace("\\", "/");

                    Translator translator = new Translator();
                    translator.Translate("要翻译的文本", result =>
                    {
                        Console.WriteLine(result);
                    }, "中译英", true);
                    translator.TranslateFile(inputFile, outputFilePath, "英译中", skip_tags);
                }
                else if (input == 8)
                {
                    Console.WriteLine("请输入文件夹路径：");
                    string inputFile = Console.ReadLine();
                    Console.WriteLine("一次翻译文件数量：");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("是否跳过<>中的字符串（false/true）：");
                    bool skip_tags = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("请输入输出文件夹路径：");
                    string outputFilePath = Console.ReadLine();

                    inputFile = inputFile.Replace("\\", "/");
                    outputFilePath = outputFilePath.Replace("\\", "/");

                    Translator translator = new Translator();
                    translator.Translate("要翻译的文本", result =>
                    {
                        Console.WriteLine(result);
                    }, "中译英", true);
                    translator.TranslateFolder(inputFile, outputFilePath, "英译中", skip_tags, amount);
                }
                else if (input == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("无效值");
                }
            }
        }
    }
}