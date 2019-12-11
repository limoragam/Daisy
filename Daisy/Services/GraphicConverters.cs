using Daisy.Consts;
using Daisy.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Daisy.Converters
{
    // Receives: 
    // 1. Result value
    // 2. EAblationParam (result type)
    // Return:
    // Gradient brush from value's corresponding percentage color scale, to a shadowed version of the same color
    public class AblationResultToGradientBrushConverter : MultiConverterMarkupExtension<AblationResultToGradientBrushConverter>
    {
        // Color scale
        private Color ColorScaleHigh;
        private Color ColorScaleLow;
        private Color ColorRange;

        // Ablation result scale
        private EAblationParam AblationParam = EAblationParam.ImpedanceDrop;
        private double AblationResultScaleStart;
        private double AblationResultScaleEnd;
        private double AblationResultRange;
        
        public AblationResultToGradientBrushConverter()
        {
            SetColorScale();
            SetAblationResultScale();
        }

        private void SetColorScale()
        {
            ColorScaleHigh = Color.FromRgb(251, 201, 201);
            ColorScaleLow = Color.FromRgb(183, 0, 0);
            ColorRange = Color.Subtract(ColorScaleHigh, ColorScaleLow);
        }

        private void SetAblationResultScale()
        {
            AblationResultScaleStart = AblationParamInfo.Scales[AblationParam].Start;
            AblationResultScaleEnd = AblationParamInfo.Scales[AblationParam].End;
            AblationResultRange = AblationResultScaleEnd - AblationResultScaleStart;
        }

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || values[0] == null || !(values[0] is double) || values[1] == null)
                return Binding.DoNothing;

            EAblationParam ablationParam = (EAblationParam)Enum.Parse(typeof(EAblationParam), values[1].ToString());
            if (ablationParam != AblationParam)
            {
                AblationParam = ablationParam;
                SetAblationResultScale();
            }

            if (AblationResultRange <= 0.0)
                return Binding.DoNothing;

            // Calculate result color
            double result = Math.Max(AblationResultScaleStart, Math.Min(AblationResultScaleEnd, (double)values[0]));    // Limit result to range
            double percentage = 1 - ((result - AblationResultScaleStart) / AblationResultRange);
            // (Multiply won't work here for a fluid scale)
            Color resultColor = Color.FromRgb((byte)(ColorRange.R * percentage),
                                              (byte)(ColorRange.G * percentage), 
                                              (byte)(ColorRange.B * percentage)) + ColorScaleLow;

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
