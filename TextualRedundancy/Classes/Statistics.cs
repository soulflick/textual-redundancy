using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TextualRedundancy.Classes
{
    [Serializable()]
    public class KeyVal<T,U> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));

        }

        private T key;
        public T Key {
            get { return key; }
            set
            {
                key = value;
                OnPropertyChanged("Key");
            }
        }

        private U value;
        public U Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        public KeyVal(T k, U v)
        {
            Key = k;
            Value = v;
        }
    }

    public class Statistics : INotifyPropertyChanged
    {
        public event EventHandler OnReload;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));

        }

        public List<KeyVal<String, String>> Values { get; set; }

        public Statistics()
        {
            Values = new List<KeyVal<string, string>>();

            string[] keys = new string[]
            {
                "File Size","Time","Speed","Duration", "Number of Tokens","Unique Tokens", "Whitespace Sequences", "Percent Unique", "Percent Unique (length)", "Percent Duplicate", "Percent Duplicate (length)", "Percent Whitespace (length)", "Mean Token Length", "Minimum Redundancy","Maximum Redundancy","Mean Redundancy","Median Redundancy"
            };

            foreach (string key in keys)
                Values.Add(new KeyVal<string, string>(key, "0"));
        }

      
        public void set(string key, string value)
        {
            if (!Values.Any(v => v.Key == key))
                Values.Add(new KeyVal<string, string>(key, value));
            else
                Values.First(v => v.Key == key).Value = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Values"));
            OnPropertyChanged("Values");
        }

        public void Raise()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Values"));
            OnReload?.Invoke(this, EventArgs.Empty);
        }
    }
}
