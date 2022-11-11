using Shop.Useful;
using System.Windows;

namespace Shop.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowManager.mainWindow = this;
            InitializeComponent();
        }
    }
}
