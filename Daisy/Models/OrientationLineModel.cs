using Daisy.Enums;

namespace Daisy.ViewModels
{
    public class OrientationLineModel : ViewModelBase
    {
        public OrientationLineModel(EDirection direction)
        {
            Direction = direction;
        }

        public EDirection Direction { get; set; }
    }

}