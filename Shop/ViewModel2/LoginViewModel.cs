using CommunityToolkit.Mvvm.Input;
using Shop.Useful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModel2
{
    internal class LoginViewModel
    {
        public RelayCommand OpenCreateWindowCommand { get; set; }

        public void OpenCreateWindowCommandExecute()
        {
            WindowManager.OpenCreateAccountWindow();
            WindowManager.CloseLoginWindow();
        }

        public LoginViewModel()
        {
            this.OpenCreateWindowCommand = new RelayCommand(OpenCreateWindowCommandExecute);
        }
    }
}
