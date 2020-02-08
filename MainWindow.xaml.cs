using Daisy.Enums;
using daisy.ViewModels;
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

        private void OnResume()
        {
            DaisyViewModel data = Daisy1.DataContext as DaisyViewModel;
            
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DaisyViewModel data = new DaisyViewModel(10);
            data.SetElectrodeFluoroMarker(0, ElectrodeFluoroMarker.Rectangle);
            data.SetElectrodeFluoroMarker(3, ElectrodeFluoroMarker.SolidTriangle);
            data.SetElectrodeFluoroMarker(6, ElectrodeFluoroMarker.OutlineTriangle);

            //Daisy1.OnPlayClicked += OnResume;
            //List<int> electrodesMeetingCriteriaAdequacy1 = new List<int> { 3, 4, 5, 9 };
            //catheterViewModel1.SetElectrodesAlignmentCriteriaAdequacy(electrodesMeetingCriteriaAdequacy1, true);
            //catheterViewModel1.SetElectrodeSelection(5, false);
            data.SetAllElectrodeStatus(ElectrodeStatus.PostAblation);
            data.SetElectrodeStatus(6, ElectrodeStatus.NotSelected);
            data.SetElectrodeStatus(7, ElectrodeStatus.Disconnected);
            data.SetElectrodeAblationResult(3, 1.0);
            data.SetElectrodeAblationResult(4, 0.75);
            data.SetElectrodeAblationResult(5, 0.5);
            for( int i = 0; i < 10; ++i )
            {
                data.SetElectrodePosterior(i, true);
                data.SetElectrodeNumberOfActivations(i, 2);

            }
            data.SetElectrodePosterior(1, true);
            data.SetElectrodePosterior(3, true);
            data.SetElectrodeNumberOfActivations(1, 1);
            data.SetElectrodeNumberOfActivations(2, 2);
            data.SetElectrodeNumberOfActivations(3, 3);
            data.SetElectrodeAlignmentIndication(4, true);
            data.SetElectrodeAlignmentIndication(9, true);
            data.AdvanceColoringTitle = "ldsadas";
            Daisy1.DataContext = data;
        }

        void OnButtonClick1(object sender, RoutedEventArgs e)
        {
            DaisyViewModel data = Daisy1.DataContext as DaisyViewModel;
            data.AdvanceColoringTitle = "xyz";
            data.IsInReview = true;
            data.SetAllElectrodeStatus(ElectrodeStatus.Selected);
            List<int> posteriorElectrodes1 = new List<int> { 1, 2 };
            //             catheterViewModel1.SetElectrodeAlignmentCriteriaAdequacy(1, true);
            //             catheterViewModel1.SetElectrodeSelection(9, false);
            data.SetElectrodePosterior(1, true);
            //catheterViewModel1.PosteriorElectrodes = posteriorElectrodes1;
            //             catheterViewModel1.SetElectrodeAblationResult(5, EAblationResult.Heavy);
            data.IsPostAblation = true;

        }
    }

}
