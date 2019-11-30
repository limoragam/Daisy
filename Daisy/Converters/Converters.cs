using System;
using System.Globalization;
using System.Windows;
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

    public class BoolToVisibilityConverter : ConverterMarkupExtension<BoolToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is bool))
                return Binding.DoNothing;

            // Parameter can be used to convert to Hidden instead of Collapsed
            Visibility negativeVisibility = Visibility.Collapsed;
            if (!(parameter is null))
            {
                if (Enum.TryParse<Visibility>((string)parameter, true, out Visibility parsedVisibility))
                {
                    negativeVisibility = parsedVisibility;
                }
            }

            return (bool)value ? Visibility.Visible : negativeVisibility;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is Visibility))
                return Binding.DoNothing;

            return (Visibility)value == Visibility.Visible ? true : false;
        }
    }
}
