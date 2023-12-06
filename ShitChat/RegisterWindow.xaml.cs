using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        private User newUser;
        public List<User> userList = new List<User>();
        public Login login;
      
        public RegisterWindow()
        {
            InitializeComponent();
            newUser = new User("Username", "Password");
        }
       
     

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            newUser.UserName = UsernameTextBox.Text;
            newUser.FirstName = FirstnameTextBox.Text;
            newUser.LastName = LastnameTextBox.Text;
            newUser.Email = EmailTextBox.Text;
            newUser.Password = PasswordBox.Password;
            // kollar ifall de båda lösenorden stämmer med varandra
            if (PasswordBox.Password != RePasswordBox.Password)
            {
                MessageBox.Show("Password doesn't match.");
                return;
            }
            // kollar ifall namnet man väljer redan finns
            if (IsUsernameTaken(newUser.UserName))
            {
                MessageBox.Show("Username already taken.");
                return;
            }
            SaveUserToJson(newUser);
            ClearInputFields();
            login.Show();
            this.Hide();


        }
        private bool IsUsernameTaken(string username)
        {
            // kollar ifall namnet man väljer redan finns
            return userList.Any(user => user.UserName == username);
        }

        // Tömmer textboxnarna
        private void ClearInputFields()
        {
            UsernameTextBox.Text = "";
            FirstnameTextBox.Text = "";
            LastnameTextBox.Text = "";
            EmailTextBox.Text = "";
            PasswordBox.Password = "";
            RePasswordBox.Password = "";
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
        private void SaveUserToJson(User user)
        {
            try
            {
                string filePath = "userList.json";
                List<User> existingUsers = ReadUsersFromJson(filePath);
                existingUsers.Add(user);
                string json = JsonSerializer.Serialize(existingUsers, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private List<User> ReadUsersFromJson(string filePath)
        {
            List<User> existingUsers = new List<User>();

            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    existingUsers = JsonSerializer.Deserialize<List<User>>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading users from JSON file: " );
            }

            return existingUsers;
        }
    }
}
