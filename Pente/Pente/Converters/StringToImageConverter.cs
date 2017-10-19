using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Pente.Converters
{
    class StringToImageConverter : IValueConverter
    {
        public Brush BlackStoneBrush { get; set; }
        public Brush WhiteStoneBrush { get; set; }
        public Brush NoStoneBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush scb = null;
            if (targetType == typeof(Brush))
            {
                string stringVal = (string)value;
                if (stringVal == "X")
                {
                    scb = BlackStoneBrush;
                }
                else if (stringVal == "Y")
                {
                    scb = WhiteStoneBrush;
                }
                else
                {
                    scb = NoStoneBrush;
                }
            }

            return scb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
