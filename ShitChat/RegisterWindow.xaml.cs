using Newtonsoft.Json;
using ShitChat.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        public List<User> userList;
        public Login login;  


        public RegisterWindow()
        {
            InitializeComponent();
            newUser = new User("Username", "Password"); //Why do we create a person before we add the details? What happens if they don't register the form correctly?
            Deserialize("users.json");
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }


        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            newUser.UserName = UsernameTextBox.Text;
            newUser.FirstName = FirstnameTextBox.Text;
            newUser.LastName = LastnameTextBox.Text;
            newUser.Email = EmailTextBox.Text;
            newUser.Password = PasswordBox.Password;
            if (PasswordBox.Password != RePasswordBox.Password)
            {
                MessageBox.Show("Password doesn't match.");
                return;
            }
            if (UserAlreadyExist(newUser.UserName)) 
            {
                MessageBox.Show("Username already in use");
                return;
            }
            MessageBox.Show("User registered:\nUsername: " + newUser.UserName + "\nFirstname: " + newUser.FirstName + "\nLastname: " + newUser.LastName + "\nEmail: " + newUser.Email);
            userList.Add(newUser);
            ClearInputFields();
            login.Show();
            this.Hide();
        }


        private bool UserAlreadyExist(string username)
        {
            return userList?.Any(user => user?.UserName != null && user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)) ?? false;
        }


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


        public void Deserialize(string filePath)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText("users.json");
                userList = JsonConvert.DeserializeObject<List<User>>(json, settings);
            }
            else
            {
                userList = new List<User>
                {
                    new User("admin", "admin"),
                    new User("Tim", "admin"),
                    new User("Johan", "admin"),
                    new User("Raashid", "admin"),
                    new User("Victor", "admin"),
                };
            }
        }


        //  public List<User> ReadUsersFromJson(string filePath)
        //  {
        //      try
        //      {
        //          if (File.Exists(filePath))
        //          {
        //              string json = File.ReadAllText(filePath);
        //              return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        //          }
        //          else
        //          {
        //              userList = new List<User>
        //              {
        //                  new User("admin", "admin"),
        //                  new User("Tim", "admin"),
        //                  new User("Johan", "admin"),
        //                  new User("Raashid", "admin"),
        //                  new User("Victor", "admin"),
        //              };
        //          }
        //      }
        //      catch (Exception ex)
        //      {
        //          MessageBox.Show("Error reading users from JSON file: " + ex.Message);
        //      }
        //      return userList;
        //  }
    }
}

