using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SlackTeamMembers.Converters
{
    public class InvertedBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return Visibility.Visible;
            
            bool val;

            if (!bool.TryParse(value.ToString(), out val))
                return Visibility.Visible;

            return val ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}