using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Daisy.ViewModels
{
    public class CatheterViewModel : ViewModelBase
    {
        public CatheterViewModel(int numberOfElectrodes, double height)
        {
            NumberOfElectrodes = numberOfElectrodes;
            Radius = (int)(height / 2);
            InitElectrodes();
            AddInfoToElectrodes();
        }

        #region CatheterModel

        public int NumberOfElectrodes { get; set; } = 0;
        public int Radius { get; set; }

        public ObservableCollection<ElectrodeViewModel> Electrodes { get; set; }


        private void InitElectrodes()
        {
            if (NumberOfElectrodes < 3)
                return;

            int solidTriangleMarkerPosition = NumberOfElectrodes / 3;
            int outlineTriangleMarkerPosition = (NumberOfElectrodes * 2) / 3;
            var electrodes = new ObservableCollection<ElectrodeViewModel>();
            double height = CalculateHeight();

            for (int i = 0; i < NumberOfElectrodes; i++)
            {
                int number = i + 1;
                double angle = 360.0 * i / NumberOfElectrodes;
                bool isPosterior = false;
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

                if (i > 3 && i < 7)
                {
                    isPosterior = true;
                }

                electrodes.Add(new ElectrodeViewModel(number, orientationMarker, isPosterior, angle, height));
            }
            Electrodes = electrodes;
        }
        #endregion


        #region Helpers
        
        private void AddInfoToElectrodes()
        {
            int i = 0;
            foreach (var electrode in Electrodes)
            {
                if (i < 5)
                {
                    electrode.MeetsAlignmentCriteria = true;
                }
                if (i == 9)
                {
                    electrode.IsSelected = false;
                }
                ++i;
            }
        }

        private double CalculateHeight()
        {
            if (NumberOfElectrodes < 3)
                return 0;

            double thetaRad = 2 * Math.PI / NumberOfElectrodes;  // Angle of pie section
            thetaRad *= 0.95;   // Leave somespace around pie section
            double height = 1.8 * Math.Abs((int)(Math.Cos(thetaRad / 2) * Radius));   // Height of pie section times factor
            return height;
        }

        #endregion
    }

}