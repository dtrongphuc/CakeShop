using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CakeShop.Converter
{
    public class StringToCurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueString = value as string;

            double valueNumber = Double.Parse(valueString);

            if (value is string && valueNumber == 0)
            {
                return "0 vnđ";
            }
            return String.Format("{0:#,#} vnđ", valueNumber);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
