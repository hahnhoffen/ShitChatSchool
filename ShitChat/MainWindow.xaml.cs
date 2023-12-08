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
using ShitChat.UserControls;

namespace ShitChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MessageManager messageManager = new MessageManager();
        UserManager userManager = new UserManager();
        User currentUser;

        public MainWindow()
        {
            
            InitializeComponent();
            DropDownMenu.SetWindows(Profile, ChatWindow, Front, this);

        }

        public void SetUserName(User user)
        {
            currentUser = user;
            MenuBar.SetUserName(user.UserName.ToString());
            Profile.SetLabelToUser(user.UserName.ToString());
            messageManager.SetUser(user);
            userManager.SetUser(user);
            ChatWindow.SetManager(messageManager);
        }


        public void ShowProfile()
        {
            Profile.ShowProfile();
        }
    }
}
