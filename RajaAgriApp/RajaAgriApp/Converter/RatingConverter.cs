using System;
using System.Globalization;
using Xamarin.Forms;

namespace RajaAgriApp.Converter
{
    public class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRating = (bool)value;
            if (isRating)
            {
                //orange color
                return  Color.FromHex("#ffd732");
            }
            //Defult color
            return Color.FromHex("#e5e5e9");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }


}
