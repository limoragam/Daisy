using Daisy.ViewModels;
using System.Windows.Controls;

namespace Daisy.Petal
{
    /// <summary>
    /// Interaction logic for Electrode.xaml
    /// </summary>
    public partial class Electrode : UserControl
    {
        public Electrode()
        {
            InitializeComponent();
            DataContext = new ElectrodeViewModel(1, 10, EOrientationMarker.SolidTriangle, false, false);
        }
    }
}
