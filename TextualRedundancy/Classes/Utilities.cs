using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TextualRedundancy.Classes
{
    public class UI
    {
        public static double screen_width = SystemParameters.WorkArea.Width;
        public static double screen_height = SystemParameters.WorkArea.Height;
        public static int RASTER = 16;

        public static void Rasterize(Window pane)
        {
            pane.Top = Rasterize(pane.Top, RASTER);
            pane.Left = Rasterize(pane.Left, RASTER);
            pane.Width = Rasterize(pane.Width, RASTER);
            pane.Height = Rasterize(pane.Height, RASTER);
        }

        public static double Rasterize(double pos, int raster)
        {
            return ((int)pos / raster) * raster;
        }

        public static System.Windows.Point GetMousePosition(Window wnd)
        {
            var position = Mouse.GetPosition(wnd);
            return new System.Windows.Point(position.X + wnd.Left, position.Y + wnd.Top);
        }

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                T childType = child as T;
                if (childType == null)
                {
                    foundChild = FindChild<T>(child, childName);

                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }
    }
    public class BMP
    {
        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }

        }
    }

    public class VarPoint
    {
        public double X;
        public double Y;
        public bool IsDrawn = false;

        public VarPoint()
        {
            ;
        }

        public VarPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public class Pair<T, V>
    {
        public bool IsDrawn = false;
        public T First;
        public V Second;
        public int SynchronouseIndex = 0;

        public Pair(T First, V Second)
        {
            this.First = First;
            this.Second = Second;
        }
    }

    public class Utilities
    {
        public static string getSizeString(double bytes)
        {
            double kb = 1024;
            double mb = Math.Pow(kb, 2);
            double gb = Math.Pow(kb, 3);

            if (bytes < kb)
                return bytes.ToString() + " bytes";
            else if (bytes < mb)
                return Math.Round((double)bytes / kb, 3) + " kB";
            else if (bytes < gb)
                return Math.Round((double)bytes / mb, 3) + " MB";
            else
                return Math.Round((double)bytes / gb, 3) + " GB";
        }

        public static string getTimeString(double msecs)
        {
            if (msecs < 1000)
                return Math.Round(msecs, 2).ToString() + " msecs";
            else if (msecs < 100)
                return Math.Round(msecs / 1000, 3).ToString() + " secs";
            else
                return Math.Round(msecs / 1000, 3).ToString() + " secs";
        }

        public static string toEncodeString(byte[] bytes, int pos, int num, Encoding enc)
        {
            byte[] arr = new byte[num];
            for (int i = pos; i < pos + num; i++)
                arr[i - pos] = bytes[i];

            return enc.GetString(arr);
        }
        public static string toString(byte[] bytes, int pos, int num)
        {
            string str = string.Empty;
            for (int i = pos; i < pos + num; i++)
                str += Convert.ToChar(bytes[i]);
            return str;
        }

        public static char[] toChars(byte[] bytes, int pos, int num)
        {
            char[] chars = new char[num];
            for (int i = pos; i < pos + num; i++)
                chars[i - pos] = Convert.ToChar(bytes[i]);
            return chars;
        }

        public static Line Copy(Line line)
        {
            Line l = new Line();
            l.X1 = line.X1;
            l.X2 = line.X2;
            l.Y1 = line.Y1;
            l.Y2 = line.Y2;
            l.Stroke = line.Stroke;
            l.StrokeThickness = line.StrokeThickness;
            return l;
        }
    }
}
