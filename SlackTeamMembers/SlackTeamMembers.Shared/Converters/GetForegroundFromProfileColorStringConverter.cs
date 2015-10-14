using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace SlackTeamMembers.Converters
{
    public class GetForegroundFromProfileColorStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()))
                return new SolidColorBrush(Colors.White);

            try
            {
                byte pos = 0;

                string hex = value.ToString().Replace("#","");

                if (hex.Length == 8)
                    pos = 2;

                byte red = System.Convert.ToByte(hex.Substring(pos, 2), 16);

                pos += 2;
                byte green = System.Convert.ToByte(hex.Substring(pos, 2), 16);

                pos += 2;
                byte blue = System.Convert.ToByte(hex.Substring(pos, 2), 16);

                double a = 1 - (0.299 * red + 0.587 * green + 0.114 * blue) / 255;

                var d = a < 0.5 ? 0 : 255;

                return Color.FromArgb(255, System.Convert.ToByte(d), System.Convert.ToByte(d), System.Convert.ToByte(d));
            }
            catch (Exception)
            {
                return Colors.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}