using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TextualRedundancy.Classes;

namespace TextualRedundancy.Controls
{
    public partial class DockPane : Window
    {
        public TabItem Item = null;

        private ICommand undockPane = null;
        private DockHost DockHost = null;
        private Point InitialMousePos;

        public new string Name
        {
            get; set;
        }

        public ICommand CmdUndockPane
        {
            get
            {
                return undockPane ?? (undockPane = new ParamCommand(param => DockAndClose(param), true));
            }
        }
        
        public DockPane(DockHost Host)
        {
            var bmap = new BitmapImage(new Uri("pack://application:,,,/TextualRedundancy;component/Images/icon.png", UriKind.Absolute));
            Icon = bmap;

            InitializeComponent();
            Closing += DockPane_Closing;
            SizeChanged += DockPane_SizeChanged;
            LocationChanged += DockPane_LocationChanged;
            StateChanged += DockPane_StateChanged;

            DockHost = Host;

        }

        private void DockPane_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                Height = UI.screen_height / 2;
                Width = UI.screen_width / 2;
                Top = UI.screen_height / 7;
                Left = UI.screen_width / 7;
                UI.Rasterize(this);
            }
        }

        private void DockPane_LocationChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                return;

            Left = Math.Max(0, UI.Rasterize(Left, UI.RASTER));
            Top = Math.Max(0, UI.Rasterize(Top, UI.RASTER));
        }

        private void DockPane_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Width = UI.Rasterize(Width, UI.RASTER);
            Height = UI.Rasterize(Height, UI.RASTER);
            e.Handled = true;
        }

        public void DockAndClose(object param)
        {
            Dock(null);
            Closing -= DockPane_Closing;
            Close();
        }

        private void DockPane_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dock(null);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DockAndClose(null);
        }

        public void RemoveItem(TabItem itm = null)
        {
            MainTab.Items.RemoveAt(0);
        }

        private void Dock(object sender)
        {
            if (MainTab.Items.Count == 0)
                return;

            TabItem current = MainTab.Items[0] as TabItem;
            MainTab.Items.Remove(current);
            DockHost.Manager.Dock(current);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point thisPos = UI.GetMousePosition(this);
                Vector delta = thisPos - InitialMousePos;

                delta.X = UI.Rasterize(delta.X, 16);
                delta.Y = UI.Rasterize(delta.Y, 16);

                Top += delta.Y;
                Left += delta.X;

                if (delta.Y != 0 || delta.X != 0)
                {
                    InitialMousePos.X += delta.X;
                    InitialMousePos.Y += delta.Y;
                }
            }
        }

        private void DockImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DockAndClose(null);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                bool isnormal_afterwards = WindowState == WindowState.Maximized;
                WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
                return;
            }

            InitialMousePos = UI.GetMousePosition(this);
            UIElement el = (UIElement)sender;
            el.CaptureMouse();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UIElement el = (UIElement)sender;
            el.ReleaseMouseCapture();
        }
    }
}
