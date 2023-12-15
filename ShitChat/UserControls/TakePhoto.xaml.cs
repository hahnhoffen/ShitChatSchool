using Emgu.CV;
using Emgu.CV.Bioinspired;
using Emgu.CV.Util;
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
        profilePage profilePage;
        Profile profile;
        public bool takenPhoto = false;

        public TakePhoto()
        {
            InitializeComponent();
        }

        public void SetProfile(Profile profile)
        {
            this.profile = profile;
        }

        public void SetProfilePage(profilePage profilePage)
        {
            this.profilePage = profilePage;
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

             if (camera == 0)
             {
                 streamVideo = true;
                 StreamVideo();
             }
             else
             {
                 MessageBox.Show("Could't find Camera");
                 streamVideo = false;
             }
        }



        public void TakePhoto_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Tar en frame från kameran och får en Mat objekt
                Mat frame = capture.QueryFrame();

                //Konverterar Mat objektet till Bitmap
                Bitmap bitmap = frame.ToBitmap();

                //själva bilden i bitmapimage format
                BitmapImage bitmapImage1 = Convert(bitmap);
                profilePage.SetProfileImage(bitmapImage1);
                profile.SetProfilePic(bitmapImage1);

                //Ger imageBoxen värdet av bitmapimage
                Photo_Box.Source = bitmapImage1;

                //Sparar ner Bilden i en variabel för att återanvända.
                BitmapImage profilePic = bitmapImage1;

                System.Drawing.Imaging.ImageFormat imageFormat = null;
                imageFormat = System.Drawing.Imaging.ImageFormat.Png;

                takenPhoto = true;
                    
            }
            catch
            {
                MessageBox.Show("Camera is already in use");
            }
        }


        public void PhotoHide()
        {
            this.Visibility = Visibility.Hidden;
        }

        public void PhotoShow()
        {
            this.Visibility = Visibility.Visible;
        }

        private void ChoosePhoto_Btn_Click_1(object sender, RoutedEventArgs e)
        {
            bool newbool = profilePage.GetBool(false);

            if (this != null && profilePage.GetBool(false) == true)
            {
                profilePage.Visibility = Visibility.Visible;
                this.PhotoHide();
                profilePage.GetBool(false);
            }
            else
            {
                profile.ShowProfile();
                this.PhotoHide();
            }
        }
    }
}
