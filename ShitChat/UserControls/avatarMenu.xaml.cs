using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for avatarMenu.xaml
    /// </summary>
    public partial class avatarMenu : UserControl
    {
        UserManager userManager;
        profilePage profilePage;
        string picked = "0";

        public avatarMenu()
        {
            InitializeComponent();
        }


        public void SetManagers(UserManager userManager, profilePage ProfilePage)
        {
            this.userManager = userManager;
            this.profilePage = ProfilePage;
        }

        private void pickButton_Click(object sender, RoutedEventArgs e)
        {
            avatarMenuClass.Visibility = Visibility.Collapsed;
            Pick();
        }


        public void Pick()
        {
            switch (picked)
            {
                case "0":
                    break;
                case "1":
                    border1.Opacity = 0.4;
                    userManager.currentUser.AvatarImage = @"/UserControls/avatar1.png";
                    BitmapImage b1 = new BitmapImage();
                    b1.BeginInit();
                    b1.UriSource = new Uri(userManager.currentUser.AvatarImage, UriKind.RelativeOrAbsolute);
                    b1.EndInit();
                    profilePage.avatarPicture.Source = b1;
                    break;
                case "2":
                    border1.Opacity = 0.4;
                    userManager.currentUser.AvatarImage = @"/UserControls/avatar2.png";
                    BitmapImage b2 = new BitmapImage();
                    b2.BeginInit();
                    b2.UriSource = new Uri(userManager.currentUser.AvatarImage, UriKind.RelativeOrAbsolute);
                    b2.EndInit();
                    profilePage.avatarPicture.Source = b2;
                    break;
                case "3":
                    border1.Opacity = 0.4;
                    userManager.currentUser.AvatarImage = "/UserControls/avatar3.png";
                    BitmapImage b3 = new BitmapImage();
                    b3.BeginInit();
                    b3.UriSource = new Uri(userManager.currentUser.AvatarImage, UriKind.RelativeOrAbsolute);
                    b3.EndInit();
                    profilePage.avatarPicture.Source = b3;
                    break;
                case "4":
                    border1.Opacity = 0.4;
                    userManager.currentUser.AvatarImage = "/UserControls/avatar4.png";
                    BitmapImage b4 = new BitmapImage();
                    b4.BeginInit();
                    b4.UriSource = new Uri(userManager.currentUser.AvatarImage, UriKind.RelativeOrAbsolute);
                    b4.EndInit();
                    profilePage.avatarPicture.Source = b4;
                    break;
                case "5":
                    border1.Opacity = 0.4;
                    userManager.currentUser.AvatarImage = "/UserControls/avatar5.png";
                    BitmapImage b5 = new BitmapImage();
                    b5.BeginInit();
                    b5.UriSource = new Uri(userManager.currentUser.AvatarImage, UriKind.RelativeOrAbsolute);
                    b5.EndInit();
                    profilePage.avatarPicture.Source = b5;
                    break;
                case "6":
                    border1.Opacity = 0.4;
                    userManager.currentUser.AvatarImage = "/UserControls/avatar6.png";
                    BitmapImage b6 = new BitmapImage();
                    b6.BeginInit();
                    b6.UriSource = new Uri(userManager.currentUser.AvatarImage, UriKind.RelativeOrAbsolute);
                    b6.EndInit();
                    profilePage.avatarPicture.Source = b6;
                    break;
            }
        }


        public void ButtonCheck(Border border)
        {
            if (border.Opacity == 0.4)
            {
                border.Opacity = 0.8;
                int len = border.Name.Length;
                picked = border.Name[len - 1].ToString();
            }
            else
            {
                border.Opacity = 0.4;
                picked = "0";
            }
        }


        private void profileBtn1_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(border1);
        }


        private void profileBtn2_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(border2);
        }

        private void profileBtn3_Click(object sender, RoutedEventArgs e)
        { 
            ButtonCheck(border3);
        }

        private void profileBtn4_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(border4);
        }

        private void profileBtn5_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(border5);
        }

        private void profileBtn6_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(border6);
        }
    }
}
