using System;
using System.Windows;
using System.Windows.Controls;

namespace daisy.Controls
{
    /// <summary>
    /// Interaction logic for Daisy.xaml
    /// </summary>
    public partial class Daisy : UserControl
    {
        public Daisy()
        {
            InitializeComponent();
        }

        private double MinSize
        {
            get { return (double)Math.Min(ActualWidth,ActualHeight); }
        }
        
        private void daisyMain_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            OuterGrid.Width = MinSize - OuterGrid.RowDefinitions[0].ActualHeight;
            OuterGrid.Height = MinSize;
        }          
    }
}
