using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelp
{
    internal class DBInfo
    {
        static public string file = @"C:\Users\DAVID\Desktop\ShopUsers.db";      
        static public string connection_string = "Data Source=" + file + ";New=True";
        static public SQLiteConnection connection = new SQLiteConnection(connection_string);
        static public SQLiteCommand cmd = new SQLiteCommand(connection);
        SQLiteDataReader rdr;


        public DBInfo()
        {
            connection.Open();
        }
    }
}
