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
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class dopaminePathwaysControl : UserControl
    {
        private static dopaminePathwaysControl _instance; //render userControl based on button pressed
        private DispatcherTimer timerVideoTime; // A timer to display the video's location

        public dopaminePathwaysControl()
        {
            InitializeComponent();

            Gif1.Visibility = Visibility.Visible;
            Gif2.Visibility = Visibility.Hidden;
            previousButton.Visibility = Visibility.Hidden;
            backButton.Visibility = Visibility.Visible;
        }

        public static dopaminePathwaysControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new dopaminePathwaysControl();
                }
                _instance = new dopaminePathwaysControl();
                return _instance;

            }
        }

        // Create the timer and otherwise get ready.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(0.1);
            timerVideoTime.Tick += new EventHandler(timer_Tick);
            Gif1.Stop();
        }

        private void Gif1_MediaOpened(object sender, RoutedEventArgs e)
        {
            sbarPosition.Minimum = 0;
            sbarPosition.Maximum =
                Gif1.NaturalDuration.TimeSpan.TotalSeconds;
            sbarPosition.Visibility = Visibility.Visible;
        }

        // Show the play position in the ScrollBar and TextBox.
        private void ShowPosition()
        {
            sbarPosition.Value = Gif1.Position.TotalSeconds;
            txtPosition.Text =
                Gif1.Position.TotalSeconds.ToString("0.0");
        }

        private void EnableTimer(bool is_playing)
        {
            timerVideoTime.IsEnabled = is_playing;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            ShowPosition();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (Gif2.Visibility == Visibility.Visible)
            {
                previousButton.Visibility = Visibility.Hidden;
                Gif2.Visibility = Visibility.Hidden;
                Gif1.Visibility = Visibility.Visible;
            } 
            
        } 
        
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (Gif1.Visibility == Visibility.Visible)
            {
                backButton.Visibility = Visibility.Visible;
                previousButton.Visibility = Visibility.Visible;
                Gif1.Visibility = Visibility.Collapsed;
                Gif1.Visibility = Visibility.Hidden;
                Gif2.Visibility = Visibility.Visible;
            }
            
        }

        private void btnSetPosition_Click(object sender, RoutedEventArgs e)
        {

            TimeSpan timespan =
                TimeSpan.FromSeconds(double.Parse(txtPosition.Text));
            Gif1.Position = timespan;
            ShowPosition();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /*
        public void PlayVideo(object sender, RoutedEventArgs e)


        {

           // VideoPreview.Visibility = Visibility.Collapsed;


           // dopaminePathwaysVideo.Visibility = Visibility.Visible;


           // dopaminePathwaysVideo.Play();


        }

        
        public void PauseVideo(object sender, RoutedEventArgs e)


        {


            VideoPreview.Visibility = Visibility.Collapsed;


            dopaminePathwaysVideo.Visibility = Visibility.Visible;


            dopaminePathwaysVideo.Pause();


        }


        public void StopVideo(object sender, RoutedEventArgs e)


        {


            VideoPreview.Visibility = Visibility.Collapsed;


            dopaminePathwaysVideo.Visibility = Visibility.Visible;


            dopaminePathwaysVideo.Stop();


        }
        */

    }
}
