using System;
using Translator.Command;

namespace Lexicon
{
    class Program
    {
        static void Main(string[] args)
        {
            var importTSV = CommandLineUtil.GetCommandOption("-import:", null);
            var exportTSV = CommandLineUtil.GetCommandOption("-export:", null);
            if (!string.IsNullOrEmpty(importTSV))
            {
                TranslatorCommand.ImportFromTSV(importTSV);
            }
            else if (!string.IsNullOrEmpty(exportTSV))
            {
                TranslatorCommand.ExportToTSV(exportTSV);
            }
            else
            {
                var list = CommandLineUtil.GetCommandOption();
                if (list.Count > 0)
                {
                    foreach (string s in list)
                    {
                        Console.WriteLine("TRANSLATE: {0}", s);
                        foreach (var r in TranslatorCommand.Translate(s))
                        {
                            Console.WriteLine(string.Format("{0}|{1}", r.Word, r.Translator));
                        }
                    }
                }
                else
                {
                    ShowUsage();
                }
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Usage: lexicon [-import:filepath] [-export:filepath] [-translate] translate-word");
        }
    }
}
