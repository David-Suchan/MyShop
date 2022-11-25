using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Shop.Model2;
using Shop.Useful;

namespace Shop.ViewModel2
{
    internal class CheckedOutViewModel
    {
        //static CartViewModel cartViewModel = new CartViewModel();
        public ObservableCollection<Item> Item { get; set; }

        public RelayCommand OpenMainWindowCommand { get; set; }

        public static void OpenMainWindowCommandExecute()
        {
            WindowManager.OpenMainWindow();
            WindowManager.CloseCheckedOutWindow();
        }
        
        public void HandleMessage(object message)
        {
            var items = (ObservableCollection<Item>)message;
            this.Item = items;
        }

        

        

        public CheckedOutViewModel()
        {
            this.OpenMainWindowCommand = new RelayCommand(OpenMainWindowCommandExecute);
            Messenger.Subscribe(typeof(ObservableCollection<Item>), HandleMessage);
        }

    }
}
