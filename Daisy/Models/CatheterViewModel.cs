using Daisy.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Daisy.ViewModels
{
    public class CatheterViewModel : ViewModelBase
    {
        public CatheterViewModel(int numberOfElectrodes, List<int> posteriorElectrodes, double radius)
        {
            NumberOfElectrodes = numberOfElectrodes;
            PosteriorElectrodes = posteriorElectrodes;
            Radius = radius;
            CalculateOrientationLine();
        }

        #region Catheter Characteristics

        private int _numberOfElectrodes;

        public int NumberOfElectrodes
        {
            get { return _numberOfElectrodes; }
            set 
            { 
                _numberOfElectrodes = value;
                InitElectrodes();
            }
        }

        private List<int> _posteriorElectrodes;
        public List<int> PosteriorElectrodes
        {
            get { return _posteriorElectrodes; }
            set 
            { 
                _posteriorElectrodes = value;
                InitElectrodes();
            }
        }

        private double _radius;
        public double Radius
        {
            get { return _radius; }
            set 
            { 
                _radius = value;
                InitElectrodes();
                NotifyPropertyChanged();
            }
        }

        public void SetAblationPhase(EAblationPhase ablationPhase)
        {
            foreach (var electrode in Electrodes)
            {
                electrode.AblationPhase = ablationPhase;
            }
        }

        #endregion


        #region Electrodes
        public ObservableCollection<ElectrodeViewModel> Electrodes { get; set; }

        public void InitElectrodes()
        {
            if (NumberOfElectrodes < 3 || PosteriorElectrodes == null || Radius <= 0)
                return;

            int solidTriangleMarkerPosition = NumberOfElectrodes / 3;
            int outlineTriangleMarkerPosition = (NumberOfElectrodes * 2) / 3;
            var electrodes = new ObservableCollection<ElectrodeViewModel>();
            double height = CalculateElectrodeHeight(NumberOfElectrodes);

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

                bool isPosterior = PosteriorElectrodes.Contains(number);

                electrodes.Add(new ElectrodeViewModel(number, orientationMarker, isPosterior, angle, height));
            }

            Electrodes = electrodes;
            NotifyPropertyChanged(nameof(Electrodes));
        }

        private double CalculateElectrodeHeight(int numberOfElectrodes)
        {
            if (numberOfElectrodes < 3)
                return 0;

            double internalRadius = Radius * 0.67;  // Use a smaller circle to calculate height
            double thetaRad = 2 * Math.PI / numberOfElectrodes;  // Pie section
            double height = Math.Abs((int)(Math.Cos(thetaRad / 2) * internalRadius));   // Pie triangle height
            return height;
        }
        #endregion


        #region Electrode Selection

        public void SetElectrodeSelection(int electrodeNumber, bool isSelected)
        {
            if (electrodeNumber < 1 || electrodeNumber > Electrodes.Count)
                return;

            Electrodes[electrodeNumber - 1].IsSelected = isSelected;
        }

        public void SetElectrodesSelection(List<int>electrodeNumbers, bool isSelected)
        {
            foreach (var electrodeNumber in electrodeNumbers)
            {
                SetElectrodeSelection(electrodeNumber, isSelected);
            }
        }

        public void SetAllElectrodeSelections(bool isSelected)
        {
            foreach (var electrode in Electrodes)
            {
                electrode.IsSelected = isSelected;
            }
        }

        #endregion


        #region Electrode Alignment Criteria

        public void SetElectrodeAlignmentCriteriaAdequacy(int electrodeNumber, bool meetsCriteria)
        {
            if (electrodeNumber < 1 || electrodeNumber > Electrodes.Count)
                return;

            Electrodes[electrodeNumber - 1].MeetsAlignmentCriteria = meetsCriteria;
        }

        public void SetElectrodesAlignmentCriteriaAdequacy(List<int> electrodeNumbers, bool meetsCriteria)
        {
            foreach (var electrodeNumber in electrodeNumbers)
            {
                SetElectrodeAlignmentCriteriaAdequacy(electrodeNumber, meetsCriteria);
            }
        }

        public void SetAllElectrodeAlignmentCriteriaAdequacies(bool meetsCriteria)
        {
            foreach (var electrode in Electrodes)
            {
                electrode.MeetsAlignmentCriteria = meetsCriteria;
            }
        }

        #endregion


        #region Electrode Number of Activations

        public void IncrementElectrodeNumberOfActivations(int electrodeNumber)
        {
            if (electrodeNumber < 1 || electrodeNumber > Electrodes.Count)
                return;

            ++Electrodes[electrodeNumber - 1].NumberOfActivations;
        }

        public void IncrementElectrodesNumberOfActivations(List<int> electrodeNumbers)
        {
            foreach (var electrodeNumber in electrodeNumbers)
            {
                IncrementElectrodeNumberOfActivations(electrodeNumber);
            }
        }

        public void IncrementAllElectrodesNumberOfActivations()
        {
            foreach (var electrode in Electrodes)
            {
                ++electrode.NumberOfActivations;
            }
        }

        public void SetElectrodeNumberOfActivations(int electrodeNumber, int numberOfActivations)
        {
            if (electrodeNumber < 1 || electrodeNumber > Electrodes.Count || numberOfActivations < 0)
                return;

            Electrodes[electrodeNumber - 1].NumberOfActivations = numberOfActivations;
        }

        public void ResetAllElectrodesNumberOfActivations()
        {
            foreach (var electrode in Electrodes)
            {
                electrode.NumberOfActivations = 0;
            }
        }

        #endregion


        #region Electrode Ablation Result

        public void SetElectrodeAblationResult(int electrodeNumber, EAblationResult ablationResult)
        {
            if (electrodeNumber < 1 || electrodeNumber > Electrodes.Count)
                return;

            Electrodes[electrodeNumber - 1].AblationResult = ablationResult;
        }

        public void SetElectrodesAblationResult(List<int> electrodeNumbers, List<EAblationResult> ablationResults)
        {
            if (electrodeNumbers.Count != ablationResults.Count)
                return;

            int counter = 0;
            foreach (var electrodeNumber in electrodeNumbers)
            {
                SetElectrodeAblationResult(electrodeNumber, ablationResults[counter]);
                ++counter;
            }
        }

        #endregion


        #region Orientation Lines
        public Size OrientationLineRadius { get; set; }
        public Point OrientationLineStart { get; set; }
        public Point OrientationLineEnd { get; set; }

        private void CalculateOrientationLine()
        {
            if (Radius <= 0)
                return;

            OrientationLineRadius = new Size(Radius, Radius);
            double thetaRad = 2 * Math.PI / 9;  // Pie section
            OrientationLineStart = new Point(-Radius * Math.Sin(thetaRad/2) + Radius, Radius * Math.Cos(thetaRad/2) - 0.8 * Radius);
            OrientationLineEnd = new Point(Radius * Math.Sin(thetaRad/2) + Radius, OrientationLineStart.Y);
        }
        #endregion
    }

}