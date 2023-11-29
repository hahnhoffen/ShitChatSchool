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

        string user = null;
        string password = null;

        public Login()
        {
            InitializeComponent();
            this.Show();
        }

        private void ToRegisterWindow(object sender, RoutedEventArgs e)
        {
            RegisterWindow.Show();
            this.Hide();
        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            user = UserName_block.Text;
            password = Password_block.Text;

            if (user != "")
            {
                for (int i = 0; i < RegisterWindow.userList.Count; i++)
                {
                    if (user == RegisterWindow.userList[i].Username &&
                        password == RegisterWindow.userList[i].Password)
                    {
                        mainWindow.Show();
                        this.Hide();
                    }
                    else
                    {
                        ErrorLabel.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to write username and password");
            }
        }

        private void Quit_app(object sender, RoutedEventArgs e)
        {
            Application application = Application.Current;
            application.Shutdown();
        }
    }
}
