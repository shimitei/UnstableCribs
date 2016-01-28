using Translator.IO;

namespace Translator.Database
{
    public class DatabaseUtil
    {
        public static DatabaseConnectionHelper Open()
        {
            var result = new DatabaseConnectionHelper(Statics.DbFilename, DatabaseAction.CreateTable);
            return result;
        }

        public static void ImportFromTSV(string filepath)
        {
            using (var helper = Open())
            {
                using (var transaction = helper.Connection.BeginTransaction())
                {
                    // truncate table
                    DatabaseAction.TruncateTable(helper.Connection);

                    // insert data
                    FileUtil.TSV(filepath, ar =>
                    {
                        if (ar.Length >= 2)
                        {
                            // TSV line
                            //   KEY[tab]A/B/C
                            // insert data
                            //   key:'KEY'
                            //   value:'A/B/C'
                            DatabaseAction.InsertData(helper.Connection, ar[0], ar[1]);
                        }
                    });
                    transaction.Commit();
                }
            }
        }
    }
}
