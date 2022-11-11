
using System;
using DBHelp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Shop.Useful;
using Shop.DBHelp;

namespace Shop.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            DBInfo dBInfo = new DBInfo();
            WindowManager.loginWindow = this;
            DBCommands.CreateDatabase();
            
                

            
            InitializeComponent();

        }
    }
}
