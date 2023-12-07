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

namespace ShitChat.UserControls
{
    /// <summary>
    /// Interaction logic for FrontWindow.xaml
    /// </summary>
    public partial class FrontWindow : UserControl
    {
        public FrontWindow()
        {
            InitializeComponent();
        }

        public void ShowFront()
        {
            Front.Visibility = Visibility.Visible;
        }
        public void HideFront()
        {
            Front.Visibility = Visibility.Hidden;
        }

    }
}
