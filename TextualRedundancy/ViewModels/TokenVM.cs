using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TextualRedundancy.Classes;

namespace TextualRedundancy.ViewModels
{
    class TokenVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));

        }

        public TokenVM()
        {
            Analyzer.Finished += Analyzer_Finished;
        }

        public void Reload(bool reorder = true)
        {
            Tokens = Analyzer.Instance.GetMatches();
            if (!Tokens.Any())
                return;

            double length = 120;
            double max = Tokens.Max(m => m.Amount);
            double maxlen = Tokens.Max(m => m.Token.Length * m.Amount);

            foreach (TokenMatch match in Tokens)
            {
                double setting = match.Amount;
                double val = (length / max) * setting;
                match.DistributionLength = val;

                double len = match.Token.Length * match.Amount;
                val = (length / maxlen) * len;
                match.RelativeTokenLength = val;
            }

            OnPropertyChanged("Tokens");
        }

        private void Analyzer_Finished(object sender, FinishedEventArgs e)
        {
            Reload();
        }

        private List<TokenMatch> tokens = null;
        public List<TokenMatch> Tokens
        {
            get { return tokens; }
            set
            {
                tokens = value;
                OnPropertyChanged("Tokens");

            }
        }
    }
}
