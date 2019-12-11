using Daisy.Enums;

namespace Daisy.ViewModels
{
    public class ElectrodeViewModel : ViewModelBase
    {
        public ElectrodeViewModel(int number, 
                                  EOrientationMarker orientationMarker, 
                                  bool isPosterior)
        {
            Number = number;
            OrientationMarker = orientationMarker;
            IsPosterior = isPosterior;
        }

        public int Index 
        { 
            get
            {
                return Number - 1;
            }
        }
        public int Number { get; set; } = 1;
        public EOrientationMarker OrientationMarker { get; set; }
        public bool IsPosterior { get; set; } = false;

        private bool _meetsAlignmentCriteria = false;
        public bool MeetsAlignmentCriteria
        {
            get { return _meetsAlignmentCriteria; }
            set 
            { 
                _meetsAlignmentCriteria = value;
                NotifyPropertyChanged();
            }
        }

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

        private EAblationPhase _ablationPhase = EAblationPhase.Before;
        public EAblationPhase AblationPhase
        {
            get { return _ablationPhase; }
            set 
            { 
                _ablationPhase = value;
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

        private EAblationParam _ablationParam = EAblationParam.ImpedanceDrop;
        public EAblationParam AblationParam
        {
            get { return _ablationParam; }
            set 
            { 
                _ablationParam = value;
                NotifyPropertyChanged();
            }
        }

        private double _ablationResult;
        public double AblationResult
        {
            get { return _ablationResult; }
            set 
            { 
                _ablationResult = value;
                NotifyPropertyChanged();
            }
        }

    }
}