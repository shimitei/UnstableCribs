using System;
using System.Data.SQLite;
using System.Diagnostics;

namespace Translator.Database
{
    public class DatabaseConnection : IDisposable
    {
        public SQLiteConnection Connection { get; set; }

        public static DatabaseConnection Open()
        {
            var result = new DatabaseConnection(Statics.DbFilename, DatabaseAction.CreateTable);
            return result;
        }

        public DatabaseConnection(string dbFilename, Action<SQLiteConnection> createAction = null)
        {
            if (System.IO.File.Exists(dbFilename))
            {
                Debug.WriteLine("DB file exists");
                Connection = new SQLiteConnection(string.Format("DataSource={0};Version=3;", dbFilename));
                Connection.Open();
            }
            else
            {
                Debug.WriteLine("DB file not exists");
                Connection = new SQLiteConnection(string.Format("DataSource={0};Version=3;New=True;", dbFilename));
                Connection.Open();
                if (createAction != null)
                {
                    Debug.WriteLine("DB create action");
                    createAction(Connection);
                }
            }
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
