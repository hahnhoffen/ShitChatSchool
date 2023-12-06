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
    /// Interaction logic for Profilexaml.xaml
    /// </summary>
    public partial class Profilexaml : UserControl
    {
        public Login login;
        string CurrentUser = null;
        public RegisterWindow registerWindow;

        public Profilexaml()
        {
            InitializeComponent();
        }

        //sätter värdet till den inloggades användarnamn
        private void Profile_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentUser = login.GetLogedInUser();
            UsrName_Label.Content = CurrentUser;
        }

        //tar värdet från login och tilldelar denna usercontrolen
        public void SetLogin(Login login)
        {
            this.login = login;
        }

        //stämmer inte passwordboxarna eller är dem null så visas label, annars ändras lösenordet.
        //Är inte adresstextBoxen "" så ändras adressen till det angivna.
        private void Apply_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Chge_Psw_Box.Text != "" &&
                Cofrm_Psw_Box.Text != "" &&
                Chg_Adr_Box.Text != "")
            {
                ChangePassWord();
                Pwrd_Error_Label.Visibility = Visibility.Collapsed;
            }
            else
            {
                Pwrd_Error_Label.Visibility = Visibility.Visible;
                Pwrd_Error_Label.Content = "You need to fill both password fields!";
            }

            if (Chg_Adr_Box.Text != "")
            {
                Change_Address();
                Adrs_Error_Label.Visibility = Visibility.Collapsed;
            }
            else
            {
                Adrs_Error_Label.Visibility = Visibility.Visible;
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
                if (user.UserName.Equals(CurrentUser))
                {
                    Chg_Adr_Box.Text = user.Address;
                    break;
                }
            }
        }
    }
}
