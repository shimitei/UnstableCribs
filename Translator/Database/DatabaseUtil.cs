using System.Collections.Generic;
using System.Data.SQLite;
using Translator.IO;

namespace Translator.Database
{
    public class DatabaseUtil
    {
        public static DatabaseConnectionHelper Open()
        {
            var result = new DatabaseConnectionHelper(Statics.DbFilename, DatabaseAction.OnCreateDatabaseAction);
            return result;
        }

        public static void ImportFromTSV(string filepath)
        {
            using (var helper = Open())
            {
                using (var transaction = helper.Connection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(helper.Connection))
                    {
                        FileUtil.TSV(filepath, ar =>
                        {
                            var arLength = ar.Length;
                            if (arLength >= 2)
                            {
                                // TSV line
                                //   KEY[tab]A[tab]B[tab]C
                                // to
                                //   [KEY,A],[KEY,B],[KEY,C]
                                // INSERT INTO lexicon(input, output) VALUES (?, KEY);
                                var key = ar[0];
                                for (var i = 1; i < arLength; i++)
                                {
                                    command.CommandText = string.Format(
                                        "INSERT INTO lexicon(input, output) VALUES ('{0}', '{1}')",
                                        ar[i], key);
                                    command.ExecuteNonQuery();
                                }
                            }
                        });
                        transaction.Commit();
                    }
                }
            }
        }
    }
}
