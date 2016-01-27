using System;
using System.IO;

namespace Translator.IO
{
    public class FileUtil
    {
        public static void TSV(string filepath, Action<string[]> onReadLine)
        {
            try
            {
                using (var sr = new StreamReader(filepath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] fields = line.Split('\t');
                        onReadLine(fields);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
