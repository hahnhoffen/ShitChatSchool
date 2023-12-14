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
            FriendsListBox.Items.Clear();
            foreach (User user in messageManager.currentUser.friendsList)
            {
                FriendsListBox.Items.Add(user.UserName);
            }
        }

        private void FriendsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FriendsListBox.SelectedItem != null)
            {
                User selectedFriend = messageManager.currentUser.friendsList.FirstOrDefault(user => user.UserName == FriendsListBox.SelectedItem.ToString());
                friendNameLabel.Content = selectedFriend.UserName;
                UpdateChatDisplay(selectedFriend);
            }
        }

        private void Sendbtn_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;

            if (FriendsListBox.SelectedItem != null)
            {
                string selectedFriend = FriendsListBox.SelectedItem.ToString();
                reciever = messageManager.currentUser.friendsList.FirstOrDefault(user => user.UserName == selectedFriend);

                if (reciever != null)
                {
                    SendMessage(message);
                }
            }
        }

        private void SendMessage(string message)
        {
            messageManager.CreateNewMessage(message, messageManager.currentUser, reciever);
            UpdateChatDisplay(reciever); 
            MessageTextBox.Text = string.Empty;
        }

        private void UpdateChatDisplay(User selectedFriend)
        {
            MessagesListView.Items.Clear();

           
            Conversation conversation = messageManager.currentUser.conversations.FirstOrDefault(c => c.Friend == selectedFriend);

            if (conversation != null)
            {
                foreach (Message message in conversation.messages)
                {
                    MessagesListView.Items.Add($"{message.Writer.UserName}: {message.MessageString}");
                }
            }
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