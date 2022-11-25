using CommunityToolkit.Mvvm.Input;
using Shop.DBHelp;
using Shop.Model2;
using Shop.Useful;
using Shop.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Shop.ViewModel2
{
    internal class CartViewModel : ViewModelBase
    {

        
        private ObservableCollection<Item> items = ClothesViewModel.Cart;        
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        static ClothesViewModel clothesViewModel = new ClothesViewModel();

        public decimal price { get; set; } = ClothesViewModel.TotalPrice;

        public RelayCommand RemoveCommand { get; set; }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public RelayCommand CheckedOutWindowCommand { get; set; }

        public static decimal FinalBalance { get; set; } = UserSupport.LoggedInUser.Balance;

        public void RemoveCommandExecute()
        {
            cartWindow.TotalPrice.Text = Convert.ToString(Convert.ToDecimal(cartWindow.TotalPrice.Text) - ClothesViewModel.Cart[cartWindow.cart.SelectedIndex + 1].Price);
            Price -= ClothesViewModel.Cart[cartWindow.cart.SelectedIndex + 1].Price;
            AfterCheckout += ClothesViewModel.Cart[cartWindow.cart.SelectedIndex + 1].Price;
            ClothesViewModel.Cart.RemoveAt(cartWindow.cart.SelectedIndex + 1);
        }




        public void CheckedOutWindowCommandExecute()
        {
            FinalBalance -= Price;
            DBCommands.UpdateBalance(UserSupport.LoggedInUser.Id, FinalBalance);
            foreach (var item in Items)
            {
                DBCommands.AddToRecentlyPurchasedTable(UserSupport.LoggedInUser.Id, item);
            }
            WindowManager.OpenCheckedOutWindow();
            Messenger.SendMessage(typeof(ObservableCollection<Item>), this.Items);
            WindowManager.CloseCartWindow();
        }

        private decimal afterCheckout = FinalBalance - ClothesViewModel.TotalPrice;

        public decimal AfterCheckout
        {
            get
            {
                return afterCheckout;
            }
            set
            {
                afterCheckout = value;
                OnPropertyChanged(nameof(AfterCheckout));

            }
        }

        public decimal AfterCheckout1 { get => afterCheckout; set => afterCheckout = value; }

        public CartViewModel()
        {
            CheckedOutWindowCommand = new RelayCommand(CheckedOutWindowCommandExecute);
            RemoveCommand = new RelayCommand(RemoveCommandExecute);

        }
    }
}
