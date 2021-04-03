using SpaceMonkey.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMonkey.UI.Converters
{
    public class CategoryToIdConverter : BaseValueConverter<CategoryToIdConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value != null)
            {
                int id = (int)value;
                return CategoryIdHelper.IdToCategory(id);
            }
            else return string.Empty;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string category = value as string;
                return CategoryIdHelper.CategoryToId(category);
            }
            else return 0;
        }
    }
}
