using System.Windows.Media;
using Daisy.Enums;

namespace daisy.ViewModels
{
    public class ElectrodeViewModel : BaseViewModel
    {
        public ElectrodeViewModel(int number)
        {
            Number = number;
        }

        public int Index 
        { 
            get
            {
                return Number - 1;
            }
        }
        public int Number { get; }
        public ElectrodeFluoroMarker FluoroMarker { get; set; } = ElectrodeFluoroMarker.None;

        private bool _isPosterior;
        public bool IsPosterior
        {
            get { return _isPosterior; }
            set 
            { 
                _isPosterior = value;
                NotifyPropertyChanged();
            }
        }

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

        ElectrodeStatus _status = ElectrodeStatus.NotSelected;
        public ElectrodeStatus Status
        {
            get { return _status; }
            set
            {
                if (Status == value)
                    return;

                _status = value;
                switch (_status)
                {
                    case ElectrodeStatus.Disconnected:
                        TextDark = false;
                        ColorLow = ColorHigh = Color.FromRgb(0, 0, 0);
                        break;

                    case ElectrodeStatus.NotSelected:
                        TextDark = false;
                        ColorLow = ColorHigh = Color.FromRgb(88, 88, 88);
                        break;

                    case ElectrodeStatus.Selected:
                        TextDark = true;
                        ColorLow = ColorHigh = Color.FromRgb(255, 210, 0);
                        break;

                    case ElectrodeStatus.Ablating:
                        TextDark = false;
                        ColorLow = ColorHigh = Color.FromRgb(255, 0, 0);
                        break;

                    case ElectrodeStatus.PostAblation:
                        TextDark = false;
                        ColorLow = Color.FromRgb(255, 204, 204);
                        ColorHigh = Color.FromRgb(255, 0, 0);
                        break;

                    case ElectrodeStatus.NoColoringIndicators:
                        TextDark = false;
                        ColorLow = ColorHigh = Color.FromRgb(128, 0, 0);
                        break;
                }
                NotifyPropertyChanged();
            }
        }

        private bool _textDark;
        public bool TextDark
        {
            get { return _textDark; }
            set
            {
                _textDark = value;
                NotifyPropertyChanged();
            }
        }

        private Color _colorLow;
        public Color ColorLow
        {
            get { return _colorLow; }
            set
            {
                _colorLow = value;
                NotifyPropertyChanged();
            }
        }

        private Color _colorHigh;
        public Color ColorHigh
        {
            get { return _colorHigh; }
            set
            {
                _colorHigh = value;
                NotifyPropertyChanged();
            }
        }

        private double _intensity;
        public double Intensity
        {
            get { return _intensity; }
            set 
            {
                _intensity = value;
                NotifyPropertyChanged();
            }
        }

    }
}