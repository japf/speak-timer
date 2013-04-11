using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WinTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer;
        private TimeSpan timeSpan;

        public MainPage()
        {
            this.InitializeComponent();

            this.timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            this.timer.Tick += TimerOnTick;

            this.timeSpan = new TimeSpan();

            this.txtHour.Text = DateTime.Now.ToString("HH:MM:ss");
            var t = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            t.Tick += (s, e) => this.txtHour.Text = DateTime.Now.ToString("HH:MM:ss");
            t.Start();
        }

        private void TimerOnTick(object sender, object o)
        {
            this.timeSpan = this.timeSpan.Add(TimeSpan.FromSeconds(1));
            this.txtDuration.Text = this.timeSpan.ToString("c");
        }

        private void OnButtonStartClick(object sender, RoutedEventArgs e)
        {
            this.timer.Start();
        }

        private void OnButtonPauseClick(object sender, RoutedEventArgs e)
        {
            this.timer.Stop();
        }

        private void OnButtonStopClick(object sender, RoutedEventArgs e)
        {
            this.timeSpan = new TimeSpan();
            this.timer.Stop();

            this.txtDuration.Text = this.timeSpan.ToString("c");
        }
    }
}
