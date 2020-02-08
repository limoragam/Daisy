//using Biosense.Common.Commands;
using Daisy.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace daisy.ViewModels
{
    public class DaisyViewModel : BaseViewModel
    {
        public DaisyViewModel(int numberOfElectrodes)
        {
            NumberOfElectrodes = numberOfElectrodes;
            DeflectionLines = new ObservableCollection<DeflectionLineModel>()
            {
                new DeflectionLineModel(DeflectionDirection.North),
                new DeflectionLineModel(DeflectionDirection.East) ,
                new DeflectionLineModel(DeflectionDirection.South),
                new DeflectionLineModel(DeflectionDirection.West)
            };
			//PlayCommand = new DelegateCommand(()=>OnPlayClicked(), new TrueCondition());
        }

        #region Daisy Characteristics

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

        #endregion


        #region Electrodes
        public ObservableCollection<ElectrodeViewModel> Electrodes { get; set; }

        private void InitElectrodes()
        {
            var electrodes = new ObservableCollection<ElectrodeViewModel>();

            for (int i = 0; i < NumberOfElectrodes; i++)
            {
                electrodes.Add(new ElectrodeViewModel(i + 1));
            }            
            Electrodes = electrodes;
            NotifyPropertyChanged(nameof(Electrodes));
        }

        #endregion

        #region Electrode FluoroMarkers

        public void SetElectrodeFluoroMarker(int electrodeNumber, ElectrodeFluoroMarker marker)
        {
            if (electrodeNumber < 0 || electrodeNumber >= Electrodes.Count)
                return;

            Electrodes[electrodeNumber].FluoroMarker = marker;
        }

        #endregion

        #region Electrode Posterior

        public void SetElectrodePosterior(int electrodeNumber, bool isPosterior)
        {
            if (electrodeNumber < 0 || electrodeNumber >= Electrodes.Count)
                return;

            Electrodes[electrodeNumber].IsPosterior = isPosterior;
        }

        public void SetAllElectrodePosterior(bool isPosterior)
        {
            foreach (var electrode in Electrodes)
            {
                electrode.IsPosterior = isPosterior;
            }
        }

        #endregion


        #region Electrode Alignment Indication

        public void SetElectrodeAlignmentIndication(int electrodeNumber, bool meetsCriteria)
        {
            if (electrodeNumber < 0 || electrodeNumber >= Electrodes.Count)
                return;

            Electrodes[electrodeNumber].MeetsAlignmentCriteria = meetsCriteria;
        }

        public void SetAllElectrodeAlignmentIndication(bool meetsCriteria)
        {
            foreach (var electrode in Electrodes)
            {
                electrode.MeetsAlignmentCriteria = meetsCriteria;
            }
        }

        #endregion


        #region Electrode Number of Activations

        public void SetElectrodeNumberOfActivations(int electrodeNumber, int numberOfActivations)
        {
            if (electrodeNumber < 0 || electrodeNumber >= Electrodes.Count)
                return;

            Electrodes[electrodeNumber].NumberOfActivations = numberOfActivations;
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

        private string _advanceColoringTitle = "";
        public string AdvanceColoringTitle 
        { 
            get { return _advanceColoringTitle; }
            set
            {
                _advanceColoringTitle = value;
                NotifyPropertyChanged();
            }
        }
        private bool _inReview = false;
        public bool IsInReview
        {
            get { return _inReview;  }
            set
            {
                _inReview = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isPostAblation = false;
        public bool IsPostAblation
        {
            get { return _isPostAblation; }
            set 
            {
                _isPostAblation = value;
                NotifyPropertyChanged();
            }
        }

        public void SetElectrodeAblationResult(int electrodeNumber, double result)
        {
            if (electrodeNumber < 0 || electrodeNumber >= Electrodes.Count)
                return;

            Electrodes[electrodeNumber].Intensity = result;
        }
        public void SetElectrodeColors(int electrodeNumber, Color low, Color high)
        {
            if (electrodeNumber < 0 || electrodeNumber >= Electrodes.Count)
                return;

            Electrodes[electrodeNumber].ColorLow = low;
            Electrodes[electrodeNumber].ColorHigh = high;
        }
        public void SetAllElectrodeColors(Color low, Color high)
        {
            foreach (var electrode in Electrodes)
            {
                electrode.ColorLow = low;
                electrode.ColorHigh = high;
            }
        }
        public void SetElectrodeStatus(int electrodeNumber, ElectrodeStatus status)
        {
            if (electrodeNumber < 0 || electrodeNumber >= Electrodes.Count)
                return;

            Electrodes[electrodeNumber].Status = status;
        }
        public void SetAllElectrodeStatus(ElectrodeStatus status)
        {
            foreach (var electrode in Electrodes)
            {
                electrode.Status = status;
            }
        }
        #endregion


        #region Deflection Lines
        public ObservableCollection<DeflectionLineModel> DeflectionLines { get; }

        #endregion

        public event Action OnPlayClicked = delegate { };

        public ICommand PlayCommand { get; }
    }

}