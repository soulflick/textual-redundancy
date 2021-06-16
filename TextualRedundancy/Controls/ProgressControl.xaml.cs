using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TextualRedundancy.ViewModels;

namespace TextualRedundancy.Controls
{
    public partial class ProgressControl : Window
    {
        public static ProgressControl Instance;

        public delegate void UpdateProgress(double percent);

        public UpdateProgress DelegateUpdateProgress;
        public bool IsStarted = false;
        public bool IsClosed = false;

        private ProgressVM ViewModel = null;
        
        public ProgressControl()
        {
            var bmap = new BitmapImage(new Uri("pack://application:,,,/TextualRedundancy;component/Images/icon.png", UriKind.Absolute));
            Icon = bmap;

            InitializeComponent();

            Instance = this;
            ViewModel = new ProgressVM(this);

            DataContext = ViewModel;
            Closed += ProgressControl_Closed;
        }

        public void updateProgressFunc(double number)
        {
            TotalProgress.Value = number;
            TotalProgress.UpdateLayout();

        }
        
        private void ProgressControl_Closed(object sender, EventArgs e)
        {
            IsClosed = true;
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationVM.Instance.CmdStop.Execute(null);
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
