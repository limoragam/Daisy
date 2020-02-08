using Daisy.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace daisy.Converters
{
    public class IntensityToGradientBrushConverter : MultiConverterMarkupExtension<IntensityToGradientBrushConverter>
    {
        public IntensityToGradientBrushConverter()
        {
            
        }

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3 || 
                values[0] == null || !(values[0] is double) ||
                values[1] == null || !(values[1] is Color) ||
                values[2] == null || !(values[2] is Color))
                return Binding.DoNothing;

            double f = (double)values[0];
            Color L = (Color)values[1];
            Color H = (Color)values[2];

            // (Multiply won't work here for a fluid scale)
            Color resultColor = Color.FromRgb((byte)(H.R * f + L.R * (1 - f)),
                                              (byte)(H.G * f + L.G * (1 - f)),
                                              (byte)(H.B * f + L.B * (1 - f)));

            // Create brush
            List<GradientStop> gradientStops = new List<GradientStop>() 
            {
                new GradientStop(Color.Multiply(resultColor, 0.43F), 0.0),
                new GradientStop(Color.Multiply(resultColor, 0.7F), 0.25),
                new GradientStop(resultColor, 1.0)
            };
            LinearGradientBrush brush = new LinearGradientBrush(new GradientStopCollection(gradientStops), new Point(0, 0), new Point(0, 1));

            return brush;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
