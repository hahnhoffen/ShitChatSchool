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

        public dropDownMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application application = Application.Current;
            application.Shutdown();
        }


        private void Profile_btn_Click(object sender, RoutedEventArgs e)
        {
            chatWindow.HideChatWindow();

            if (profile.Visibility != Visibility.Visible)
            {
                profile.Visibility = Visibility.Visible;
            }
            else
            {
                profile.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;
            if (chatWindow.Visibility != Visibility.Visible)
            {
                chatWindow.ShowChatWindow();
            }
            else
            {
                chatWindow.HideChatWindow();
            }
        }


        //hämtar värdena av profile 
        public void SetProfile(Profile profile)
        {
            this.profile = profile;
        }

        //hämtar värdena av chatWindow 
        public void SetChatWindow(chatWindow ChatWindow)
        {
            this.chatWindow = ChatWindow;
        }
    }
}
