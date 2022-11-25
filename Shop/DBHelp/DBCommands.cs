using DBHelp;
using Shop.Model2;
using Shop.ViewModel2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Shop.DBHelp
{
    internal class DBCommands
    {
        DBInfo dBInfo = new DBInfo();
        static public void CreateDatabase()
        {
            if (!File.Exists(DBInfo.File))
            {
                SQLiteConnection.CreateFile(DBInfo.File);
            }           
        }
        public static void CreateUserTable()
        {
            DBInfo.Connection.Open();
            DBInfo.Cmd.CommandText = "DROP TABLE IF EXISTS users";
            DBInfo.Cmd.ExecuteNonQuery();

            DBInfo.Cmd.CommandText = @"CREATE TABLE user(id INTEGER PRIMARY KEY, username TEXT, password TEXT, balance DECIMAL)";
            DBInfo.Cmd.ExecuteNonQuery();
            DBInfo.Connection.Close();
        }
        public static void CreateRecentlyPurchasedTable()
        {
            
            DBInfo.Cmd.CommandText = "DROP TABLE IF EXISTS recentlypurchased";
            DBInfo.Cmd.ExecuteNonQuery();
            DBInfo.Cmd.CommandText = @"CREATE TABLE recentlypurchased(id INTEGER PRIMARY KEY, user_id INT, name STRING, price DECIMAL )";
            DBInfo.Cmd.ExecuteNonQuery();
            
        }
        public static User AddToUserTable(string username, string password, decimal balance = 1000m)
        {
            
            DBInfo.Cmd.CommandText = $@"INSERT INTO user(username, password, balance) VALUES('{username}','{password}', {balance})";
            DBInfo.Cmd.ExecuteNonQuery();
            return new User()
            {
                UserName = username,
                Password = password,
                Balance = balance,
                LoggedIn = true
            };
            
        }
        public static void AddToRecentlyPurchasedTable(int user_id, Item item)
        {
            



            DBInfo.Cmd.CommandText = $@"INSERT INTO recentlypurchased(user_id, name, price) VALUES({user_id}, '{item.Name}', {item.Price})";
            
            DBInfo.Cmd.ExecuteNonQuery();
            
        }

        public static List<User> ReadFromDatabase()
        
        {
            DBInfo.Connection.Open();

            var List = new List<User>();
            

            SQLiteDataReader rdr = DBInfo.Cmd.ExecuteReader();

            while (rdr.Read())
            {

                var user = new User();
                user.Id = rdr.GetInt32(0);
                user.UserName = rdr.GetString(1);
                user.Password = rdr.GetString(2);
                user.Balance = rdr.GetInt32(3);
                
                List.Add(user);
                DBInfo.Connection.Close();


            }
            return List;
        }
        public static User CheckIfUserExists(string username)
        {
            
            DBInfo.Cmd.CommandText = $@"SELECT * FROM user WHERE username = '{username}'";
            using SQLiteDataReader rdr = DBInfo.Cmd.ExecuteReader();

            while (rdr.Read())
            {

                var user = new User();
                user.Id = rdr.GetInt32(0);
                user.UserName = rdr.GetString(1);
                user.Password = rdr.GetString(2);
                user.Balance = rdr.GetDecimal(3);

                return user;
                
            }
            return null;
        }
        public static void UpdateBalance(int id, decimal newbalance)
        {

            DBInfo.Cmd.CommandText = $@"UPDATE user SET balance = {newbalance} WHERE id = {id}";
            DBInfo.Cmd.ExecuteNonQuery();


        }
        public static void GetRecentlyPurchased(int id)
        {
            ObservableCollection<Item> items = new ObservableCollection<Item>();
            DBInfo.Cmd.CommandText = $@"SELECT ALL * FROM recentlypurchased WHERE user_id = {id}";
            using SQLiteDataReader rdr = DBInfo.Cmd.ExecuteReader();           
            while (rdr.Read())
            {

                var item = new Item();
                item.Name = rdr.GetString(2);
                item.Price = rdr.GetDecimal(3);
                items.Add(item);
            }
            AccountInfoViewModel.RecentlyPurchased = items;
            
        }

    }
}

