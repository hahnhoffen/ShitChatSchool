﻿using System;
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
        User CurrentUser = null;
        RegisterWindow registerWindow;
        dropDownMenu DropDownMenu;
        Profile profile;
        chatWindow chatWindow;

        public Profile()
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


        //hämtar värdena av chatWindow 
        public void SetChatWindow(chatWindow ChatWindow)
        {
            this.chatWindow = ChatWindow;
        }
        public void SetLabelToUser(string CurrentUser)
        { 
            UsrName_Label.Content = CurrentUser.ToString();
        }
        //sätter värdet till den inloggades användarnamn

        //tar värdet från login och tilldelar denna usercontrolen
        public void SetLogin(Login login1)
        {
            this.login = login1;
        }
        //sätter värdet i registerWindow
        public void SetRegisterWindow(RegisterWindow registerWindow)
        {
            this.registerWindow = registerWindow;
        }



        //stämmer inte passwordboxarna eller är dem null så visas label, annars ändras lösenordet.
        //Är inte adresstextBoxen "" så ändras adressen till det angivna.
        private void Apply_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Chge_Psw_Box.Text != "" &&
                Cofrm_Psw_Box.Text != "")
            {
                ChangePassWord();
                Error_Psw_label.Visibility = Visibility.Hidden;
            }
            else
            {
                Error_Psw_label.Visibility = Visibility.Visible;
            }

            if (Chg_Adr_Box.Text != "")
            {
                Change_Address();
            }
            else
            {
                Error_Adr_Label.Visibility = Visibility.Visible;
            }
        }
        //byter till aktuellt lösenord
        private void ChangePassWord()
        {
            foreach (User user in registerWindow.userList)
            {
                if (user.UserName.Equals(CurrentUser) &&
                    Chge_Psw_Box.Text == Cofrm_Psw_Box.Text)
                {
                    Chge_Psw_Box.Text = user.Password;
                    break;
                }
            }
        }
        //Byter Adress.
        private void Change_Address()
        {
            foreach(User user in registerWindow.userList)
            {
                if (user.Address != Chg_Adr_Box.Text)
                {
                    Chg_Adr_Box.Text = user.Address;
                    Error_Adr_Label.Visibility = Visibility.Hidden;
                    break;
                }
            }
        }

        public void ShowProfile()
        {
            this.Visibility = Visibility.Visible;
        }

        public void HideProfile()
        {
            this.Visibility = Visibility.Collapsed;
        }
       
    }
}
