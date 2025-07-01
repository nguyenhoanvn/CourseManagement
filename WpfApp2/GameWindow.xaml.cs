using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private DispatcherTimer blinkTimer;
        private DispatcherTimer speedUpTimer;
        private double blinkIntervalMs = 1050;
        private const double MinIntervalMs = 50;
        private const double DecreaseStep = 100;
        public GameWindow()
        {
            InitializeComponent();

            // Timer for blinking
            blinkTimer = new DispatcherTimer();
            blinkTimer.Interval = TimeSpan.FromMilliseconds(blinkIntervalMs);
            blinkTimer.Tick += BlinkTimer_Tick;
            blinkTimer.Start();

            // Timer for speeding up the blink
            speedUpTimer = new DispatcherTimer();
            speedUpTimer.Interval = TimeSpan.FromSeconds(2); // Speed up every second
            speedUpTimer.Tick += SpeedUpTimer_Tick;
            speedUpTimer.Start();

        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            DotImage.Visibility = DotImage.Visibility == Visibility.Visible
                ? Visibility.Hidden
                : Visibility.Visible;
        }

        private void SpeedUpTimer_Tick(object sender, EventArgs e)
        {
            if (blinkIntervalMs >= MinIntervalMs)
            {
                blinkIntervalMs -= DecreaseStep;
                blinkTimer.Interval = TimeSpan.FromMilliseconds(blinkIntervalMs);
            }
            else
            {

                speedUpTimer.Stop();
                blinkTimer.Stop();
                BombText.Visibility = Visibility.Visible;
                DotImage.Visibility = Visibility.Hidden;
                BombImage.Visibility = Visibility.Hidden;
            }
        }


    }
}
