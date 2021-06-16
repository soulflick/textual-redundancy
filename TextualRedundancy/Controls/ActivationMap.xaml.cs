using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TextualRedundancy.Classes;
using TextualRedundancy.ViewModels;

namespace TextualRedundancy.Controls
{
    public partial class ActivationMap : UserControl
    {
        private double x = 0;
        private double y = 0;
        private double length = 0;
        private double width = 0;
        private double height = 0;
        private double scale_factor = 0.80;
        private int match_count = 0;
        private double step = 0.2;
        private double h_2 = 0;
        private int point_count = 0;

        private bool mean_visible = false;
        private object Lock = new object();

        private System.Timers.Timer RefreshTimer = new System.Timers.Timer();
        private List<Pair<Point, Point>> Points = new List<Pair<Point, Point>>();

        public ActivationMap()
        {
            InitializeComponent();
            Analyzer.Started += Analyzer_Started;
            Analyzer.Finished += Analyzer_Finished;
            Tokenizer.TokenChanged += Tokenizer_TokenChanged;

            Loaded += ActivationMap_Loaded;

            RefreshTimer.Elapsed += Refresh_Elapsed;
            RefreshTimer.Interval = 780;
            RefreshTimer.AutoReset = true;
            RefreshTimer.Start();
        }

        
        private void Analyzer_Finished(object sender, FinishedEventArgs e)
        {
            match_count = Tokenizer.Instance.MatchCount;
            Redraw();
        }

        void ShowMean()
        {
            if (!Points.Any())
                return;

            double mean = Points.Sum(p => p.Second.Y) / (double)Points.Count;

            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
            {

                Line lmean = new Line();
                lmean.Stroke = Brushes.GreenYellow;
                lmean.StrokeThickness = 1;
                lmean.X1 = 0;
                lmean.Y1 = mean;
                lmean.X2 = width;
                lmean.Y2 = mean;
                lmean.Opacity = 0.4;
                lmean.StrokeDashArray = new DoubleCollection(new double[] { 1, 4, 1, 4 });
                Area.Children.Add(lmean);
            }));

            mean_visible = true;
        }

        private void Analyzer_Started(object sender, StartedEventArgs e)
        {
            Reset();

            length = ApplicationVM.CurrentFileSize;
            Dispatcher.Invoke(() => Area.Children.Clear());
            y = ActualHeight / 2;
            step = height / (8);
            x = 0;
            match_count = 0;
            point_count = 0;
        }

        void Reset()
        {
            Points.Clear();
            point_count = 0;
            x = 0;
            y = 0;
            length = 0;
            h_2 = height / 2;
            mean_visible = false;
        }

        private void Refresh_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Redraw();
        }

        private void ActivationMap_Loaded(object sender, RoutedEventArgs e)
        {
            y = ActualHeight / 2;
            length = ApplicationVM.CurrentFileSize;
            width = ActualWidth - 2;
            height = ActualHeight - 4;
        }

        private void Tokenizer_TokenChanged(object sender, Classes.TokenChangedEventArgs e)
        {
            Collect(e);
        }

        void Collect(TokenChangedEventArgs e)
        {

            double tokenlength = e.Token.Length;
            double delta_y = e.IsSeparator ? 0 : e.Added ? -step : step;
            double delta_x = (width / length) * tokenlength;

            point_count++;

            if (Math.Floor(x + delta_x) > Math.Floor(x) || Points.Count == 0)
            {
                Point start = new Point(x, y);
                if (Points.Count > 0)
                    start = Points[Points.Count - 1].Second;

                Point end = new Point(x + delta_x, y + delta_y);

                lock (Lock)
                {
                    Points.Add(new Pair<Point, Point>(start, end) { SynchronouseIndex = e.SynchronousIndex });
                }
            }

            x += delta_x;
            y += delta_y;

            if (y < 4 || y > height - 4)
            {
                resizeGraph();
                y = Points[Points.Count - 1].Second.Y;
            }
        }

        private void resizeGraph()
        {
            Area.Children.Clear();

            step *= scale_factor;

            int b = 0;

            for (int el = 0; el < Points.Count; el++)
            {
                Points[el].First.Y = getNewY(Points[el].First.Y);
                Points[el].Second.Y = getNewY(Points[el].Second.Y);
                Points[el].IsDrawn = false;
            }
        }

        void Redraw()
        {
            if (match_count > 0 && point_count >= match_count && !mean_visible)
                ShowMean();

            bool anynotdrawn = false;
            lock (Lock)
                anynotdrawn = !Points.Any(p => !p.IsDrawn);

            if (anynotdrawn)
                return;

            List<Pair<Point, Point>> copy = new List<Pair<Point, Point>>();

            lock (Lock)
                copy = Points.Take(Points.Count).ToList();

            if (!copy.Any())
                return;

            Pair<Point, Point> first = copy.LastOrDefault(p => p.IsDrawn);

            if (first == null)
                first = copy.FirstOrDefault(p => !p.IsDrawn);

            if (first == null)
                return;

            double x_prev = first.First.X;
            double y_prev = first.First.Y;

            foreach (Pair<Point, Point> p in copy.OrderBy(o => o.SynchronouseIndex))
            {
                if (p.IsDrawn)
                    continue;

                p.IsDrawn = true;

                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Send, new Action(() =>
                {

                    Line line = new Line();
                    line.Stroke = Brushes.SteelBlue;
                    line.StrokeThickness = 1.25;
                    line.X1 = x_prev;
                    line.X2 = p.Second.X;
                    line.Y1 = y_prev;
                    line.Y2 = p.Second.Y;
                    Area.Children.Add(line);

                    x_prev = p.Second.X;
                    y_prev = p.Second.Y;
                }));


            }

            if (match_count > 0 && point_count >= match_count)
                ShowMean();


            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                Area.UpdateLayout();
                Area.InvalidateVisual();
            }));
        }

        double getNewY(double my_y)
        {

            if (my_y >= h_2)
                my_y = h_2 + (my_y - h_2) * scale_factor;
            else
                my_y = h_2 - (h_2 - my_y) * scale_factor;

            return my_y;
        }

    }
}
