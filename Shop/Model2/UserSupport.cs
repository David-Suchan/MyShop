using Shop.DBHelp;
using Shop.Useful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shop.Model2
{
    public static class UserSupport
    {
        static public User LoggedInUser = new User();
        public static string Username { get; set; }
        public static string Password { get; set; }

        public static void CreateUserCommandExecute()
        {

            var foundUser = DBCommands.CheckIfUserExists(Username);
            if (foundUser == null)
            {
                LoggedInUser = DBCommands.AddToUserTable(Username, Password);

                WindowManager.OpenMainWindow();
                WindowManager.CloseCreateAccountWindow();
            }
            if (foundUser != null)
            {
                MessageBox.Show("That user already exists please create a new user");
            }
        }
    }
}
