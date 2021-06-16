using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TextualRedundancy.Classes;
using TextualRedundancy.ViewModels;

using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using Point = System.Windows.Point;

namespace TextualRedundancy.Controls
{
    public partial class ActivationBitMap : UserControl
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

        private System.Timers.Timer Refreshtimer = new System.Timers.Timer();
        private Graphics BMPGraphics = null;
        private Bitmap Area = null;
        private Color ColorBG;
        private object Lock = new object();
        private object Graphic = new object();

        public ActivationBitMap()
        {
            ColorBG = Color.FromArgb(AppColors.bg.R, AppColors.bg.G, AppColors.bg.B);

            InitializeComponent();

            Analyzer.Started += Analyzer_Started;
            Analyzer.Finished += Analyzer_Finished;
            Tokenizer.TokenChanged += Tokenizer_TokenChanged;

            Loaded += ActivationMap_Loaded;

            Refreshtimer.Elapsed += Refresh_Elapsed;
            Refreshtimer.Interval = 780;
            Refreshtimer.AutoReset = true;
            Refreshtimer.Start();
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

            int mean = (int)(Points.Sum(p => p.Second.Y) / (double)Points.Count);

            Pen pen = new Pen(Color.Gray);
            pen.Width = (float)1;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen.DashPattern = new float[] { 1, 6, 1, 6 };

            lock (Graphic)
                BMPGraphics.DrawLine(pen, 0, mean, (int)width, mean);

            mean_visible = true;
        }

        void DrawBase()
        {
            Color lclr = Color.FromArgb(62, 62, 62);
            Pen pen2 = new Pen(lclr);
            pen2.Width = 1;
            pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen2.DashPattern = new float[] { 1, 4, 1, 4 };
            int h2 = (int)height / 2;

            lock (Graphic)
                BMPGraphics.DrawLine(pen2, 0, h2, (int)width, h2);
        }

        private void Analyzer_Started(object sender, StartedEventArgs e)
        {
            Reset();

            length = ApplicationVM.CurrentFileSize;
            y = ActualHeight / 2;
            step = height / (8);
            x = 0;
            match_count = 0;
            point_count = 0;

        }

        void Reset()
        {
            Points.Clear();
            lock (Graphic)
                BMPGraphics.Clear(ColorBG);

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

            Area = new Bitmap((int)ActualWidth, (int)ActualHeight);

            lock (Graphic)
            {
                BMPGraphics = null;
                BMPGraphics = Graphics.FromImage(Area);
            }
            ClearGraphics();
        }

        void ClearGraphics()
        {
            lock (Graphic)
                BMPGraphics.Clear(ColorBG);

            DrawBase();
        }

        private void Tokenizer_TokenChanged(object sender, Classes.TokenChangedEventArgs e)
        {
            Collect(e);
        }

        List<Pair<Point, Point>> Points = new List<Pair<Point, Point>>();

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
            ClearGraphics();

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

            Color color = Color.SteelBlue;
            Pen pen = new Pen(color);
            pen.Width = (float)1.25;

            foreach (Pair<Point, Point> p in copy.OrderBy(o => o.SynchronouseIndex))
            {
                if (p.IsDrawn)
                    continue;

                p.IsDrawn = true;

                lock (Graphic)
                    BMPGraphics.DrawLine(pen, (int)x_prev, (int)y_prev, (int)p.Second.X, (int)p.Second.Y);

                x_prev = p.Second.X;
                y_prev = p.Second.Y;

            }

            if (match_count > 0 && point_count >= match_count)
                ShowMean();

            ShowBitmap();
        }

        void ShowBitmap()
        {
            Dispatcher.Invoke(() => MainImage.Source = BMP.BitmapToImageSource(Area));
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
