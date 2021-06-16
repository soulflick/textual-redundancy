using System.Windows.Media;

namespace TextualRedundancy.Classes
{
    public class AppColors
    {
        public static Color green = new Color() { A = 255, R = 29, G = 63, B = 48 };
        public static Color yellow = new Color() { A = 255, R = 100, G = 100, B = 100 };
        public static Color blue = new Color() { A = 255, R = 33, G = 85, B = 131 };
        public static Color bg = new Color() { A = 255, R = 26, G = 26, B = 26 };
        public static Color bg_2 = new Color() { A = 255, R = 42, G = 42, B = 42 };

        public static Brush GreenBrush = new SolidColorBrush(green);
        public static Brush YellowBrush = new SolidColorBrush(yellow);
        public static Brush BlueBrush = new SolidColorBrush(blue);

    }
}
