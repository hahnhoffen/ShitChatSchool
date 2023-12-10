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
    public partial class dropDownMenu : UserControl
    {

        Profile profile;
        chatWindow chatWindow;
        FrontWindow frontWindow;
        MainWindow mainWindow;
        UserManager userManager;
        profilePage ProfilePage;


        public dropDownMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userManager.SaveUserListToJson();
            Login login = new Login();
            mainWindow.Visibility = Visibility.Collapsed;
        }
        

        private void Profile_btn_Click(object sender, RoutedEventArgs e)
        {
            chatWindow.HideChatWindow();
            frontWindow.HideFront();
            ProfilePage.Visibility = Visibility.Hidden;

            if (profile.Visibility != Visibility.Visible)
            {
                profile.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;
            frontWindow.HideFront();
            ProfilePage.Visibility= Visibility.Hidden;

            if (chatWindow.Visibility != Visibility.Visible)
            {
                chatWindow.UpdateWindowInformation();
                chatWindow.ShowChatWindow();
            }
        }

        //sätter värdena på Rutorna/UserControlsen.
        public void SetWindows(Profile profile, chatWindow ChatWindow, FrontWindow frontWindow, MainWindow mainWindow, UserManager userManager, profilePage profilePage)
        {
            this.profile = profile;
            this.chatWindow = ChatWindow;
            this.frontWindow = frontWindow;
            this.mainWindow = mainWindow;
            this.userManager = userManager;
            this.ProfilePage = profilePage;
        }
    }
}

