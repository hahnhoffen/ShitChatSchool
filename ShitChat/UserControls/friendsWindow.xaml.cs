using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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
        //UserManager manager; //= new UserManager();
        User user;
        RegisterWindow register = new RegisterWindow();
        MessageManager friendsManager;
        private User loggedInUser;

        public friendsWindow()
        {
            InitializeComponent();
        }

        public void SetManager(MessageManager manager)
        {
            this.friendsManager = manager;
        }

        //private bool IsUser (string username)
        //{
        //    loggedInUser = register.userList.FirstOrDefault(user => user.UserName == username);
        //    return loggedInUser != null;
        //}

        private bool IsAdmin()
        {
            //return loggedInUser != null && loggedInUser.UserName == "admin";
            return friendsManager.currentUser.UserName == "admin";
        }

        public void ShowFriendsWindow()
        {
            this.Visibility = Visibility.Visible;
            ShowFriendsList();
        }

        public void HideFriendsWindow()
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void ShowFriendsList()
        {
            removeFriend_ListBox.Items.Clear();
            if (IsAdmin())
            {

                foreach (User user in register.userList)
                {
                    if (user.UserName != "admin")
                    {
                        removeFriend_ListBox.Items.Add(user.UserName);
                    }
                }
            }
            else
            {
                if (friendsManager.currentUser.friendsList != null && friendsManager.currentUser.friendsList.Count > 0)
                {
                    foreach (User friend in friendsManager.currentUser.friendsList)
                    {
                        if (friend.UserName != friendsManager.currentUser.UserName)
                        {
                            removeFriend_ListBox.Items.Add($"{friend.UserName}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sadly you have no friends :(");
                }
            }
        }

        private void UpdateRemoveFriendsButtonState()
        {
            RemoveFriends.IsEnabled = true;
        }

        private void removeFriend_ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateRemoveFriendsButtonState();
        }

        //private void RemoveFriends_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (IsAdmin())
        //    {
        //        HandleAdminRemove();
        //    }
        //    else
        //    {
        //        HandleUserRemove();
        //    }
        //}

        private void HandleAdminRemove()
        {
            if (removeFriend_ListBox.SelectedItem != null)
            {
                string message = "Are you sure you want to remove this user?";
                string title = "Remove User";
                var option = MessageBox.Show(message, title, MessageBoxButton.YesNo);

                if (option == MessageBoxResult.Yes)
                {
                    removeFriend_ListBox.Items.Remove(removeFriend_ListBox.SelectedItem);
                    MessageBox.Show("User has been removed!");
                }
            }
        }

        private void HandleUserRemove()
        {
            if (removeFriend_ListBox.SelectedItem != null)
            {
                string message = "Are you sure you want to remove this friend?";
                string title = "Remove Friend";
                var result = MessageBox.Show(message, title, MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    removeFriend_ListBox.Items.Remove(removeFriend_ListBox.SelectedItem);
                    MessageBox.Show("Friend has been removed as your friend");
                }
                else if (removeFriend_ListBox == null)
                {
                    MessageBox.Show("Sadly, you have no friends..");
                }
            }
        }

        private void RemoveFriends_Click(object sender, RoutedEventArgs e)
        {
            if (IsAdmin())
            {
                HandleAdminRemove();
            }
            else
            {
                HandleUserRemove();
            }
        }
    }
}
