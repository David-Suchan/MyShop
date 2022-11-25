using CommunityToolkit.Mvvm.Input;
using Shop.DBHelp;
using Shop.Model2;
using Shop.Useful;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModel2
{
    class AccountInfoViewModel : ViewModelBase
    {
        public static string UserName { get; set; }

        public static string Password { get; set; }

        public static ObservableCollection<Item> RecentlyPurchased { get; set; }

        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public RelayCommand OpenMainWindowCommand { get; set; }

        public static void OpenMainWindowCommandExecute()
        {
            WindowManager.OpenMainWindow();
            WindowManager.CloseAccountInfoWindow();
        }
        public AccountInfoViewModel()
        {
            this.OpenMainWindowCommand = new RelayCommand(OpenMainWindowCommandExecute);
        }

    }
}
