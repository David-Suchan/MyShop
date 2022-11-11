using CommunityToolkit.Mvvm.Input;
using Shop.Model2;
using Shop.Useful;
using Shop.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModel2
{
    internal class ClothesViewModel : ViewModelBase
    {
        static public User David = new User();
        public RelayCommand<decimal> BuyCommand { get; set; }

        public RelayCommand<Item> AddCommand { get; set; }

        public RelayCommand<string> RefreshCommand { get; set; }

        public RelayCommand HomepageCommand { get; set; }

        public RelayCommand CartCommand { get; set; }
        public string SkirtPhoto
        {
            get { return @"C:\Users\DAVID\Desktop\Shop Photos\Skirt.jpg"; }
        }

        public string GreenTshirtPhoto
        {
            get { return @"C:\Users\DAVID\Desktop\Shop Photos\GreenShirt.jpg"; }
        }

        public string SlacksPhoto
        {
            get { return @"C:\Users\DAVID\Desktop\Shop Photos\Slacks.jpg"; }
        }

        private decimal davidBalance = David.Balance;

        public decimal DavidBalance
        {
            get { return davidBalance; }
            set
            {
                davidBalance = value;
                OnPropertyChanged(nameof(DavidBalance));
            }
        }

        private void BuyCommandExecute(decimal price)
        {
            DavidBalance = DavidBalance - price;
        }
        private void HomepageCommandExecute()
        {
            WindowManager.OpenMainWindow();
            WindowManager.CloseClothesWindow();
        }

        static public decimal TotalPrice { get; set; }
        private void CartCommandExecute()
        {

            WindowManager.OpenCartWindow();
            WindowManager.CloseClothesWindow();

        }


        public Item Skirt { get; set; } = new Item();
        public Item GreenTshirt { get; set; } = new Item();
        public Item Slacks { get; set; } = new Item();

        static public ObservableCollection<Item> Cart { get; set; } = new ObservableCollection<Item>();

        public static CartWindow cartWindow = new CartWindow();

        private void AddCommandExecute(Item item)
        {
            CartViewModel cartViewModel = new CartViewModel();

            Cart.Add(item);
            TotalPrice += item.Price;


        }
        public ClothesViewModel()
        {
            CartCommand = new RelayCommand(CartCommandExecute);
            BuyCommand = new RelayCommand<decimal>(BuyCommandExecute);
            HomepageCommand = new RelayCommand(HomepageCommandExecute);
            AddCommand = new RelayCommand<Item>(AddCommandExecute);
            Skirt.Price = 29.99m;
            Skirt.Name = "Skirt";
            Slacks.Price = 49.99m;
            Slacks.Name = "Slacks";
            GreenTshirt.Price = 34.99m;
            GreenTshirt.Name = "Green t-shirt";
        }

    }
}
