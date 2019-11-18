using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Daisy.Converters
{
    // Returns Visible if Enum matches any in the list inside parameter
    // Example list: ConverterParameter='EBig; EVeryBig'
    public class EnumToVisibilityConverter : ConverterMarkupExtension<EnumToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value == null) || (!(value is Enum)) || (parameter == null))
            {
                return Binding.DoNothing;
            }
            Visibility eRet = Visibility.Collapsed;

            string paramsParsed = parameter.ToString();
            bool invert = ConverterAssists.CheckForCharAndRemove('!', ref paramsParsed);

            if (ConverterAssists.CheckForCharAndRemove('#', ref paramsParsed))
            {
                eRet = Visibility.Hidden;
            }

            var enums = ConverterAssists.ParseStringToEnum(value.GetType(), paramsParsed);

            foreach (Enum paramValue in enums)
            {
                if (value.Equals(paramValue))
                {
                    eRet = Visibility.Visible;
                }
            }

            if (invert)
            {
                if (eRet == Visibility.Visible)
                {
                    eRet = Visibility.Collapsed;
                }
                else if (eRet == Visibility.Collapsed)
                {
                    eRet = Visibility.Visible;
                }
            }

            return eRet;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    // Returns true if Enum matches any in the list inside parameter
    // Example list: ConverterParameter='EBig; EVeryBig'
    public class EnumToBoolConverter : ConverterMarkupExtension<EnumToBoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value == null) || (!(value is Enum)) || (parameter == null))
            {
                return Binding.DoNothing;
            }

            bool bRet = false;

            string paramString = parameter.ToString();
            bool invert = ConverterAssists.CheckForCharAndRemove('!', ref paramString);

            var enums = ConverterAssists.ParseStringToEnum(value.GetType(), paramString);
            foreach (Enum paramValue in enums)
            {
                if (value.Equals(paramValue))
                {
                    bRet = true;
                }
            }

            if (invert)
            {
                bRet = !bRet;
            }

            return bRet;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            string paramString = parameter.ToString();
            if (ConverterAssists.CheckForCharAndRemove('!', ref paramString))
            {
                boolValue = !boolValue;
            }

            return boolValue ? paramString : Binding.DoNothing;
        }

    }
    public static class ConverterAssists
    {
        public static IEnumerable<Enum> ParseStringToEnum(Type enumType, string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Empty or null string");
            }

            string[] strArray = str.Split(new[] { '|', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var enumArray = new Enum[strArray.Length];
            for (int i = 0; i < strArray.Length; ++i)
            {
                enumArray[i] = (Enum)Enum.Parse(enumType, strArray[i], true);
            }

            return enumArray;
        }

        public static bool CheckForCharAndRemove(char c, ref string str)
        {
            bool containsChar = str.Contains(c);
            if (containsChar)
            {
                str = str.Remove(str.IndexOf(c), 1);
            }
            return containsChar;
        }
    }

}
