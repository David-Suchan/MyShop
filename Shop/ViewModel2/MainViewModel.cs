using CommunityToolkit.Mvvm.Input;
using Shop.Model2;
using Shop.Useful;

namespace Shop.ViewModel2
{
    internal class MainViewModel : ViewModelBase
    {
        static CheckedOutViewModel checkedOutViewModel = new CheckedOutViewModel();
        public RelayCommand OpenClothesWindowCommand { get; set; }
        public User CurrentUser { get; set; } = new User();


        private decimal balance = checkedOutViewModel.CheckedOutBalance;

        public decimal Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public MainViewModel()
        {

            OpenClothesWindowCommand = new RelayCommand(OpenClothesWindowCommandExecute);
        }

        private void OpenClothesWindowCommandExecute()
        {
            CartViewModel cartViewModel = new CartViewModel();


            WindowManager.OpenClothesWindow();
            WindowManager.CloseMainWindow();

        }
    }
}
