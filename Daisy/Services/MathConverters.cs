using System;
using System.Globalization;
using System.Windows.Data;


namespace Daisy.Converters
{
    // Returns a percentage of input length/number
    public class PercentageConverter : ConverterMarkupExtension<PercentageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToDouble(value) == 0 || System.Convert.ToDouble(parameter) == 0)
                return Binding.DoNothing;
            return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    // Is value more than param?
    public class MoreThanConverter : ConverterMarkupExtension<MoreThanConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return Binding.DoNothing;
            return System.Convert.ToDouble(value) > System.Convert.ToDouble(parameter);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    // Receives: 
    // 1. Pie slice number (start count at 0)
    // 2. Total number of slices
    // 3. Angle (degrees) of first slice (optional, will assume 0 otherwise)
    // Returns: angle (degrees) of slice
    public class PieSliceNumberToAngleConverter : MultiConverterMarkupExtension<PieSliceNumberToAngleConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || values[0] == null || values[1] == null)
                return Binding.DoNothing;

            int sliceNumber = System.Convert.ToInt32(values[0]);
            int numberOfSlices = System.Convert.ToInt32(values[1]);
            double startAtAngle = 0;
            if (values.Length > 2 && values[2] != null)
            {
                startAtAngle = System.Convert.ToDouble(values[2]);
            }
            return 360.0 * sliceNumber / numberOfSlices + startAtAngle;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Receives: 
    // 1. Radius
    // 2. Total number of slices
    // Returns: chord length
    // NOTE: this takes into account a small space between pie slices
    public class NumberOfPieSlicesToChordConverter : MultiConverterMarkupExtension<NumberOfPieSlicesToChordConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || values[0] == null || values[1] == null)
                return Binding.DoNothing;

            double radius = System.Convert.ToDouble(values[0]);
            int numberOfSlices = System.Convert.ToInt32(values[1]);

            if (radius <= 0 || numberOfSlices <= 0)
                return Binding.DoNothing;

            double thetaRad = 0.7 * 2 * Math.PI / numberOfSlices;  // 0.97 is for some space between pie slices
            double chord = 2* Math.Abs((int)(Math.Sin(thetaRad / 2) * radius));
            return chord;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
