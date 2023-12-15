using Emgu.CV.Features2D;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using static System.Net.Mime.MediaTypeNames;

namespace ShitChat.UserControls
{
    /// <summary>
    /// Interaction logic for profilePage.xaml
    /// </summary>
    public partial class profilePage : UserControl
    {
        RegisterWindow registerWindow;
        UserManager userManager;
        MainWindow mainWindow;
        menuBar MenuBar;
        User searchedUser;


        public profilePage()
        {
            InitializeComponent();
        }


        public void SetManagers(RegisterWindow registerWindow, UserManager userManager, MainWindow mainWindow)
        {
            this.registerWindow = registerWindow;
            this.userManager = userManager;
            this.mainWindow = mainWindow;
        }


        public void SearchUser(string userName)
        {
            foreach (User user in registerWindow.userList)
            {
                if (userName == user.UserName)
                {
                    searchedUser = user;
                    DisplayProfile(user);
                }
            }
        }


        public void DisplayProfile(User searchedUser)
        {
            bool myProfile = true;
            if (searchedUser.UserName == userManager.currentUser.UserName)
            {
                ButtonVisibility(myProfile);
            }
            else
            {
                ButtonVisibility(!myProfile);
                foreach (User user in userManager.currentUser.friendsList)
                {
                    if (user.UserName == searchedUser.UserName)
                    {
                        addFriendBtn.Content = "- Remove Friend";
                    }
                }
            }
            userNameLabel.Content = searchedUser.UserName;
            userCountryLabel.Content = "Country: " + searchedUser.Country.ToString();
            userCityLabel.Content = "City: " + searchedUser.City.ToString();
            if (searchedUser.Presentation != null)
            {
                presentationLabel.Content = searchedUser.Presentation.ToString();
            }
            if (searchedUser.AvatarImage != null)
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(searchedUser.AvatarImage, UriKind.RelativeOrAbsolute);
                b.EndInit();
                avatarPicture.Source = b;
            }
            else
            {
                string presetAvatarImage = @"/UserControls/avatar1.png";   //Updating the pathway for the specific account's avatar image
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(presetAvatarImage, UriKind.RelativeOrAbsolute);
                b.EndInit();
                avatarPicture.Source = b;
            }
        }


        public void ButtonVisibility(bool myProfile)
        {
            if (myProfile)
            {
                addFriendBtn.Visibility = Visibility.Hidden;
                sendMessageBtn.Visibility = Visibility.Hidden;
                changeAvatarBtn.Visibility = Visibility.Visible;
                takePhotoBtn.Visibility = Visibility.Visible;
            }
            else
            {
                changeAvatarBtn.Visibility = Visibility.Hidden;
                takePhotoBtn.Visibility = Visibility.Hidden;
                addFriendBtn.Visibility = Visibility.Visible;
                sendMessageBtn.Visibility = Visibility.Visible;
            }
        }

        private void addFriendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (searchedUser != null) 
            {
                foreach (User user in userManager.currentUser.friendsList)
                {
                    if (searchedUser.UserName == user.UserName)
                    {
                        userManager.currentUser.RemoveFriend(searchedUser);
                        addFriendBtn.Content = "+ Add Friend";
                        MessageBox.Show("You've removed this user from your friends list!");
                        return;
                    }
                }
                userManager.currentUser.AddFriend(searchedUser);
                addFriendBtn.Content = "- Remove Friend";
                MessageBox.Show("You added a friend!");
            }
        }


        private void changeAvatarBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.avatarPage.SetManagers(userManager, this);
            mainWindow.avatarPage.Visibility = Visibility.Visible;
        }


        private void takePhoto_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowPhotoWindow();
        }


        //Ger bildens värde till avatarPicture.
        public void SetProfileImage(BitmapImage profileImage)
        {
            avatarPicture.Source = profileImage;
        }
    }
}
