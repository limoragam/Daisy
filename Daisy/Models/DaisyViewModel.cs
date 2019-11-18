using System.Collections.Generic;

namespace Daisy.ViewModels
{
    public class DaisyViewModel : ViewModelBase
    {
        public DaisyViewModel(int numberOfElectrodes)
        {
            NumberOfElectrodes = numberOfElectrodes;
            InitElectrodes();
        }

        #region Data

        public int NumberOfElectrodes { get; set; } = 0;

        public List<ElectrodeViewModel> Electrodes { get; set; }


        private void InitElectrodes()
        {
            if (NumberOfElectrodes == 0)
                return;

            int solidTriangleMarkerPosition = NumberOfElectrodes / 3;
            int outlineTriangleMarkerPosition = (NumberOfElectrodes * 2) / 3;
            var electrodes = new List<ElectrodeViewModel>();

            for (int i = 0; i < NumberOfElectrodes; i++)
            {
                int number = i + 1;
                double angle = 360.0 * i / NumberOfElectrodes;
                EOrientationMarker orientationMarker = EOrientationMarker.None;
                if (i == 0)
                {
                    orientationMarker = EOrientationMarker.Rectangle;
                }
                if (i == solidTriangleMarkerPosition)
                {
                    orientationMarker = EOrientationMarker.SolidTriangle;
                }
                if (i == outlineTriangleMarkerPosition)
                {
                    orientationMarker = EOrientationMarker.OutlineTriangle;
                }
                electrodes.Add(new ElectrodeViewModel(number, angle, orientationMarker));
            }

            Electrodes = electrodes;
        }
        #endregion
    }

    // put const lists for alignment + posterior
}