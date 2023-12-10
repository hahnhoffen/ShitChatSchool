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


        public void SetMenuBar(menuBar MenuBar)
        {
            this.MenuBar = MenuBar;
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
            userCityLabel.Content = "City: " + user.City.ToString();
            if (user.AvatarImage != null)
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(user.AvatarImage, UriKind.RelativeOrAbsolute);
                b.EndInit();
                avatarPicture.Source = b;
            }
        }


        private void addFriendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (searchedUser != null && searchedUser.UserName != userManager.currentUser.UserName) 
            {
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
            //userManager.currentUser.OpenFileDialog();
            mainWindow.avatarPage.SetManagers(userManager, this);
            mainWindow.avatarPage.Visibility = Visibility.Visible;
            //avatarPicture.Source = new BitmapImage(new Uri(userManager.currentUser.AvatarImage, UriKind.Relative));
            //profilePicture.Source = userManager.currentUser.AvatarImage.ToString();
        }
    }
}
