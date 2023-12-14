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

        UserManager manager = new UserManager();
        User user = new User();
        public friendsWindow()
        {

            textboxAddFriend.Visibility = Visibility.Hidden;
            searchNewFriends.Visibility = Visibility.Hidden;
            removeFriend_ListBox.Visibility = Visibility.Hidden;
            AddFriend_ListBox.Visibility = Visibility.Hidden;
            AddFriend_ListBox.IsEnabled = false;
            removeFriend_ListBox.IsEnabled = false;
            InitializeComponent();
        }


        private void AddFriends_Click(object sender, RoutedEventArgs e)
        {
            AddFriends.Visibility = Visibility.Hidden;
            RemoveFriends.Visibility = Visibility.Hidden;
            textboxAddFriend.Visibility = Visibility.Visible;
            searchNewFriends.Visibility = Visibility.Visible;
            AddFriend_ListBox.Visibility = Visibility.Visible;
            AddFriend_ListBox.IsEnabled = true;
        }


        private void RemoveFriends_Click(object sender, RoutedEventArgs e)
        {
            AddFriends.Visibility = Visibility.Hidden;
            RemoveFriends.Visibility = Visibility.Hidden;
            textboxAddFriend.Visibility = Visibility.Hidden;
            searchNewFriends.Visibility = Visibility.Hidden;
            AddFriend_ListBox.Visibility = Visibility.Hidden;
            removeFriend_ListBox.Visibility = Visibility.Visible;
            removeFriend_ListBox.IsEnabled = true;
        }


        private void search_Button_Click(object sender, RoutedEventArgs e)
        {
            string searching = searchNewFriends.Text;
            if (searchNewFriends.Text != "")
            {
                if (searchNewFriends.Text == user.UserName) 
                {
                    foreach (var apllication in user.UserName)
                    {
                        AddFriend_ListBox.Items.Add(searching);
                        if (AddFriend_ListBox.SelectedItem != null)
                        {
                            string message = "Do you want to add this user to your friendlist?";
                            string title = "Add friend";
                            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.Yes)
                            {
                                user.AddFriend(user);
                                MessageBox.Show("User have been added as your friend");
                            }
                        }
                    }
                }
            }
            else 
            {
                MessageBox.Show("User not found, please try again!");
            }
        }


        private void removeFriend_ListBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (removeFriend_ListBox.Visibility != Visibility.Hidden)
            {
                while (removeFriend_ListBox.IsEnabled == true)
                {
                    foreach (var friend in manager.currentUser.friendsList)
                    {
                        removeFriend_ListBox.Items.Add(friend);
                        Console.WriteLine(manager.currentUser.friendsList);
                    }
                    if (removeFriend_ListBox.SelectedItem != null)
                    {
                        string message = "Are you sure you want to remove this friend?";
                        string title = "Remove friend";
                        var result = MessageBox.Show(message, title, MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            user.RemoveFriend(user);
                            MessageBox.Show("User have been removed as your friend");
                        }
                    }
                }
            }
        }


        private void AddFriend_ListBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (AddFriend_ListBox.Visibility == Visibility.Visible)
            {
                AddFriend_ListBox.Items.Clear();
                while (AddFriend_ListBox.IsEnabled == true)
                {
                    if (searchNewFriends.Text != null)
                    {
                        if (searchNewFriends.Text == user.UserName)
                        {
                            AddFriend_ListBox.Items.Add(user.UserName);
                        }
                    }
                }
            }
        }
    }
}
