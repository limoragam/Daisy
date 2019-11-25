using Daisy.ViewModels;
using System.Windows;

namespace Daisy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Catheter.DataContext = new CatheterViewModel(10, Catheter.Height);
        }
    }
}
