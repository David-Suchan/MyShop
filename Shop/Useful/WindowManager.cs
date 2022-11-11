using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.View;

namespace Shop.Useful
{
    internal class WindowManager
    {
        public static MainWindow mainWindow;
        public static ClothesWindow clothesWindow;
        public static CartWindow cartWindow;
        public static CheckedOutWindow checkedOutWindow;
        public static CreateAccountWindow createAccountWindow;
        public static LoginWindow loginWindow;
        public static void OpenMainWindow()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
        }

        public static void CloseMainWindow()
        {
            if (mainWindow != null)
            {
                mainWindow.Close();
            }
            mainWindow = null;
        }
        public static void OpenClothesWindow()
        {
            clothesWindow = new ClothesWindow();
            clothesWindow.Show();
        }
        public static void CloseClothesWindow()
        {
            if (clothesWindow != null)
            {
                clothesWindow.Close();
            }
            clothesWindow = null;
        }
        public static void OpenCartWindow()
        {
            cartWindow = new CartWindow();
            cartWindow.Show();
        }
        public static void CloseCartWindow()
        {
            if(cartWindow != null)
            {
                cartWindow.Close();
            }
            cartWindow = null;
        }
        public static void OpenCheckedOutWindow()
        {
            checkedOutWindow = new CheckedOutWindow();
            checkedOutWindow.Show();
        }
        public static void CloseCheckedOutWindow()
        {
            if(checkedOutWindow != null)
            {
                checkedOutWindow.Close();
            }
            checkedOutWindow = null;
        }
        public static void OpenCreateAccountWindow()
        {
            createAccountWindow = new CreateAccountWindow();
            createAccountWindow.Show();
        }
        public static void CloseCreateAccountWindow()
        {
            if(createAccountWindow != null)
            {
                createAccountWindow.Close();
            }
            createAccountWindow = null;
        }
        public static void OpenLoginWindow()
        {
            loginWindow = new LoginWindow();
            loginWindow.Show();
        }
        public static void CloseLoginWindow()
        {
            if(loginWindow != null)
            {
                loginWindow.Close();
            }
            loginWindow = null;
        }
    }
}
