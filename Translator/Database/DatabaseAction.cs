using System;
using System.Data.SQLite;

namespace Translator.Database
{
    class DatabaseAction
    {
        public static Action<SQLiteConnection> OnCreateDatabaseAction = (conn) =>
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    command.CommandText =
                        "CREATE TABLE Lexicon("
                            + "id INTEGER PRIMARY KEY AUTOINCREMENT"
                            + ",input text"
                            + ",output integer"
                            + ",note text"
                        + ")";

                    command.ExecuteNonQuery();
                }
            };
    }
}
