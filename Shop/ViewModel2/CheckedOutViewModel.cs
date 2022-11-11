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

        public decimal CheckedOutBalance { get; set; } = 1000m;

    }
}
