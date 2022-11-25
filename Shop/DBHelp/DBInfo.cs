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
        static public string File = @"C:\Users\DAVID\Desktop\ShopUsers.db";      
        static string ConnectionString = "Data Source=" + File + ";New=True";
        static public SQLiteConnection Connection = new SQLiteConnection(ConnectionString);
        static public SQLiteCommand Cmd = new SQLiteCommand(Connection);


        public DBInfo()
        {
            Connection.Open();
        }
    }
}
