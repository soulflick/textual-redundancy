using TextualRedundancy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TextualRedundancy.Controls;
using TextualRedundancy.Classes;

namespace TextualRedundancy
{
    public partial class MainWindow : Window, IDockWindow
    {
        public static MainWindow Instance;

        private ApplicationVM ViewModel = new ApplicationVM();
        private ProgressControl progressControl = new ProgressControl();
        private DockManager DockManager = null;

        private ICommand undockPane = null;
        public ICommand CmdUndockPane
        {
            get
            {
                return undockPane ?? (undockPane = new ParamCommand(param => OnUndock(param), true));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            EvaluateDockState();

            SetIcon();
            Instance = this;

            DockManager = new DockManager(this, MainTabControl);
            AppDispatcher.Dispatcher = Dispatcher;
            DataContext = ViewModel;
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            StateChanged += MainWindow_StateChanged;

            UndockAll();
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                Left = UI.screen_width / 6;
                Top = UI.screen_height / 6;
                Width = UI.screen_width / 2;
                Height = UI.screen_height / 2;
                UI.Rasterize(this);
            }
        }

        private void SetIcon()
        {
            var bmap = new BitmapImage(new Uri("pack://application:,,,/TextualRedundancy;component/Images/icon_x64.png", UriKind.Absolute));
            Icon = bmap;
        }

        private void OnUndock(object sender)
        {
            TabItem current = MainTabControl.SelectedItem as TabItem;
            DockManager.Undock(current);

            if (MainTabControl.Items.Count == 0)
            {
                if (WindowState == WindowState.Maximized)
                    WindowState = WindowState.Normal;
                Top = 0;
                Left = 0;
                Height = 100;
                Width = 600;
            }

            EvaluateDockState();
        }

        public void OnDock()
        {
            EvaluateDockState();

            if (MainTabControl.Items.Count == 1)
                MainTabControl.SelectedIndex = 0;

            if (Height < 200)
                Height = UI.screen_height / 2;
        }


        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ProgressControlVisibility")
            {
                Visibility vsbl = ViewModel.ProgressControlVisibility;

                if (vsbl == Visibility.Visible)
                {
                    if (progressControl == null)
                        progressControl = new ProgressControl();

                    if (progressControl.IsClosed)
                        progressControl = new ProgressControl();

                    progressControl.Show();
                }
                else
                {
                    if (progressControl == null)
                        return;
                    if (!progressControl.IsClosed)
                        progressControl.Close();
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            DockManager.CloseAll();

            if (!progressControl.IsClosed)
                progressControl.Close();

            Close();

        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Normalize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount != 2)
                return;

            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                    Top = Mouse.GetPosition(this).Y;
                }
                DragMove();
            }
        }

        private void DockAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DockManager.DockAll();
            EvaluateDockState();
            return;
        }

        private void ApplyLayout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UndockAll(true);
            EvaluateDockState();
        }

        public void EvaluateDockState()
        {
        }

        public void UndockAll(bool manuallyTriggered = false)
        {
            List<TabItem> itms = new List<TabItem>();

            itms.Add(TabItemStatistics);
            itms.Add(TabItemTokenGrid);
            itms.Add(TabItemMap);

            double stat_wid = 450;
            double tokgrid_left = 0;
            double distgrid_top = 0;

            foreach (TabItem item in itms)
                DockManager.Undock(item);
            
            foreach (TabItem item in itms)
            {
                DockPane pane = DockManager.Docks.FirstOrDefault(d => d.Name == item.Name);
                if (pane == null)
                    continue;

                pane.Top = 0;
                
                if (pane.Item.Name == "TabItemStatistics")
                {
                    pane.Height = UI.screen_height;
                    pane.Left = UI.Rasterize(UI.screen_width - stat_wid, UI.RASTER);
                    pane.Width = UI.Rasterize(UI.screen_width - pane.Left, UI.RASTER);
                    stat_wid = pane.Width;
                }
                else if (pane.Item.Name == "TabItemTokenGrid")
                {
                    double wid = UI.Rasterize((UI.screen_width - stat_wid) / 1.85 + 14, UI.RASTER);
                    pane.Height = UI.screen_height;
                    pane.Width = wid;
                    tokgrid_left = UI.Rasterize(UI.screen_width - stat_wid - wid, UI.RASTER);
                    pane.Left = tokgrid_left;
                }
                else if (pane.Item.Name == "TabItemMap")
                {
                    pane.Width = tokgrid_left;
                    pane.Left = 0;
                    pane.Top = 126;
                    UI.Rasterize(pane);
                    pane.Height = UI.screen_height - pane.Top;
                    distgrid_top = pane.Top;
                }

                UI.Rasterize(pane);
                pane.BringIntoView();
                pane.Focus();
            }

            WindowState = WindowState.Normal;
            Top = 0;
            Left = 0;
            Height = distgrid_top;
            Width = UI.Rasterize(tokgrid_left, UI.RASTER);

           
            if (progressControl.IsClosed)
            {
                progressControl = new ProgressControl();
            }

            if (manuallyTriggered && progressControl.IsStarted)
            {
                if (!progressControl.IsActive)
                    progressControl.Show();

                if (progressControl.WindowState == WindowState.Minimized)
                    progressControl.WindowState = WindowState.Normal;

                progressControl.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                progressControl.Focus();
            }

            Focus();

            EvaluateDockState();

        }
    }
}
