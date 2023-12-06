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
        
        public chatWindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Hidden;
        }

        private void Sendbtn_Click(object sender, RoutedEventArgs e)
        {

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
