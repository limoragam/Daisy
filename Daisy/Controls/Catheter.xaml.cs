using Daisy.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Daisy.Controls
{
    /// <summary>
    /// Interaction logic for Electrode.xaml
    /// </summary>
    public partial class Catheter : UserControl
    {
        public Catheter()
        {
            InitializeComponent();
        }

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Radius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(Catheter), new PropertyMetadata(0.0));


    }
}
