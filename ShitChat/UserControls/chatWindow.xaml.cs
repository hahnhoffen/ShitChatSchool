using Newtonsoft.Json.Bson;
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

namespace ShitChat.UserControls
{
    /// <summary>
    /// Interaction logic for chatWindow.xaml
    /// </summary>
    public partial class chatWindow : UserControl
    {
        MessageManager messageManager;
        User reciever;

        public chatWindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Hidden;
        }

        public void SetManager(MessageManager messageManager1)
        {
            this.messageManager = messageManager1;
        }
        
        public void UpdateWindowInformation()
        {
            userNameLabel.Content = messageManager.currentUser.UserName;
            foreach (User user in messageManager.currentUser.friendsList)
            {
                FriendsListBox.Items.Add(user.Username);
            }
        }

        private void Sendbtn_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            foreach (User user in messageManager.currentUser.friendsList)
            {
                if (user.Username == MessagesListView.SelectedItem.ToString())
                {
                    reciever = user;
                }
                else
                {
                    continue;
                }
            }
            messageManager.CreateNewMessage(message, messageManager.currentUser, reciever);
        }


        public void ShowChatWindow()
        {
            this.Visibility = Visibility.Visible;
        }


        public void HideChatWindow()
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}