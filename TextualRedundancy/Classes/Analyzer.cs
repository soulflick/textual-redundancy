using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace TextualRedundancy.Classes
{
    public class FinishedEventArgs : EventArgs
    {
        public DateTime DateTimeFinished;
    }
    public class StartedEventArgs : EventArgs
    {
        public DateTime DateTimeStarted;

    }
    public class Analyzer
    {

        public static event EventHandler<FinishedEventArgs> Finished;
        public static event EventHandler<StartedEventArgs> Started;
        public static Analyzer Instance = null;
        public static long Processed = 0;
        public double position = 0;

        private int read_buff_length = 1024;
        private Tokenizer Tokenizer = null;
        private Dispatcher Dispatcher = null;
        private Thread Worker = null;
        private double duration = 0;
        
        private ViewModels.ApplicationVM view = null;
        private DateTime StartedDateTime = DateTime.Now;

        public Analyzer()
        {
            Dispatcher = AppDispatcher.Dispatcher;
            Instance = this;
        }

        public List<TokenMatch> GetMatches()
        {
            return Tokenizer.Matches;
        }

        public void Stop()
        {
            if (Worker == null || Tokenizer == null)
                return;

            bool alive = Worker.IsAlive;

            Worker.Abort();
            Tokenizer.FinalizeTokenizer();

            DateTime then = DateTime.Now;
            double duration = Math.Round((then - StartedDateTime).TotalMilliseconds, 2); ;

            GetStatistics(view.StatisticsViewModel);
            
            if (alive)
            {
                Dispatcher = AppDispatcher.Dispatcher;
                Dispatcher.Invoke(() =>
                {
                    view.Tokens = Tokenizer.Matches;
                    Finished.Invoke(this, new FinishedEventArgs() { DateTimeFinished = DateTime.Now });
                });
            }
        }

        public bool IsBusy()
        {
            if (Worker != null && Worker.IsAlive)
            {
                System.Windows.MessageBox.Show("Analyzation in progress");
                return true;
            }
            return false;
        }



        public void Go(ViewModels.ApplicationVM view, string file)
        {
            IsBusy();

            this.view = view;
            Processed = 0;

            double length = 0;

            Worker = new Thread(() =>
            {
                Encoding myFileEncoding = EncodingDetection.Detect(file);

                StartedDateTime = DateTime.Now;
                Tokenizer = new Tokenizer();
                Started?.Invoke(null, new StartedEventArgs() { DateTimeStarted = DateTime.Now });
               
                try
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        length = fs.Length;
                        int bytes_left = (int)fs.Length;
                        byte[] bytes = new byte[bytes_left];
                        int bytes_read = 0;
                        int number_of_segments = bytes_left / read_buff_length;
                        int current_segment = 0;

                        while (bytes_left > 0)
                        {
                            current_segment++;

                            int max_read = Math.Min(read_buff_length, bytes_left);
                            int n = fs.Read(bytes, bytes_read, max_read);

                            position = bytes_read;

                            String str_in = Utilities.toEncodeString(bytes, bytes_read, max_read, myFileEncoding);

                            Tokenizer.Tokenize(str_in);
                            bytes_read += n;
                            bytes_left -= n;

                            Processed = bytes_read;

                            if (n == 0) break;
                        }
                    }

                    Tokenizer.FinalizeTokenizer();

                    DateTime then = DateTime.Now;

                    duration = Math.Round((then - StartedDateTime).TotalSeconds, 2); ;

                    double bps = Math.Round((double)length / duration, 2);

                    view.StatisticsViewModel.Statistics.set("BytesPerMillisecond", bps.ToString());

                    GetStatistics(view.StatisticsViewModel);
                }
                catch (Exception exc)
                {
                    MessageBridge.Info("Exception: " + exc.Message);
                }
                finally
                {
                    Finished?.Invoke(this, new FinishedEventArgs() { DateTimeFinished = DateTime.Now });
                }

            });

            Worker.SetApartmentState(ApartmentState.STA);
            Worker.IsBackground = true;
            Worker.Start();
        }

        public List<TokenMatch> GetResults()
        {
            if (Tokenizer == null)
                return new List<TokenMatch>();

            return Tokenizer.Matches;
        }

        public void GetStatistics(ViewModels.StatisticsVM Stats)
        {
            if (Tokenizer == null || Tokenizer.Matches == null || Tokenizer.Matches.Count == 0)
                return;

            double bps = Math.Round((double)(ViewModels.ApplicationVM.CurrentFileSize / 1024) / duration, 2);
            double pu = Tokenizer.Matches.Count / (double)Tokenizer.Matches.Sum(t => t.Amount);

            double sum = Tokenizer.Matches.Sum(t => t.Amount);
            double duplicate = sum - Tokenizer.Matches.Count;
            double pd = (double)duplicate / (double)sum;

            Stats.Statistics.set("File Size", Utilities.getSizeString(ViewModels.ApplicationVM.CurrentFileSize));
            Stats.Statistics.set("Time", ViewModels.ApplicationVM.StartTime.ToString());
            Stats.Statistics.set("Speed", bps.ToString() + " kB/sec");
            Stats.Statistics.set("Duration", duration + " sec");

            Stats.Statistics.set("Number of Tokens", Tokenizer.Matches.Sum(m => m.Amount).ToString());
            Stats.Statistics.set("Unique Tokens", Tokenizer.Matches.Count.ToString());
            Stats.Statistics.set("Whitespace Sequences", Tokenizer.WhiteSpaceSequences.ToString());

            Stats.Statistics.set("Percent Unique",  (Math.Round(pu,4)*100).ToString() + " %");
            Stats.Statistics.set("Percent Unique (length)", (Math.Round(Tokenizer.LengthUnique / ViewModels.ApplicationVM.CurrentFileSize, 4) * 100).ToString() + " %");
            Stats.Statistics.set("Percent Duplicate", (Math.Round(pd, 4) * 100).ToString() + "%");
            Stats.Statistics.set("Percent Duplicate (length)", (Math.Round(Tokenizer.LengthDuplicate / ViewModels.ApplicationVM.CurrentFileSize, 4) * 100).ToString() + " %");
            Stats.Statistics.set("Percent Whitespace (length)", (Math.Round(Tokenizer.LengthWhiteSpace / ViewModels.ApplicationVM.CurrentFileSize, 4) * 100).ToString() + " %");

            Stats.Statistics.set("Mean Token Length", Math.Round(Tokenizer.Matches.Sum(s => s.Token.Length) / (double)Tokenizer.Matches.Count, 3).ToString()+ " Byte");
            Stats.Statistics.set("Minimum Redundancy", Tokenizer.Matches.Min(m => m.Amount).ToString());
            Stats.Statistics.set("Maximum Redundancy", Tokenizer.Matches.Max(m => m.Amount).ToString());
            Stats.Statistics.set("Mean Redundancy", Math.Round(Tokenizer.Matches.Sum(m => m.Amount) / (double)Tokenizer.Matches.Count, 3).ToString());
            Stats.Statistics.set("Median Redundancy", Tokenizer.Matches[Tokenizer.Matches.Count / 2].Amount.ToString());

            Stats.Statistics.Raise();
        }
    }
}
