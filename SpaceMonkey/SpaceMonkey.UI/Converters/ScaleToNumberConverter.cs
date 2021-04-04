using SpaceMonkey.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMonkey.UI.Converters
{
    public class ScaleToNumberConverter : BaseValueConverter<ScaleToNumberConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value != null)
            {
                double scale = (double)value;
                return ScaleFactorHelper.DoubleToScale(scale);
            }
            else return string.Empty;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string scale = value as string;
                return ScaleFactorHelper.ScaleToDouble(scale);
            }
            else return 0;
        }
    }
}
