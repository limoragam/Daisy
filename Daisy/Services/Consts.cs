using Daisy.Enums;
using System.Collections.Generic;

namespace Daisy.Consts
{
    public class Range
    {
        public double Start { get; set; }
        public double End { get; set; }

        public Range(double start, double end)
        {
            Start = start;
            End = end;
        }
    }

    public static class AblationParamInfo
    {
        public static readonly Dictionary<EAblationParam, Range> Scales = new Dictionary<EAblationParam, Range>
        {
            { EAblationParam.ImpedanceDrop, new Range(10.0, 40.0) },
            { EAblationParam.TemperatureRise, new Range(5.0, 10.0) }
        };
    }
}
