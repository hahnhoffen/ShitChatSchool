using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        public List<User> Users { get; private set; }
        UserManager manager = new UserManager();
        User user = new User();
        RegisterWindow register = new RegisterWindow();
        private User loggedInUser;
        public friendsWindow()
        {
            InitializeComponent();
            LoadUserData();
            DataContext = this;
        }
        private void LoadUserData()
        {
            string jsonF = manager.usersPath;
            try
            {
                string jsonContent = File.ReadAllText(jsonF);
                Users = JsonConvert.DeserializeObject<List<User>>(jsonContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private bool IsUser (string username)
        {
            loggedInUser = register.userList.FirstOrDefault(user => user.UserName == username);
            return loggedInUser != null;
        }
        private bool IsAdmin()
        {
            return loggedInUser != null && loggedInUser.UserName == "admin";
        }
        private void AddFriends_Click(object sender, RoutedEventArgs e)
        {
            textHelper.Visibility = Visibility.Visible;
            searchNewFriends.Visibility = Visibility.Visible;
            search_Button.Visibility = Visibility.Visible;
            AddFriend_ListBox.Visibility = Visibility.Visible;
        }
        private void RemoveFriends_Click(object sender, RoutedEventArgs e)
        {
            removeFriend_ListBox.Visibility = Visibility.Visible;
            if (IsAdmin())
            {
                removeFriend_ListBox.Items.Add(register.userList);
            }
            else
            {
                removeFriend_ListBox.Items.Add(user.friendsList);
            }
        }
        private void search_Button_Click(object sender, RoutedEventArgs e)
        {
            string searching = searchNewFriends.Text.Trim();
            /*if (!string.IsNullOrEmpty(searching))
            {
                User foundUser = Users.FirstOrDefault(user => user.UserName == searching);
                if (foundUser != null)
                {
                    AddFriend_ListBox.Items.Add(foundUser.UserName);
                    string message = $"Do you want to add {foundUser.UserName} to your friendlist?";
                    string title = "Add friend";
                    var result = MessageBox.Show(message, title, MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        user.AddFriend(user);
                        MessageBox.Show($"{foundUser.UserName} have been added as your friend");
                        AddFriend_ListBox.Items.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("User not Found, please try again!");
                }
            }*/
        }
        public void ShowFriendsWindow()
        {
            this.Visibility = Visibility.Visible;
        }
        public void HideFriendsWindow()
        {
            this.Visibility = Visibility.Collapsed;
        }
        private void removeFriend_ListBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (removeFriend_ListBox.Visibility != Visibility.Visible)
            {
                removeFriend_ListBox.Visibility = Visibility.Visible;
                if (IsAdmin())
                {
                    if (removeFriend_ListBox.SelectedItem != null)
                    {
                        string message = "Are you sure you want to remove this user?";
                        string title = "Remove User";
                        var option = MessageBox.Show(message, title, MessageBoxButton.YesNo);
                        if (option == MessageBoxResult.Yes)
                        {
                            manager.currentUser.RemoveFriend(user);
                            MessageBox.Show("User have been removed!");
                        }
                    }
                }
                else
                {
                    if (removeFriend_ListBox.SelectedItem != null)
                    {
                        string message = "Are you sure you want to remove this friend?";
                        string title = "Remove friend";
                        var result = MessageBox.Show(message, title, MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            manager.currentUser.RemoveFriend(user);
                            MessageBox.Show("User have been removed as your friend");
                        }
                        else if (removeFriend_ListBox == null)
                        {
                            MessageBox.Show("Sadly you have no friends..");
                        }
                        else if (removeFriend_ListBox.Visibility == Visibility.Hidden)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}
