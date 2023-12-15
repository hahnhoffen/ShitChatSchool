using Emgu.CV.Util;
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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        Login login;
        User currentUser;
        RegisterWindow registerWindow;
        dropDownMenu DropDownMenu;
        Profile profile;
        chatWindow chatWindow;
        TakePhoto takePhoto;
        UserManager userManager;

        public Profile()
        {
            InitializeComponent();
        }


        public void SetRegisterWindow(RegisterWindow registerWindow, UserManager userManager)
        {
            this.registerWindow = registerWindow;
            this.userManager = userManager;
        }
        public void SetTakePhoto(TakePhoto takePhoto)
        {
            this.takePhoto = takePhoto;
        }


        //hämtar värdena av chatWindow 
        public void SetChatWindow(chatWindow ChatWindow)
        {
            this.chatWindow = ChatWindow;
        }


        public void SetLogin(Login login1)
        {
            this.login = login1;
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


        private void Apply_btn_Click(object sender, RoutedEventArgs e)
        {
            currentUser = userManager.currentUser;
            if (Chge_Psw_Box.Password != "" &&
                Cofrm_Psw_Box.Password != "")
            {
                ChangePassWord();
            }
            Change_City(Chg_City_Box.Text);
            ChangeCountry();
            ChangePresentation();
            ClearFields();
          //Error_Psw_label.Visibility = Visibility.Hidden;
        }


        private void ChangePresentation()
        {
            if (presentationTextBox.Text != "")
            {
                currentUser.Presentation = presentationTextBox.Text;
            }
        }


        private void ChangeCountry()
        {
            if (Chge_Country_Box.Text != "")
            {
                currentUser.Country = Chge_Country_Box.Text;
            }
        }


        private void ChangePassWord()
        {
            if (Chge_Psw_Box.Password == Cofrm_Psw_Box.Password)
            {
                currentUser.Password = Chge_Psw_Box.Password;
            }
        }


        private void Change_City(string city)
        {
            if (Chg_City_Box.Text != "")
            {
                currentUser.City = city;
            }
            Error_Adr_Label.Visibility = Visibility.Hidden;
        }


        public void ClearFields()
        {
            Chg_City_Box.Text = "";
            Chge_Psw_Box.Password = "";
            Chge_Country_Box.Text = "";
            presentationTextBox.Text = "";
        }

        public void SetProfilePic(BitmapImage image)
        {
            ProfilePic_box.Source = image;
        }

        public void ShowProfile()
        {
            this.Visibility = Visibility.Visible;
        }


        public void HideProfile()
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Photo_btn_Click(object sender, RoutedEventArgs e)
        {
            
            takePhoto.PhotoShow();
            this.HideProfile();
        }
    }
}
