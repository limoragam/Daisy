using Daisy.Enums;
using Daisy.ViewModels;
using System.Collections.Generic;
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
            List<int> posteriorElectrodes1 = new List<int> { 5, 6, 7 };
            var catheterViewModel1 = new CatheterViewModel(10, posteriorElectrodes1, Catheter1.Radius);
            List<int> electrodesMeetingCriteriaAdequacy1 = new List<int> { 3, 4, 5, 9 };
            catheterViewModel1.SetElectrodesAlignmentCriteriaAdequacy(electrodesMeetingCriteriaAdequacy1, true);
            catheterViewModel1.SetElectrodeSelection(5, false);
            Catheter1.DataContext = catheterViewModel1;

            List<int> posteriorElectrodes2 = new List<int> { 11, 12 };
            var catheterViewModel2 = new CatheterViewModel(10, posteriorElectrodes2, Catheter2.Radius);
            List<int> electrodesMeetingCriteriaAdequacy2 = new List<int> { 9, 10, 11, 12 };
            catheterViewModel2.SetElectrodesAlignmentCriteriaAdequacy(electrodesMeetingCriteriaAdequacy2, true);
            catheterViewModel2.SetAblationPhase(EAblationPhase.During);
            catheterViewModel2.SetElectrodeSelection(7, false);
            Catheter2.DataContext = catheterViewModel2;

            List<int> posteriorElectrodes3 = new List<int> { 1, 4, 5, 6 };
            var catheterViewModel3 = new CatheterViewModel(10, posteriorElectrodes3, Catheter3.Radius);
            List<int> electrodesMeetingCriteriaAdequacy3 = new List<int> { 4, 6, 7 };
            catheterViewModel3.SetElectrodesAlignmentCriteriaAdequacy(electrodesMeetingCriteriaAdequacy3, true);
            catheterViewModel3.SetAblationPhase(EAblationPhase.After);
            catheterViewModel3.SetElectrodeSelection(1, false);
            catheterViewModel3.SetElectrodesAblationResult(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<EAblationResult> { EAblationResult.Heavy,
                                            EAblationResult.Heavy,
                                            EAblationResult.Heavy,
                                            EAblationResult.Heavy,
                                            EAblationResult.Medium,
                                            EAblationResult.Light,
                                            EAblationResult.Medium,
                                            EAblationResult.Light,
                                            EAblationResult.Light});
            catheterViewModel3.SetElectrodeNumberOfActivations(4, 2);
            catheterViewModel3.SetElectrodeNumberOfActivations(6, 2);
            Catheter3.DataContext = catheterViewModel3;
        }
    }
}
