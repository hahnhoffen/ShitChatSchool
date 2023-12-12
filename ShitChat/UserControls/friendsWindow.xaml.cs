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
    /// Interaction logic for friendsWindow.xaml
    /// </summary>
    public partial class friendsWindow : UserControl
    {
        public friendsWindow()
        {
            textboxAddFriend.Visibility = Visibility.Collapsed;
            searchNewFriends.Visibility = Visibility.Collapsed;
            removeFriend_ListBox.Visibility = Visibility.Collapsed;
            InitializeComponent();
        }

        private void AddFriends_Click(object sender, RoutedEventArgs e)
        {
            AddFriends.Visibility = Visibility.Collapsed;
            RemoveFriends.Visibility = Visibility.Collapsed;
            textboxAddFriend.Visibility = Visibility.Visible;
            searchNewFriends.Visibility = Visibility.Visible;
            //if (search=username) show user
            //else cw"User not found, try again"
        }

        private void RemoveFriends_Click(object sender, RoutedEventArgs e)
        {
            AddFriends.Visibility = Visibility.Collapsed;
            RemoveFriends.Visibility = Visibility.Collapsed;
            removeFriend_ListBox.Visibility = Visibility.Visible;
            //listbox för att se vänner
            //foreach (friend friend in friendslist) show friendlist
            //click. POPUP-msgbox cw"Are you sure you want to remove this friend?"
            //Friend removed

        }

        private void removeFriend_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (friend friends in currentUser_friendslist)
        }
    }
}
