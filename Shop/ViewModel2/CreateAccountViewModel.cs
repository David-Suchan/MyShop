using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DBHelp;
using Shop.View;
using System.Windows.Controls;
using Shop.Useful;

namespace Shop.ViewModel2
{
    internal class CreateAccountViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public RelayCommand CreateUserCommand { get; set; }

        public void CreateUserCommandExecute()
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow();
            
            DBCommands.AddToDatabase(Username, Password);
            WindowManager.OpenMainWindow();
            WindowManager.CloseCreateAccountWindow();

        }

        public CreateAccountViewModel()
        {
            this.CreateUserCommand = new RelayCommand(CreateUserCommandExecute);
        }
    }
}
