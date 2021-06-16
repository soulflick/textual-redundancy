using System.Collections;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using TextualRedundancy.ViewModels;

namespace TextualRedundancy.Controls
{
    public partial class TokenControl : UserControl
    {
        private TokenVM ViewModel { get; set; }
        private SortDescriptionCollection SortDescriptions = null;
        private IEnumerable CurrentView = null;

        public TokenControl()
        {
            InitializeComponent();
            ViewModel = new TokenVM();
            DataContext = ViewModel;
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;

        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Tokens")
            {
                Dispatcher.Invoke(() =>
                {
                    if (CurrentView == null)
                        return;

                    sdescs = CollectionViewSource.GetDefaultView(CurrentView).SortDescriptions;

                    SortDescription sde2 = new SortDescription();
                    if (sdescs != null && sdescs.Count > 0)
                    {
                        SortDescription sdesc = sdescs[sdescs.Count - 1];
                        sde2 = new SortDescription(sdesc.PropertyName, sdesc.Direction);
                    }
                    

                    ValueGrid.ItemsSource = null;
                    ValueGrid.ItemsSource = ViewModel.Tokens;

                    if (sde2.PropertyName != string.Empty)
                    {
                        ReSort(sde2);
                    }
                });
            }
        }

        private void ReSort(SortDescription sdesc)
        {
            if (sdesc == null)
                return;

            var dataView = CollectionViewSource.GetDefaultView(ValueGrid.ItemsSource);
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(sdesc);
            dataView.Refresh();
        }

        private void ValueGrid_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
                ViewModel.Reload(false);
        }

        SortDescriptionCollection sdescs
        {
            get { return SortDescriptions; }
            set { SortDescriptions = value;  }
        }
        
        private void ValueGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            this.Dispatcher.BeginInvoke((System.Action) delegate () {
                CurrentView = (sender as DataGrid).ItemsSource;
            });
        }
    }
}
