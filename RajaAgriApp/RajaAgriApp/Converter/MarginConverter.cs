using RajaAgriApp.Common;
using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;

namespace RajaAgriApp.Converter
{
    public class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int DropDownType=(int)value;
            switch(DropDownType)
            {
                case 0:
                    return new Thickness(20,145,20,20);
                case 1:
                    return new Thickness(20, 235, 20, 20);
                case 2:
                    return new Thickness(20, 325, 20, 20);
                case 3:
                    return new Thickness(20, 145, 20, 20);
                case 4:
                    return new Thickness(20, 325, 20, 20);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }


}
