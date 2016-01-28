using System;
using System.Data.SQLite;
using Translator.Model;

namespace Translator.Database
{
    internal class DatabaseAction
    {
        public static Action<SQLiteConnection> CreateTable = (conn) =>
        {
            using (SQLiteCommand command = new SQLiteCommand(conn))
            {
                command.CommandText =
                    "CREATE TABLE lexicon("
                        + "id INTEGER PRIMARY KEY AUTOINCREMENT"
                        + ",word text"
                        + ",translator text"
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
                    "INSERT INTO lexicon(word, translator) VALUES ('{0}', '{1}')",
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

        public static Action<SQLiteConnection, Action<Lexicon>> SelectAll = (conn, action) =>
        {
            using (SQLiteCommand command = new SQLiteCommand(conn))
            {
                command.CommandText = "SELECT * FROM lexicon;";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        action(ToLexicon(reader));
                    }
                }
            }
        };

        private static Lexicon ToLexicon(SQLiteDataReader reader)
        {
            var result = new Lexicon();
            result.Id = Convert.ToInt32(reader["id"].ToString());
            result.Word = reader["word"].ToString();
            result.Translator = reader["translator"].ToString();
            return result;
        }

        public static Action<SQLiteConnection, string, Action<Lexicon>> Select = (conn, s, action) =>
        {
            using (SQLiteCommand command = new SQLiteCommand(conn))
            {
                command.CommandText = string.Format(
                    "SELECT * FROM lexicon WHERE translator like '%{0}%';",
                    SqlSanitize(s)
                    );
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        action(ToLexicon(reader));
                    }
                }
            }
        };

    }
}
