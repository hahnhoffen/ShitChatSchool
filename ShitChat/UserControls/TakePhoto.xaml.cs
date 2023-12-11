using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    /// Interaction logic for TakePhoto.xaml
    /// </summary>
    public partial class TakePhoto : UserControl
    {

        bool streamVideo = false;
        static int camera = 0;
        VideoCapture capture = new VideoCapture(camera);

        public TakePhoto()
        {
            InitializeComponent();
        }

        private async void StreamVideo()
        {
            while (streamVideo)
            {
                var frameSize = new System.Drawing.Size(345, 225);

                //tar en frame från kameran, här är bilden en array av RGB(pixlar)
                Mat frame = new Mat();
                capture.Read(frame);

                CvInvoke.Resize(frame, frame, frameSize);

                //Gör bilden till bitmap, alltså en frame som uppdateras. Gör om Arrayen till faktiska färger.
                var img = frame.ToBitmap();

                //konverterar bitmap till image, eftersom imagebox tar sourcecode???
                BitmapImage bitmapImage = Convert(img);

                //Sätter imagebox till bitmap
                Cam_box.Source = bitmapImage;

                await Task.Delay(16);

            }
        }

        //Konverterar till bitmap
        private BitmapImage Convert(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(ms.ToArray());
            bitmapImage.EndInit();

            return bitmapImage;
        }

        private void OpenCam_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Okay to use Camera?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (camera == 0)
                {
                    StreamVideo();
                }
                else
                {
                    MessageBox.Show("Could't find Camera");
                    streamVideo = false;
                }
            }
        }

        private void ChoosePhoto_Btn_Click(object sender, RoutedEventArgs e)
        {
            
            this.PhotoHide();
        }

        private void TakePhoto_btn_Click(object sender, RoutedEventArgs e)
        {
            //Tar en frame från kameran och får en Mat objekt
            Mat frame = capture.QueryFrame();

            //Konverterar Mat objektet till Bitmap
            Bitmap bitmap = frame.ToBitmap();

            //själva bilden i bitmapimage format
            BitmapImage bitmapImage1 = Convert(bitmap);

            //Ger imageBoxen värdet av bitmapimage
            Photo_Box.Source = bitmapImage1;
        }

        public void PhotoHide()
        {
            this.Visibility = Visibility.Hidden;
        }
        public void PhotoShow()
        {
            this.Visibility = Visibility.Visible;
        }
    }
}
