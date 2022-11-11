using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model2
{
    public class User
    {
        public int Id { get; set; }

        public decimal Balance { get; set; } = 1000;

        public string UserName { get; set; }

        public string Password { get; set; }

        public ObservableCollection<Item> RecentlyPurchased { get; set; }

        public bool LoggedIn { get; set; }
    }
}
