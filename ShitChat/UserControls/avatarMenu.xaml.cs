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
    /// Interaction logic for avatarMenu.xaml
    /// </summary>
    public partial class avatarMenu : UserControl
    {

        string picked = "0";

        public avatarMenu()
        {
            InitializeComponent();
        }


        private void pickButton_Click(object sender, RoutedEventArgs e)
        {
            avatarMenuClass.Visibility = Visibility.Collapsed;
            Pick();
        }


        public void Pick()
        {
            switch (picked)
            {
                case "0":
                    break;
                case "1":
                    border1.Opacity = 0.4;
                    break;
                case "2":
                    border2.Opacity = 0.4;
                    break;
                case "3":
                    border3.Opacity = 0.4;
                    break;
                case "4":
                    border4.Opacity = 0.4;
                    break;
                case "5":
                    border5.Opacity = 0.4;
                    break;
                case "6":
                    border6.Opacity = 0.4;
                    break;
            }
        }


        public void ButtonCheck(Border border)
        {
            if (border.Opacity == 0.4)
            {
                border.Opacity = 0.8;
                int len = border.Name.Length;
                picked = border.Name[len - 1].ToString();
            }
            else
            {
                border.Opacity = 0.4;
                picked = "0";
            }
        }


        private void profileBtn1_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(border1);
        }


        private void profileBtn2_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(border2);
        }

        private void profileBtn3_Click(object sender, RoutedEventArgs e)
        { 
            ButtonCheck(border3);
        }

        private void profileBtn4_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(border4);
        }

        private void profileBtn5_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(border5);
        }

        private void profileBtn6_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(border6);
        }
    }
}
