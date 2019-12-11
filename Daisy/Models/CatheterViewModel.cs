using Daisy.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Daisy.ViewModels
{
    public class CatheterViewModel : ViewModelBase
    {
        public CatheterViewModel(int numberOfElectrodes, List<int> posteriorElectrodes)
        {
            NumberOfElectrodes = numberOfElectrodes;
            PosteriorElectrodes = posteriorElectrodes;
            InitOrientationLines();
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
            if (NumberOfElectrodes < 3 || PosteriorElectrodes == null)
                return;

            int solidTriangleMarkerPosition = NumberOfElectrodes / 3;
            int outlineTriangleMarkerPosition = (NumberOfElectrodes * 2) / 3;
            var electrodes = new ObservableCollection<ElectrodeViewModel>();

            for (int i = 0; i < NumberOfElectrodes; i++)
            {
                int number = i + 1;

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

                electrodes.Add(new ElectrodeViewModel(number, orientationMarker, isPosterior));
            }

            Electrodes = electrodes;
            NotifyPropertyChanged(nameof(Electrodes));
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

        public string AblationParamString 
        { 
            get
            {
                switch (AblationParam)
                {
                    case EAblationParam.ImpedanceDrop:
                        return "Impedance Drop";
                    case EAblationParam.TemperatureRise:
                        return "Temperature Rise";
                    default:
                        break;
                }
                return string.Empty;
            }
        }

        private EAblationParam eAblationParam = EAblationParam.ImpedanceDrop;
        public EAblationParam AblationParam
        {
            get { return eAblationParam; }
            set 
            { 
                eAblationParam = value;
                SetElectrodeAblationParam();
                NotifyPropertyChanged(AblationParamString);
            }
        }

        private void SetElectrodeAblationParam()
        {
            foreach (var electrode in Electrodes)
            {
                electrode.AblationParam = AblationParam;
            }
        }


        public void SetElectrodeAblationResult(int electrodeNumber, double result)
        {
            if (electrodeNumber < 1 || electrodeNumber > Electrodes.Count)
                return;

            Electrodes[electrodeNumber - 1].AblationResult = result;
        }

        public void SetElectrodesAblationResult(List<int> electrodeNumbers, List<double> ablationResults)
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
        public ObservableCollection<OrientationLineModel> OrientationLines { get; set; }

        private void InitOrientationLines()
        {
            var orientationLines = new ObservableCollection<OrientationLineModel>();

            orientationLines.Add(new OrientationLineModel(EDirection.North));
            orientationLines.Add(new OrientationLineModel(EDirection.East));
            orientationLines.Add(new OrientationLineModel(EDirection.South));
            orientationLines.Add(new OrientationLineModel(EDirection.West));

            OrientationLines = orientationLines;
            NotifyPropertyChanged(nameof(OrientationLines));
        }
        #endregion
    }

}