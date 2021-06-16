using System;
using System.ComponentModel;
using TextualRedundancy.Classes;

namespace TextualRedundancy.ViewModels
{
    class ProgressVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Controls.ProgressControl ProgressControl = null;
        private System.Timers.Timer refreshTimer = null;

        private double whitespace_length;
        private double unique_length;
        private double duplicate_length;
        private double sum;
        private double max;

        public void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));

        }
        private int fileSize = 0;
        public int FileSize
        {
            get { return fileSize; }
            set { fileSize = value; OnPropertyChanged("FileSize"); }
        }

        private int numberOfBytes = 0;
        public int NumberOfBytes
        {
            get { return numberOfBytes; }
            set { numberOfBytes = Math.Min(value,FileSize); OnPropertyChanged("NumberOfBytes"); }
        }

        private int numberOfTokens = 0;
        public int NumberOfTokens
        {
            get { return numberOfTokens; }
            set { numberOfTokens = value; OnPropertyChanged("NumberOfTokens"); }
        }

        private int numberUnique = 0;
        public int NumberUnique
        {
            get { return numberUnique; }
            set { numberUnique = value; OnPropertyChanged("NumberUnique"); }
        }

        private double percentUnique = 0;
        public double PercentUnique
        {
            get { return percentUnique; }
            set { percentUnique = value; }
        }

        private double totalPercent = 0;
        public double TotalPercent
        {
            get { return totalPercent; }
            set { totalPercent = value; }
        }
        private double percentNew = 0;
        public double PercentNew
        {
            get { return percentNew; }
            set { percentNew = value; }
        }
        private double percentWhitespace = 0;
        public double PercentWhitespace
        {
            get { return percentWhitespace; }
            set { percentWhitespace = value; }
        }
        private double percentDuplicate = 0;
        public double PercentDuplicate
        {
            get { return percentDuplicate; }
            set { percentDuplicate = value; }
        }


        private void Clear()
        {
            FileSize = (int)ApplicationVM.CurrentFileSize;
            NumberOfBytes = 0;
            NumberOfTokens = 0;
            NumberUnique = 0;
            whitespace_length = 0;
            duplicate_length = 0;
            unique_length = 0;
            sum = 0;
            Update();
        }

        public ProgressVM(Controls.ProgressControl ctrl)
        {
            ProgressControl = ctrl;

            Analyzer.Started += Analyzer_Started;
            Tokenizer.TokenChanged += UpdateProgress;
            Analyzer.Finished += Analyzer_Finished;

            refreshTimer = new System.Timers.Timer();
            refreshTimer.Elapsed += RefreshTimer_Elapsed;
            refreshTimer.Interval = 850;
            refreshTimer.AutoReset = true;

            Clear();
        }

        private void Analyzer_Started(object sender, StartedEventArgs e)
        {
            ProgressControl.IsStarted = true;
            Clear();
            FileSize = (int)ApplicationVM.CurrentFileSize;
            ProgressControl.Dispatcher.Invoke(() =>
            {
                if (ProgressControl.WindowState == System.Windows.WindowState.Minimized)
                    ProgressControl.WindowState = System.Windows.WindowState.Normal;
            });
            refreshTimer.Start();
        }

        private void Analyzer_Finished(object sender, FinishedEventArgs e)
        {
            NumberOfBytes = FileSize;
            refreshTimer.Stop();

            UpdateProgress();
            Update();
            
            NumberOfBytes = FileSize;
        }

        private void RefreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            AppDispatcher.Dispatcher.Invoke(() =>
            {
                UpdateProgress();
                Update();
            });
        }


        void Update()
        {
            OnPropertyChanged("PercentUnique");
            OnPropertyChanged("TotalPercent");
            OnPropertyChanged("PercentNew");
            OnPropertyChanged("PercentDuplicate");
            OnPropertyChanged("PercentWhitespace");
            OnPropertyChanged("NumberOfBytes");
            OnPropertyChanged("NumberUnique");

            ProgressControl.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Send, new Action(() => OnPropertyChanged("NumberOfBytes")));
        }

        private void UpdateProgress(object sender, TokenChangedEventArgs e)
        {
            NumberOfBytes += e.Token.Length;
            if (e.IsSeparator)
            {

            }
            else
            {
                NumberOfTokens++;
                if (e.Added)
                    NumberUnique++;
            }

            PercentUnique = Math.Round((((double)NumberUnique / (double)NumberOfTokens) * 100), 2);
            TotalPercent = Math.Round((((double)NumberOfBytes / (double)FileSize) * 100), 2);
            PercentNew = Math.Round((100 / (double)NumberOfBytes) * unique_length, 2);
            PercentWhitespace = Math.Round((100 / (double)NumberOfBytes) * whitespace_length, 2);
            PercentDuplicate = Math.Round((100 / (double)NumberOfBytes) * duplicate_length, 2);

            if (e.IsSeparator)
                whitespace_length += e.Token.Length;
            else
            {
                if (e.Added)
                    unique_length += e.Token.Length;
                else
                    duplicate_length += e.Token.Length;
            }

            sum = whitespace_length + unique_length + duplicate_length;
            max = 600;

            if (sum == 0)
            {
                ProgressControl.CDREST.Width = new System.Windows.GridLength(max);
                return;
            }
        }

        void UpdateProgress()
        {
            AppDispatcher.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                PercentUnique = Math.Round((((double)NumberUnique / (double)NumberOfTokens) * 100), 2);
                TotalPercent = Math.Round((((double)NumberOfBytes / (double)FileSize) * 100), 2);
                PercentNew = Math.Round((100 / (double)NumberOfBytes) * unique_length, 2);
                PercentWhitespace = Math.Round((100 / (double)NumberOfBytes) * whitespace_length, 2);
                PercentDuplicate = Math.Round((100 / (double)NumberOfBytes) * duplicate_length, 2);

                double fact = max / sum;

                if (sum == 0)
                    return;

                ProgressControl.CDREST.Width = new System.Windows.GridLength(0);

                ProgressControl.CDWS.Width = new System.Windows.GridLength(fact * whitespace_length);
                ProgressControl.LengthWhiteSpace.Width = fact * whitespace_length;

                ProgressControl.CDNEW.Width = new System.Windows.GridLength(fact * unique_length);
                ProgressControl.LengthTokens.Width = fact * unique_length;

                ProgressControl.CDDUPL.Width = new System.Windows.GridLength(fact * duplicate_length);
                ProgressControl.LengthDuplicates.Width = fact * duplicate_length;

                ProgressControl.CDREST.Width = new System.Windows.GridLength(0);

                Update();
            }));

        }
    }
}
