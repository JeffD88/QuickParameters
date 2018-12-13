using System.Windows;

using QuickParameters.ViewModel;

namespace QuickParameters.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            this.DataContext = new MainViewViewModel();
        }
    }
}
