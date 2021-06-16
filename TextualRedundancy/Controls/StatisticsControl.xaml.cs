using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TextualRedundancy.ViewModels;

namespace TextualRedundancy.Controls
{
    public partial class StatisticsControl : UserControl
    {
        public DockPane DockHost = null;

        private StatisticsVM ViewModel = new StatisticsVM();
        private bool once = false;
        private List<ColumnDefinition> kdefs = new List<ColumnDefinition>();
        private List<ColumnDefinition> vdefs = new List<ColumnDefinition>();

        public StatisticsControl()
        {
            InitializeComponent();
            DataContext = ViewModel;
            lvStatisticValues.DataContext = ViewModel.Statistics;
            ViewModel.Statistics.OnReload += Statistics_OnReload;
        }
        
        private void Statistics_OnReload(object sender, EventArgs e)
        {
            if (once)
                return;
            once = true;

            double sum = 0;
            double max = 0;
            foreach (ColumnDefinition c in kdefs)
                max = Math.Max(max, c.ActualWidth);

            sum = max;

            foreach (ColumnDefinition c in kdefs)
                c.Width = new GridLength(max);

            max = 0;
            foreach (ColumnDefinition c in vdefs)
                max = Math.Max(max, c.ActualWidth * 3);

            sum += max;

            foreach (ColumnDefinition c in vdefs)
                c.Width = new GridLength(max);

            ResizeWindow(sum);
        }

        void ResizeWindow(double max)
        {
            if (DockHost != null)
                DockHost.Width = max + 76;
        }

        private void KeyDef_Loaded(object sender, RoutedEventArgs e)
        {
            ColumnDefinition kdef = sender as ColumnDefinition;
            if (!kdefs.Contains(kdef))
                kdefs.Add(kdef);
        }

        private void ValDef_Loaded(object sender, RoutedEventArgs e)
        {
            ColumnDefinition vdef = sender as ColumnDefinition;
            if (!vdefs.Contains(vdef))
                vdefs.Add(vdef);
        }
    }
}
