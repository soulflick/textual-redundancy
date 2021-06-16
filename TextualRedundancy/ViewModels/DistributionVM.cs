using System;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
using System.Windows.Controls;
using TextualRedundancy.Classes;
using TextualRedundancy.Controls;

namespace TextualRedundancy.ViewModels
{
    class DistributionVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public static DistributionVM Instance = null;

        private DistributionControl DistributionControl = null;

        private Color clr_green;
        private Color clr_blue;
        private Color clr_yellow;
        private Color clr_bg;
        private Timer RefreshTimer = null;

        private double canvas_width;
        private double canvas_height;
        private double x;
        private double y;
        private double pixel_size = 4;

        private Graphics BMPGraphics = null;
        private Bitmap Area = null;

        public void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));

        }

        public DistributionVM(DistributionControl ctrl)
        {
            Instance = this;
            DistributionControl = ctrl;

            clr_green = Color.FromArgb(AppColors.green.R, AppColors.green.G, AppColors.green.B);
            clr_blue = Color.FromArgb(AppColors.blue.R, AppColors.blue.G, AppColors.blue.B);
            clr_yellow = Color.FromArgb(AppColors.yellow.R, AppColors.yellow.G, AppColors.yellow.B);
            clr_bg = Color.FromArgb(AppColors.bg.R, AppColors.bg.G, AppColors.bg.B);

            RefreshTimer = new Timer();
            RefreshTimer.Interval = 1000;
            RefreshTimer.AutoReset = true;
            RefreshTimer.Elapsed += Refresh_Elapsed;

            Tokenizer.TokenChanged += Tokenizer_TokenChanged;
            Analyzer.Started += Analyzer_Started;
            Analyzer.Finished += Analyzer_Finished;

            Reset();
        }

        private void Refresh_Elapsed(object sender, ElapsedEventArgs e)
        {
            Redraw();
        }

        private void Analyzer_Finished(object sender, FinishedEventArgs e)
        {
            RefreshTimer.Stop();
            Redraw();
        }

        void Redraw()
        {
            DistributionControl.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Send, new Action(() => DistributionControl.MainImage.Source = BMP.BitmapToImageSource(Area)));
        }

        private void Analyzer_Started(object sender, StartedEventArgs e)
        {
            DistributionControl.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Send, new Action(() =>
            {
                Reset();

                Area = new Bitmap((int)DistributionControl.ActualWidth, (int)DistributionControl.ActualHeight);

                BMPGraphics = Graphics.FromImage(Area);
                BMPGraphics.Clear(clr_bg);

                RefreshTimer.Start();
            }));
        }

        public void Reset()
        {
            finished = false;
            x = 0;
            y = 0;

            int fileSize = (int)ApplicationVM.CurrentFileSize;
            double area = DistributionControl.ActualWidth * DistributionControl.ActualHeight;
            double factor = area / (double)fileSize;

            pixel_size = Math.Sqrt(factor);
            pixel_size = Math.Max(pixel_size, 2);

            canvas_width = (int)(DistributionControl.ActualWidth / pixel_size);
            canvas_height = (int)(DistributionControl.ActualHeight / pixel_size);
        }

        void DrawLine(TokenChangedEventArgs e, double x, double y, int len)
        {
            Color color = clr_green;

            if (e.IsSeparator)
                color = clr_yellow;
            else if (!e.Added)
                color = clr_blue;

            Pen pen = new Pen(color)
            {
                Width = (float)Math.Ceiling(pixel_size)
            };

            int yi = (int)(y + pixel_size / 2);
            int xi = (int)x;

            BMPGraphics.DrawLine(pen, new Point(xi, yi), new Point(xi + len, yi));
        }

        private void Tokenizer_TokenChanged(object sender, TokenChangedEventArgs e)
        {
            Updater(e);
        }

        bool finished = false;
        public void Updater(TokenChangedEventArgs e)
        {
            int len = e.Token.Length;
            int len_remain = len;
            int avail_in_line = 0;

            if (!finished && (y > (pixel_size * (canvas_height - 1))))
            {
                finished = true;
                RefreshTimer.Stop();
                Redraw();
                return;
            }

            while (len_remain > 0)
            {
                avail_in_line = (int)(canvas_width - x);

                if (avail_in_line > len_remain)
                {
                    DrawLine(e, x * pixel_size, y, (int)(Math.Ceiling(len_remain * pixel_size)));
                    x += len_remain;
                    len_remain = 0;
                }
                else
                {
                    DrawLine(e, x * pixel_size, y, (int)(Math.Ceiling(avail_in_line * pixel_size)));
                    x = 0;
                    y += pixel_size;
                    len_remain -= avail_in_line;
                }
            }

            return;
        }
    }
}
