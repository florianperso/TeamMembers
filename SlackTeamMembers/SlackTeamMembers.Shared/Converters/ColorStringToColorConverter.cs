using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace SlackTeamMembers.Converters
{
    public class ColorStringToColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(string.IsNullOrWhiteSpace(value?.ToString()))
                return new SolidColorBrush(Color.FromArgb(255,64,49,59));

            byte alpha;
            byte pos = 0;
            string hex = value.ToString().Replace("#","");

            if (hex.Length == 8)
            {
                alpha = System.Convert.ToByte(hex.Substring(pos, 2), 16);
                pos = 2;
            }
            else
                alpha = System.Convert.ToByte("ff", 16);

            byte red = System.Convert.ToByte(hex.Substring(pos, 2), 16);

            pos += 2;
            byte green = System.Convert.ToByte(hex.Substring(pos, 2), 16);

            pos += 2;
            byte blue = System.Convert.ToByte(hex.Substring(pos, 2), 16);

            return new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
