using ShitChat.UserControls;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>

    public partial class RegisterWindow : Window
    {
        private Person newUser;
        public List<User> userList = new List<User>();
        public Login login;
      
        public RegisterWindow()
        {
            InitializeComponent();
            newUser = new Person(); //Why do we create a person before we add the details? What happens if they don't register the form correctly? 
        }
     

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            newUser.Username = UsernameTextBox.Text;
            newUser.FirstName = FirstnameTextBox.Text;
            newUser.LastName = LastnameTextBox.Text;
            newUser.Email = EmailTextBox.Text;
            newUser.Password = PasswordBox.Password;
            newUser.Country = CountryTextBox.Text;
            newUser.City = CityTextBox.Text;
            newUser.PhoneNumber = PhoneTextBox.Text;

            if (PasswordBox.Password != RePasswordBox.Password)
            {
                MessageBox.Show("Password doesn't match.");
                return;
            }
            MessageBox.Show("User registered:\nUsername: " + newUser.Username + "\nFirstname: " + newUser.FirstName + "\nLastname: " + newUser.LastName + "\nEmail: " + newUser.Email + "\nCountry: " + newUser.Country + "\nCity: " + newUser.City + "\nPhone: " + newUser.PhoneNumber);
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            UsernameTextBox.Text = "";
            FirstnameTextBox.Text = "";
            LastnameTextBox.Text = "";
            EmailTextBox.Text = "";
            PasswordBox.Password = "";
            RePasswordBox.Password = "";
            CountryTextBox.Text = "";
            CityTextBox.Text = "";
            PhoneTextBox.Text = "";
        }

        private void GoBack_button(object sender, RoutedEventArgs e)
        {
            login.Show();
            this.Hide();
        }

        //Sätter värdet på Login så det inte öppnet ett nytt varje gång.
        public void SetLogin(Login login)
        {
            this.login = login;
        }
    }
}
