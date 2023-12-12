using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        RegisterWindow registerWindow;
        User currentUser;

        public MainWindow()
        {
            InitializeComponent();
            DropDownMenu.SetWindows(Profile, ChatWindow, Front, this, userManager, profilePage);
        }


        //Closes application if we exit main window
        protected override void OnClosed(EventArgs e)
        {
            userManager.SaveUserListToJson();
            base.OnClosed(e);
            Application.Current.Shutdown();
        }


        public void SetRegisterWindow(RegisterWindow registerWindow)
        {
            this.registerWindow = registerWindow;
        }


        public void SetUserName(User user)
        {
            this.currentUser = user;
            MenuBar.SetUserName(user.UserName.ToString());
            MenuBar.SetProfilePage(profilePage, userManager);
            messageManager.SetUser(user);
            userManager.SetClasses(user, registerWindow);
            profilePage.SetManagers(registerWindow, userManager, this);
            ChatWindow.SetManager(messageManager);
        }


        public void ShowProfile()
        {
            Profile.ShowProfile();
        }
    }
}
