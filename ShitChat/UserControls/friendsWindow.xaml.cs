using Newtonsoft.Json;
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
        private void AddFriends_Click(object sender, RoutedEventArgs e)
        {
            textHelper.Visibility = Visibility.Visible;
            searchNewFriends.Visibility = Visibility.Visible;
            search_Button.Visibility = Visibility.Visible;
            AddFriend_ListBox.Visibility = Visibility.Visible;
        }
        private void RemoveFriends_Click(object sender, RoutedEventArgs e)
        {
            if (removeFriend_ListBox.Visibility != Visibility.Visible)
            {
                removeFriend_ListBox.Visibility = Visibility.Visible;
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
                    //else if (removeFriend_ListBox == null)
                    //{
                    //    MessageBox.Show("Sadly you have no friends..");
                    //}
                    //else if (removeFriend_ListBox.Visibility == Visibility.Hidden)
                    //{
                    //    return;
                    //}
                }
            }
        }
        private void search_Button_Click(object sender, RoutedEventArgs e)
        {
            string searching = searchNewFriends.Text.Trim();
            if (!string.IsNullOrEmpty(searching))
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
            }
        }
        public void ShowFriendsWindow()
        {
            this.Visibility = Visibility.Visible;
        }
        public void HideFriendsWindow()
        {
            this.Visibility = Visibility.Collapsed;
        }
        /*private void removeFriend_ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (removeFriend_ListBox.Visibility != Visibility.Visible)
            {
                removeFriend_ListBox.Visibility = Visibility.Visible;
                if (manager.currentUser.friendsList.Contains(user))
                {
                    foreach (User friend in manager.currentUser.friendsList)
                    {
                        removeFriend_ListBox.Items.Add(friend);
                        //Console.WriteLine(manager.currentUser.friendsList);
                    }
                }
                else
                {
                    MessageBox.Show("Sadly you have no friends..");
                }
            }
        }*/
    }
}
