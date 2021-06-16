using TextualRedundancy.Classes;
using System;
using System.ComponentModel;

namespace TextualRedundancy.ViewModels
{
    public class StatisticsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static Statistics Instance = null;
        public long Length { get; set; }

        public void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));

        }

        public static Statistics Get()
        {
            if (Instance == null)
                Instance = new Statistics();
            return Instance;
        }

        public Statistics Statistics { get; set; }

        public StatisticsVM()
        {
            Statistics = Get();
            Raise();
        }

        public void Raise()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Statistics"));
            Statistics.Raise();
        }
    }
}
