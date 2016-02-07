using System.Collections.Generic;
using Translator.Database;
using Translator.Model;

namespace Translator.Command
{
    public class TranslatorCommand
    {
        public static void ImportFromTSV(string filepath)
        {
            DatabaseUtil.ImportFromTSV(filepath);
        }

        public static void ExportToTSV(string filepath)
        {
            DatabaseUtil.ExportToTSV(filepath);
        }

        public static List<Lexicon> Translate(string s)
        {
            List<Lexicon> result;
            using (var helper = DatabaseConnection.Open())
            {
                result = Translate(helper, s);
            }
            return result;
        }

        private static List<Lexicon> Translate(DatabaseConnection helper, string s)
        {
            var result = new List<Lexicon>();
            DatabaseAction.Select(helper.Connection, s, (r) =>
            {
                result.Add(r);
            });
            return result;
        }
    }
}
