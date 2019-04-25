using System;
using System.Data.SQLite;

namespace Projekat
{
    class DataBase
    {
        private static DataBase instance;
        private String connectionString;
        private SQLiteConnection connection;
          
        public static DataBase DataBaseSingleton()
        {
            if (instance == null)
                instance = new DataBase();
            return instance;
        }

        private DataBase()
        {
            connectionString = @"Data Source=C:\Users\while\Dropbox\Kodovi\TVP (C#)\Projekat\Projekat\baza\baza.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
        }

        public SQLiteDataAdapter selectZaDataSet(String sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            return adapter;
        }

        public void upaliKonekciju()
        {
            connection.Open();
        }

        public void ugasiKonekciju()
        {
            connection.Close();
        }
    }
}
