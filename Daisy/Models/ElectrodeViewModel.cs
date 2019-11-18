using System.ComponentModel;

namespace Daisy.ViewModels
{
    public class ElectrodeViewModel : ViewModelBase
    {
        public ElectrodeViewModel(int number, 
                                  EOrientationMarker orientationMarker, 
                                  bool isPosterior, 
                                  bool meetsAlignmentCriteria, 
                                  double angle)
        {
            Number = number;
            OrientationMarker = orientationMarker;
            IsPosterior = isPosterior;
            MeetsAlignmentCriteria = meetsAlignmentCriteria;
            Angle = angle;
        }

        #region Data

        public int Number { get; set; } = 1;
        public EOrientationMarker OrientationMarker { get; set; }
        public bool IsPosterior { get; set; } = false;
        public bool MeetsAlignmentCriteria { get; set; } = false;

        private bool _isSelected = true;
        public bool IsSelected
        {
            get { return _isSelected; }
            set 
            { 
                _isSelected = value;
                NotifyPropertyChanged();
            }
        }


        private EAblationState _ablationState = EAblationState.Before;
        public EAblationState AblationState
        {
            get { return _ablationState; }
            set 
            { 
                _ablationState = value;
                NotifyPropertyChanged();
            }
        }

        private int _numberOfActivations = 0;
        public int NumberOfActivations
        {
            get { return _numberOfActivations; }
            set 
            { 
                _numberOfActivations = value;
                NotifyPropertyChanged();
            }
        }

        private EAblationResult _ablationResult;
        public EAblationResult AblationResult
        {
            get { return _ablationResult; }
            set
            {
                _ablationResult = value;
                NotifyPropertyChanged();
            }
        }

        #endregion


        #region Visual

        public double Angle { get; set; }

        public int Height { get; set; }

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