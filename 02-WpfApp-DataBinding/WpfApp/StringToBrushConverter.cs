using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

public class StringToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string colorName)
        {
            try
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorName));
            }
            catch
            {
                return Brushes.Black; // Default color if conversion fails
            }
        }
        return Brushes.Black;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}