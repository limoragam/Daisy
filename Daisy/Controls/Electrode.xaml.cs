using System.Windows;
using System.Windows.Controls;

namespace daisy.Controls
{
    /// <summary>
    /// Interaction logic for Electrode.xaml
    /// </summary>
    public partial class Electrode : UserControl
    {
        public Electrode()
        {
            InitializeComponent();
        }

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(Electrode), new PropertyMetadata(0.0));


        public double RimThickness
        {
            get { return (double)GetValue(RimThicknessProperty); }
            set { SetValue(RimThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RimThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RimThicknessProperty =
            DependencyProperty.Register("RimThickness", typeof(double), typeof(Electrode), new PropertyMetadata(0.0));


    }
}
