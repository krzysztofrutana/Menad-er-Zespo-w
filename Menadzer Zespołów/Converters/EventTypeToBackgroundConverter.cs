using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Menadzer_Zespołów.Converters
{
    class EventTypeToBackgroundConverter : DependencyObject, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Wesele":
                    return new SolidColorBrush(Color.FromRgb(0, 255, 128));
                case "Poprawiny":
                    return new SolidColorBrush(Color.FromRgb(255, 255, 51));
                case "Koncert":
                    return new SolidColorBrush(Color.FromRgb(0, 128, 255));
                default:
                    return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
