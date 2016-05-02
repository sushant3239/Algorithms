using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GameOfLife
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(33.33);
            timer.Tick += UpdateLoop;
            timer.Start();
        }

        private void UpdateLoop(object sender, object e)
        {
            
        }
    }
}
