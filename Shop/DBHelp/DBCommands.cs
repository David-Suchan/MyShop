using DBHelp;
using Shop.Model2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DBHelp
{
    internal class DBCommands
    {
        DBInfo dBInfo = new DBInfo();
        static public void CreateDatabase()
        {
            if (!File.Exists(DBInfo.file))
            {
                SQLiteConnection.CreateFile(DBInfo.file);
            }
            
            DBInfo.cmd.CommandText = "DROP TABLE IF EXISTS users";
            DBInfo.cmd.ExecuteNonQuery();

            DBInfo.cmd.CommandText = @"CREATE TABLE user(id INTEGER PRIMARY KEY, username TEXT, password TEXT, balance DECIMAL)";
            DBInfo.cmd.ExecuteNonQuery();
        }
        public static void AddToDatabase(string username, string password, decimal balance = 1000m)
        {
            DBInfo.cmd.CommandText = $@"INSERT INTO user(username, password, balance) VALUES('{username}','{password}', {balance})";
            DBInfo.cmd.ExecuteNonQuery();
        }
        public static List<User> ReadFromDatabase()
        {
           
            var List = new List<User>();

            SQLiteDataReader rdr = DBInfo.cmd.ExecuteReader();
            while (rdr.Read())
            {

                var user = new User();
                user.Id = rdr.GetInt32(0);
                user.UserName = rdr.GetString(1);
                user.Password = rdr.GetString(2);
                user.Balance = rdr.GetInt32(3);
                
                List.Add(user);


            }
            return List;
        }

    }
}

