using CommunityToolkit.Mvvm.Input;
using Shop.DBHelp;
using Shop.Useful;
using Shop.Model2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shop.ViewModel2
{
    internal class LoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public RelayCommand OpenCreateWindowCommand { get; set; }

        public RelayCommand LoginCommand { get; set; }

        

        public void OpenCreateWindowCommandExecute()
        {

            WindowManager.OpenCreateAccountWindow();
            WindowManager.CloseLoginWindow();
        }
        public void LoginCommandExecute()
        {
            var foundUser = DBCommands.CheckIfUserExists(Username);
            if (foundUser != null)
            {
                UserSupport.LoggedInUser = foundUser;

                WindowManager.OpenMainWindow();
                WindowManager.CloseLoginWindow();
            }
            if (foundUser == null)
            {
                MessageBox.Show("That user doesnt exist already exists please use an existing user");
            }

        }

        public LoginViewModel()
        {
            this.OpenCreateWindowCommand = new RelayCommand(OpenCreateWindowCommandExecute);
            this.LoginCommand = new RelayCommand(LoginCommandExecute);
        }
    }
}
