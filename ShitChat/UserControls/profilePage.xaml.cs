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
        UserManager userManager;
        menuBar MenuBar;

        public profilePage()
        {
            InitializeComponent();
        }

        public void SetMenuBar(menuBar MenuBar)
        {
            this.MenuBar = MenuBar;
        }

        public void SetUserManager(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public void SearchFriend(string friendName)
        {

        }
    }
}
