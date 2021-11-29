using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Xamarin.Forms;

namespace Pogoda2
{
    class KonwerternaPolski:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            switch(value as String)
            {
               case "Snow":
               
                    return "Śnieg";
                   
               case "Rain":
                    return "Deszcz";
                case "Clouds":
                    return "Pochmurnie";
                case "Clear":
                    return "Bezchmurnie";


                default:
                    return value;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
    class KonwerternaIkone : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            switch (value as String)
            {
                case "Snow":

                    return "snieg.png";

                case "Rain":
                    return "deszcz.png";
                case "Clouds":
                    return "chmury.png";
                case "Clear":
                    return "slonce.png";


                default:
                    return value;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
    class KonwerterCelsjusze : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return ((double)value).ToString() + "°C";
                 
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
