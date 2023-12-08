using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShitChat.UserControls
{
    /// <summary>
    /// Interaction logic for profilePage.xaml
    /// </summary>
    public partial class profilePage : UserControl
    {
        RegisterWindow registerWindow;
        UserManager userManager;
        menuBar MenuBar;
        User searchedUser;

        public profilePage()
        {
            InitializeComponent();
        }

        public void SetMenuBar(menuBar MenuBar)
        {
            this.MenuBar = MenuBar;
        }

        public void SetRegisterWindow(RegisterWindow registerWindow)
        {

            this.registerWindow = registerWindow;
        }
        public void SetUserManager(UserManager userManager)
        {
            this.userManager = userManager;

        }

        public void SearchFriend(string friendName)
        {
            foreach (User user in registerWindow.userList)
            {
                if (friendName == user.UserName)
                {
                    searchedUser = user;
                    DisplayProfile(user);
                }
            }
        }

        public void DisplayProfile(User user)
        {
            userNameLabel.Content = user.UserName;
            userCityLabel.Content = "City: " + user.City.ToString();
        }
    }
}
