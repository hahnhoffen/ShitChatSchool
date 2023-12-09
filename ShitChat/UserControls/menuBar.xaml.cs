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
    /// Interaction logic for menuBar.xaml
    /// </summary>
    public partial class menuBar : UserControl
    {
        profilePage ProfilePage;
        UserManager userManager;

        public menuBar()
        {
            InitializeComponent();
        }


        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                tbPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                tbPlaceHolder.Visibility = Visibility.Hidden;
                txtInput.Foreground = Brushes.White;
            }
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }


        public void SetUserName(string username)
        {
            btn_userMenu.Content = username;
        }


        public void SetProfilePage(profilePage ProfilePage, UserManager userManager)
        {
            this.ProfilePage = ProfilePage;
            this.userManager = userManager;
        }


        private void txtInput_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string friendsName = txtInput.Text;
                ProfilePage.SearchFriend(friendsName);
                ProfilePage.Visibility = Visibility.Visible;
                txtInput.Clear();
            }
        }


        private void btn_userMenu_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage.SearchFriend(userManager.currentUser.UserName);
            ProfilePage.Visibility = Visibility.Visible;
        }
    }
}
