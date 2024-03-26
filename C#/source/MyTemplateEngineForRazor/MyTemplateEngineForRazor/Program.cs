using System;
using System.Web;
using Newtonsoft.Json;
using RazorEngine;
using RazorEngine.Templating;


class MyTemplateEngine
{
    const bool IS_DEBUG = true;
    static string DEBUG_TEMPLATE = "";
    static string DEBUG_JSON = ""; 
    static string DEBUG_EXPORT_PATH = "";


    /// <summary>
    /// テンプレート出力
    /// </summary>
    /// <param name="args">
    /// arg1:テンプレートファイルパス（テキスト形式）
    /// arg2:Modelファイルパス（json形式）
    /// arg3:出力ファイルパス（json形式）
    /// </param>
    static void Main(string[] args)
    {
        if (IS_DEBUG)
        {
            DEBUG_TEMPLATE = "..\\..\\..\\..\\..\\..\\baseFormat.cshtml";
            DEBUG_JSON = "..\\..\\..\\..\\..\\..\\importFiles\\m_test.json";
            DEBUG_EXPORT_PATH = "..\\..\\..\\..\\..\\..\\results\\m_test.cs";
        }

        Array.Resize(ref args, 3);
        // arg1:テンプレートファイルパス（テキスト形式）
        string templateContentsPath = !string.IsNullOrEmpty(args[0]) ? args[0] : DEBUG_TEMPLATE;
        // arg2:Modelファイルパス（json形式）
        string jsonContentsPath = !string.IsNullOrEmpty(args[1]) ? args[1] : DEBUG_JSON;
        // arg3:出力パス
        string exportPath = !string.IsNullOrEmpty(args[2]) ? args[2] : DEBUG_EXPORT_PATH;

        // ファイル読込
        Console.WriteLine("File Loading");
        string templateContents = File.ReadAllText(templateContentsPath);
        string jsonContents = File.ReadAllText(jsonContentsPath);
        object jsonObject = JsonConvert.DeserializeObject(jsonContents) ?? new { };

        string toRazorContents = "";
        toRazorContents += templateContents;
        Console.WriteLine("RunCompile");
        var encodeResult = Engine.Razor.RunCompile(toRazorContents, "templateKey", null, jsonObject);
        
        // HTMLデコードして元のテキストに戻す
        string result = HttpUtility.HtmlDecode(encodeResult);
        ExportFile(result, exportPath);
        Console.WriteLine("Complete");
    }

    static void ExportFile(string contents, string outputFile){
        string directoryPath = Path.GetDirectoryName(outputFile) ?? "";
        // 出力先フォルダが存在しない場合は作成する
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        File.WriteAllText(outputFile, contents);
    }
}