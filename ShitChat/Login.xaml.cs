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
using System.Windows.Shapes;

namespace ShitChat
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>


    public partial class Login : Window
    {
        RegisterWindow RegisterWindow = new RegisterWindow();
        MainWindow mainWindow;

        bool isFound = false;
        string user = null;
        string password = null;
        static User logedInUser = null;

        public Login()
        {
            InitializeComponent();
            this.Show();
        }
        //Tar användaren till registeringen, gömmer Påminnelse label.
        private void ToRegisterWindow(object sender, RoutedEventArgs e)
        {
            RegisterWindow.Show();
            this.Hide();
            Register_Btn.Visibility = Visibility.Collapsed;
        }

        //Loggar in en användare om den finns i Userlist, om inte hänvisas man till registerWindow.
        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            user = UserName_block.Text;
            password = Password_block.Text;

            if (user != "" && password != "")
            {
                foreach(User users in RegisterWindow.userList)
                {
                    if (user == users.Username &&
                        password == users.Password)
                    {
                        isFound = true;
                        logedInUser = users;

                        mainWindow.Show();
                        this.Hide();

                        Register_label.Visibility = Visibility.Collapsed;
                        break;
                    }
                    if (!isFound)
                    { 
                        Register_label.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to write Username & Password");
            }
        }

        //Retunerar Den inlogade Usern till resten av programmet.
        public static User GetLogedInUser()
        {
            return logedInUser;
        }

        //stänger ner applikationen.
        private void Quit_app(object sender, RoutedEventArgs e)
        {
            Application application = Application.Current;
            application.Shutdown();
        }
    }
}
