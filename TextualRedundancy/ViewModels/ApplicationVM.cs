using TextualRedundancy.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TextualRedundancy.ViewModels
{
    public class ApplicationVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static ApplicationVM Instance = null;
        public static DateTime StartTime;
        public static double CurrentFileSize;

        public StatisticsVM StatisticsViewModel = null;

        private ICommand cmdOpenFile = null;
        private ICommand cmdStop = null;
        private Visibility visCtrl = Visibility.Collapsed;
        private Analyzer Analyzer = new Analyzer();

        private double fileSize = 0;
        private string currentFileName = "please open file ...";
        private bool ready = false;

        public void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        public string CurrentFileName { get { return currentFileName; } set { currentFileName = value; OnPropertyChanged("CurrentFileName"); } }
        
        public double FileSize { get { return fileSize; } set { fileSize = value; CurrentFileSize = value;  OnPropertyChanged("FileSize"); } }

        public Visibility ProgressControlVisibility { get { return visCtrl; } set { visCtrl = value; OnPropertyChanged("ProgressControlVisibility"); } }


        private List<TokenMatch> tokens = null;
        public List<TokenMatch> Tokens
        {
            get
            {
                return tokens;
            }
            set
            {
                tokens = value;
                OnPropertyChanged("Tokens");
            }
        }


        public ApplicationVM()
        {
            Instance = this;
            StatisticsViewModel = new StatisticsVM();
            Analyzer.Finished += Analyzer_Finished;
        }

        private void Analyzer_Finished(object sender, EventArgs e)
        {
            MessageBridge.RaiseProgress(0);
        }

        public ICommand CmdOpenFile
        {
            get { return cmdOpenFile ?? (cmdOpenFile = new LocalCommand(() => SelectFile(), () => true)); }
        }

        public ICommand CmdStop
        {
            get { return cmdStop ?? (cmdStop = new LocalCommand(() => Stop(), () => true)); }
        }


        private bool CanGo()
        {
            return ready && !Analyzer.IsBusy();
        }

        void SelectFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "*.*";
            dlg.Title = "Please select a textual file";
           
            if (dlg.ShowDialog() != true)
                return;
            
            CurrentFileName = dlg.FileName;
            ready = true;

            CommandManager.InvalidateRequerySuggested();

            long size = new System.IO.FileInfo(CurrentFileName).Length;
            string size_str = Utilities.getSizeString(size);
            StatisticsViewModel.Statistics.set("Size", size_str);
            StatisticsViewModel.Length = size;
            StatisticsViewModel.Raise();

            FileSize = size;
            StartTime = DateTime.Now;

            Start();
        }

       
        void Start()
        {
            if (!System.IO.File.Exists(CurrentFileName))
            {
                MessageBridge.Info("The given file does not exist.");
                return;
            }

            if (Analyzer.IsBusy())
            {
                MessageBridge.Info("Analyzation in progress.");
                return;
            }

            MessageBridge.Info("");
            MessageBridge.RaiseProgress(0);

            tokens = new List<TokenMatch>();

            ProgressControlVisibility = Visibility.Visible;

            try
            {
                Analyzer.Go(this, CurrentFileName);
            }
            catch (Exception exc)
            {
                MessageBridge.Info(exc.Message);
            }
        }

        void Stop()
        {
            Analyzer.Stop();
        }
    }
}