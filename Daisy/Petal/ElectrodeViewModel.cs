using System.ComponentModel;

namespace Daisy.ViewModels
{
    public class ElectrodeViewModel : INotifyPropertyChanged
    {
        public ElectrodeViewModel(int number, int totalNumberOfElectrodes, bool isPosterior, bool meetsAlignmentCriteria)
        {
            Number = number;
            TotalNumberOfElectrodes = totalNumberOfElectrodes;
            IsPosterior = isPosterior;
            MeetsAlignmentCriteria = meetsAlignmentCriteria;
        }

        #region Data

        public int Number { get; set; } = 1;
        public bool IsPosterior { get; set; } = false;
        public bool IsSelected { get; set; } = true;
        public bool MeetsAlignmentCriteria { get; set; } = false;
        public EOrientationMarker OrientationMarker { get; set; }

        private EAblationState _ablationState = EAblationState.Before;
        public EAblationState AblationState
        {
            get { return _ablationState; }
            set 
            { 
                _ablationState = value;
                NotifyPropertyChanged(nameof(AblationState));
            }
        }

        private int _numberOfActivations = 0;
        public int NumberOfActivations
        {
            get { return _numberOfActivations; }
            set 
            { 
                _numberOfActivations = value;
                NotifyPropertyChanged(nameof(NumberOfActivations));
            }
        }

        private EAblationResult _ablationResult;
        public EAblationResult AblationResult
        {
            get { return _ablationResult; }
            set
            {
                _ablationResult = value;
                NotifyPropertyChanged(nameof(AblationResult));
            }
        }

        #endregion


        #region Visual

        private int _totalNumberOfElectrodes = 0;
        public int TotalNumberOfElectrodes
        {
            set
            {
                _totalNumberOfElectrodes = value;
                NotifyPropertyChanged(nameof(Angle));
            }
        }

        public double Angle 
        { 
            get
            {
                return CalculateAngle();
            }
        }

        private double CalculateAngle()
        {
            if (_totalNumberOfElectrodes != 0)
            {
                return 360.0 * (Number-1) / _totalNumberOfElectrodes;
            }
            return 0;
        }

        public int Height
        {
            get
            {
                return 60;
            }
        }

        public int NumberFontSize
        {
            get
            {
                return 14;
            }
        }

        public int IndicatorHeight
        {
            get
            {
                return 12;
            }
        }

        #endregion


        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }

    public enum EAblationState
    {
        Before,
        During,
        After
    }

    public enum EOrientationMarker
    {
        None,
        Rectangle,
        SolidTriangle,
        OutlineTriangle
    }

    public enum EAblationResult
    {
        Light,
        Medium,
        Heavy
    }
}