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
            userCountryLabel.Content = "Country: " + user.Country.ToString();
            userCityLabel.Content = "City: " + user.City.ToString();
            if (user.Presentation != null)
            {
                presentationLabel.Content = user.Presentation.ToString();
            }
            if (user.AvatarImage != null)
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(user.AvatarImage, UriKind.RelativeOrAbsolute);
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


        private void addFriendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (searchedUser != null && searchedUser.UserName != userManager.currentUser.UserName) 
            {
                foreach (User user in userManager.currentUser.friendsList)
                {
                    if (searchedUser == user)
                    {
                        MessageBox.Show("You've already got this user in your friends list!");
                        return;
                    }
                }
                userManager.currentUser.AddFriend(searchedUser);
                MessageBox.Show("You added a friend!");
            }
            else
            {
                MessageBox.Show("You can't add youself.");
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
