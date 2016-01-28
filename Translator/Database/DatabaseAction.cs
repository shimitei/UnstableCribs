using System;
using System.Data.SQLite;

namespace Translator.Database
{
    class DatabaseAction
    {
        public static Action<SQLiteConnection> CreateTable = (conn) =>
        {
            using (SQLiteCommand command = new SQLiteCommand(conn))
            {
                command.CommandText =
                    "CREATE TABLE Lexicon("
                        + "id INTEGER PRIMARY KEY AUTOINCREMENT"
                        + ",word text"
                        + ",translate text"
                    + ");";

                command.ExecuteNonQuery();
            }
        };

        public static Action<SQLiteConnection> TruncateTable = (conn) =>
        {
            using (SQLiteCommand command = new SQLiteCommand(conn))
            {
                command.CommandText = "DELETE FROM lexicon;";
                command.ExecuteNonQuery();
            }
        };

        public static Action<SQLiteConnection, string, string> InsertData = (conn, key, value) =>
        {
            using (SQLiteCommand command = new SQLiteCommand(conn))
            {
                command.CommandText = string.Format(
                    "INSERT INTO lexicon(word, translate) VALUES ('{0}', '{1}')",
                    SqlSanitize(key), SqlSanitize(value));
                command.ExecuteNonQuery();
            }
        };

        private static string SqlSanitize(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s = s.Replace("'", "");
                s = s.Replace("\"", "");
            }
            return s;
        }
    }
}
