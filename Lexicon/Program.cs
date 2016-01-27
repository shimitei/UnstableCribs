﻿using System;
using Translator.Database;

namespace Lexicon
{
    class Program
    {
        static void Main(string[] args)
        {
            var importTSV = "lexicon.txt";// CommandLineUtil.GetCommandOption("-import:", null);
            var exportTSV = CommandLineUtil.GetCommandOption("-export:", null);
            if (!string.IsNullOrEmpty(importTSV))
            {
                DatabaseUtil.ImportFromTSV(importTSV);
            }
            else if (!string.IsNullOrEmpty(exportTSV))
            {
                //TODO export
                //DatabaseUtil.ExportFromTSV(importTSV);
            }
            else
            {
                var list = CommandLineUtil.GetCommandOption();
                if (list.Count > 0)
                {
                    foreach (string s in list)
                    {
                        //TODO translate
                        //DatabaseUtil.translate(s);
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
            Console.WriteLine("Usage: lexicon [-import:filepath]");
            //Console.WriteLine("Usage: lexicon [-import:filepath] [-export:filepath] [-translate] translate-word");
        }
    }
}