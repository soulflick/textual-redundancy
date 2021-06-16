using System.Windows;
using System.Windows.Controls;
using TextualRedundancy.ViewModels;

namespace TextualRedundancy.Controls
{
    public partial class DistributionControl : UserControl
    {
        private DistributionVM ViewModel;
        public DistributionControl()
        {
            InitializeComponent();

            ViewModel = new DistributionVM(this);
            DataContext = ViewModel;
        }
    }
}
