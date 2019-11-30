using System.ComponentModel;

namespace Daisy.ViewModels
{
    public class ElectrodeViewModel : ViewModelBase
    {
        public ElectrodeViewModel(int number, 
                                  EOrientationMarker orientationMarker, 
                                  bool isPosterior, 
                                  double angle,
                                  double height)
        {
            Number = number;
            OrientationMarker = orientationMarker;
            IsPosterior = isPosterior;
            Angle = angle;
            Height = height;
        }

        #region Data

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

        public double Height { get; set; }

        public int NumberFontSize
        {
            get
            {
                int fontSize = 13;
                int height = (int)Height - 80;
                while (height > 20)
                {
                    ++fontSize;
                    height -= 20;
                }
                return fontSize;
            }
        }

        #endregion
    }

    public enum EAblationPhase
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