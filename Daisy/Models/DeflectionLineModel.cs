using Daisy.Enums;

namespace daisy.ViewModels
{
    public class DeflectionLineModel : BaseViewModel
    {
        public DeflectionLineModel(DeflectionDirection direction)
        {
            Direction = direction;
        }

        public DeflectionDirection Direction { get; set; }
    }

}