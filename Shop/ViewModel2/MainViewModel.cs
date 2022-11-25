using CommunityToolkit.Mvvm.Input;
using Shop.DBHelp;
using Shop.Model2;
using Shop.Useful;

namespace Shop.ViewModel2
{
    internal class MainViewModel : ViewModelBase
    {
        //static CheckedOutViewModel checkedOutViewModel = new CheckedOutViewModel();
        public RelayCommand OpenClothesWindowCommand { get; set; }
        public User CurrentUser { get; set; } = new User();

        public RelayCommand OpenAccountInfoWindowCommand { get; set; }

        public void OpenAccountInfoWindowCommandExecute()
        {
            DBCommands.GetRecentlyPurchased(UserSupport.LoggedInUser.Id);
            WindowManager.OpenAccountInfoWindow();
            WindowManager.CloseMainWindow();
        }




        public MainViewModel()
        {
            this.OpenAccountInfoWindowCommand = new RelayCommand(OpenAccountInfoWindowCommandExecute);
            this.OpenClothesWindowCommand = new RelayCommand(OpenClothesWindowCommandExecute);
        }

        private void OpenClothesWindowCommandExecute()
        {
            CartViewModel cartViewModel = new CartViewModel();


            WindowManager.OpenClothesWindow();
            WindowManager.CloseMainWindow();

        }
    }
}
